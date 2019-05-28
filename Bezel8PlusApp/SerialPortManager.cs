﻿using System;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bezel8PlusApp
{

    public enum PktType
    {
        SI = 0,
        STX = 1
    }

    public sealed class SerialPortManager
    {
        private static readonly Lazy<SerialPortManager> lazy = new Lazy<SerialPortManager>(() => new SerialPortManager());
        public static SerialPortManager Instance { get { return lazy.Value; } }

        private SerialPort _serialPort;
        private Queue<byte[]> _messageQueue;

        private SerialPortManager()
        {
            _serialPort = new SerialPort();
            _messageQueue = new Queue<byte[]>();
            Console.WriteLine(_serialPort.ReadTimeout);

            //_serialPort.DataReceived += new SerialDataReceivedEventHandler(RataReceive_test);
        }

        /// <summary>
        /// Update the serial port status to the event subscriber
        /// </summary>
        public event EventHandler<string> OnStatusChanged;

        /// <summary>
        /// Update received data from the serial port to the event subscriber
        /// </summary>
        public event EventHandler<byte[]> OnDataSent;

        /// <summary>
        /// Update received data from the serial port to the event subscriber
        /// </summary>
        public event EventHandler<byte[]> OnDataReceived;


        /// <summary>
        /// Update TRUE/FALSE for the serial port connection to the event subscriber
        /// </summary>
        public event EventHandler<bool> OnSerialPortOpened;

        /// <summary>
        /// Return TRUE if the serial port is currently connected
        /// </summary>
        public bool IsOpen { get { return _serialPort.IsOpen; } }

        public int GetWriteBufferSize() { return _serialPort.WriteBufferSize; }

        /// <summary>
        /// Open the serial port connection using basic serial port settings
        /// </summary>
        /// <param name="portname">COM1 / COM3 / COM4 / etc.</param>
        /// <param name="baudrate">0 / 100 / 300 / 600 / 1200 / 2400 / 4800 / 9600 / 14400 / 19200 / 38400 / 56000 / 57600 / 115200 / 128000 / 256000</param>
        /// <param name="parity">None / Odd / Even / Mark / Space</param>
        /// <param name="databits">5 / 6 / 7 / 8</param>
        /// <param name="stopbits">None / One / Two / OnePointFive</param>
        /// <param name="handshake">None / XOnXOff / RequestToSend / RequestToSendXOnXOff</param>
        public void Open(
            string portname = "COM1",
            int baudrate = 9600,
            Parity parity = Parity.None,
            int databits = 8,
            StopBits stopbits = StopBits.One,
            Handshake handshake = Handshake.None)
        {
            Close();

            try
            {
                _serialPort.PortName = portname;
                _serialPort.BaudRate = baudrate;
                _serialPort.Parity = parity;
                _serialPort.DataBits = databits;
                _serialPort.StopBits = stopbits;
                _serialPort.Handshake = handshake;

                _serialPort.ReadTimeout = 5000;
                //_serialPort.WriteTimeout = 200;

                _serialPort.Open();
                //StartReading();
            }
            catch (IOException)
            {
                if (OnStatusChanged != null)
                    OnStatusChanged(this, string.Format("{0} does not exist.", portname));
            }
            catch (UnauthorizedAccessException)
            {
                if (OnStatusChanged != null)
                    OnStatusChanged(this, string.Format("{0} already in use.", portname));
            }
            catch (Exception ex)
            {
                if (OnStatusChanged != null)
                    OnStatusChanged(this, "Error: " + ex.Message);
            }

            if (_serialPort.IsOpen)
            {
                string sb = StopBits.None.ToString().Substring(0, 1);
                switch (_serialPort.StopBits)
                {
                    case StopBits.One:
                        sb = "1"; break;
                    case StopBits.OnePointFive:
                        sb = "1.5"; break;
                    case StopBits.Two:
                        sb = "2"; break;
                    default:
                        break;
                }

                string p = _serialPort.Parity.ToString().Substring(0, 1);
                string hs = _serialPort.Handshake == Handshake.None ? "No Handshake" : _serialPort.Handshake.ToString();

                if (OnStatusChanged != null)
                    OnStatusChanged(this, string.Format(
                    "Connected to {0}: {1} bps, {2}{3}{4}, {5}.",
                    _serialPort.PortName,
                    _serialPort.BaudRate,
                    _serialPort.DataBits,
                    p,
                    sb,
                    hs));

                if (OnSerialPortOpened != null)
                    OnSerialPortOpened(this, true);
            }
            else
            {
                if (OnStatusChanged != null)
                    OnStatusChanged(this, string.Format(
                    "{0} already in use.",
                    portname));

                if (OnSerialPortOpened != null)
                    OnSerialPortOpened(this, false);
            }
        }

        /// <summary>
        /// Close the serial port connection
        /// </summary>
        public void Close()
        {
            _serialPort.Close();

            if (OnStatusChanged != null)
                OnStatusChanged(this, "Connection closed.");

            if (OnSerialPortOpened != null)
                OnSerialPortOpened(this, false);
        }

        public void WriteAndReadMessage(PktType type, string head, string body, out string responseOut, int readTimeOut = 0)
        {
            string prefix = String.Empty;
            string suffix = String.Empty;
            responseOut = String.Empty;

            if (type == PktType.SI)
            {
                prefix = Convert.ToChar(0x0F).ToString();
                suffix = Convert.ToChar(0x0E).ToString();
            }
            else if (type == PktType.STX)
            {
                prefix = Convert.ToChar(0x02).ToString();
                suffix = Convert.ToChar(0x03).ToString();
            }
            else
            {
                // TODO: VCAS command handling
            }

            string packed_meaasge = prefix + head + body + suffix;
            byte lrc = DataManager.LRCCalculator(Encoding.ASCII.GetBytes(packed_meaasge), packed_meaasge.Length);

            if (_serialPort.BytesToRead > 0)
                _serialPort.DiscardInBuffer();

            if (_serialPort.BytesToWrite > 0)
                _serialPort.DiscardOutBuffer();

            // Sending message
            try
            {
                _serialPort.Write(packed_meaasge + Convert.ToChar(lrc).ToString());
                if (OnDataSent != null)
                {
                    byte[] data_sent = Encoding.ASCII.GetBytes(packed_meaasge + Convert.ToChar(lrc).ToString());
                    OnDataSent(this, data_sent);
                }
            }
            catch(InvalidOperationException)
            {
                throw new System.InvalidOperationException("Serial Port is not open.");
            }
            catch (Exception)
            {
                throw new System.Exception("Sending message failed.");
            }


            // Check if ACK is received
            try
            {
                byte[] controlCode = new byte[1];
                _serialPort.Read(controlCode, 0, 1);

                if (OnDataReceived != null)
                {
                    OnDataReceived(this, controlCode);
                }

                switch (controlCode[0])
                {
                    case 0x06:
                    case 0x04:
                        Console.WriteLine("Received 0x{0} from the reader.", controlCode[0].ToString("X2"));
                        //Console.WriteLine("BytesToWrite = {0}", _serialPort.BytesToWrite);
                        break;

                    case 0x15:
                        // NAK
                        throw new System.Exception("Received NAK from reader: Incorrect LRC.");

                    default:
                        // Unknown
                        throw new System.Exception("Unknown response: 0x" + controlCode[0].ToString("X2"));
                }
            }
            catch (TimeoutException)
            {
                // Reader no response;
                throw new System.TimeoutException("Timeout: No ACK");
            }
            catch (Exception)
            {
                throw new System.Exception("Waitting ACK failed.");
            }

            // Retrieve return message from reader
            Stopwatch s = new Stopwatch();
            if (readTimeOut > 0)
                s.Start();
            while (s.Elapsed <= TimeSpan.FromMilliseconds(readTimeOut))
            {
                Application.DoEvents();
                if (_serialPort.BytesToRead > 0)
                    break;
            }
            s.Reset();

            if (_serialPort.BytesToRead > 0)
            {
                int bytes = _serialPort.BytesToRead;
                byte[] readBuffer = new byte[bytes];
                _serialPort.Read(readBuffer, 0, bytes);
                if (OnDataReceived != null)
                {
                    OnDataReceived(this, readBuffer);
                }

                // Well recevied, check LRC
                if (readBuffer[bytes - 1] == DataManager.LRCCalculator(readBuffer, bytes - 1))
                {
                    // Send ACK
                    _serialPort.Write(Convert.ToChar(0x06).ToString());
                    if (OnDataSent != null)
                    {
                        byte[] ack = Encoding.ASCII.GetBytes(Convert.ToChar(0x06).ToString());
                        OnDataSent(this, ack);
                    }
                    responseOut = Encoding.ASCII.GetString(readBuffer, 1, bytes - 3);
                }
                else
                {
                    // Send NAK
                    _serialPort.Write(Convert.ToChar(0x15).ToString());
                    if (OnDataSent != null)
                    {
                        byte[] nak = Encoding.ASCII.GetBytes(Convert.ToChar(0x15).ToString());
                        OnDataSent(this, nak);
                    }
                }
            }
            else
            {
                throw new System.TimeoutException("Timeout: No response");
            }

        }
        


        public void RataReceive_test(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {         
            if (_serialPort.BytesToRead <= 0) return;

            int bytes = _serialPort.BytesToRead;
            byte[] buffer = new byte[bytes];
            _serialPort.Read(buffer, 0, bytes);

            Console.WriteLine($"RataReceive_test Received: {debug_test(buffer)}");
            if (OnDataReceived != null)
            {
                OnDataReceived(this, buffer);
            }
            /*
            if (bytes == 1)
            {
                
                if (buffer[0] == 0x06 || buffer[0] == 0x15 || buffer[0] == 0x04)
                {
                    // <ACK>, <NAK> or <EOT>
                }
            }
            if ((buffer[0] == 0x02 && buffer[bytes - 2] == 0x03) ||(buffer[0] == 0x0F && buffer[bytes - 2] == 0x0E))
            {
                if (buffer[bytes - 1] == DataManager.LRCCalculator(buffer, bytes - 1))
                {
                    // LRC correct
                    // Enqueue received message
                    lock (_messageQueue)
                    {
                        _messageQueue.Enqueue(buffer);
                        Console.WriteLine($"Enqueued: {debug_test(buffer)}");
                    }

                    // sending <ACK>
                    _serialPort.Write(Convert.ToChar(0x06).ToString());
                    if (OnDataSent != null)
                    {
                        byte[] data_sent = Encoding.ASCII.GetBytes(Convert.ToChar(0x06).ToString());
                        OnDataSent(this, data_sent);
                    }
                    Console.WriteLine("Sending ACK");

                    
                }
                else
                {
                    // Incorrect LRC, sending <NAK>
                    _serialPort.Write(Convert.ToChar(0x15).ToString());
                    Console.WriteLine("Sending NAK");
                }
            }
            else
            {
                // TODO: VCAS command handling
            }
            */
        }

        public string debug_test(byte[] byteArray)
        {
            string s = String.Empty;

            for (int i = 0; i < byteArray.Length; i++)
            {
                if (byteArray[i] < 0x20)
                {
                    s += "<" + byteArray[i].ToString("X2") + ">";
                }
                else
                {
                    s += Convert.ToChar(byteArray[i]).ToString();
                }
            }
            return s;

        }
        
        public string Dequeue(bool includeLRC = false)
        {
            string sMessage = String.Empty;
            byte[] bMessage = null;

            lock (_messageQueue)
            {
                if (_messageQueue.Count > 0)
                {
                    bMessage = _messageQueue.Dequeue();
                }
            }

            if (bMessage != null)
            {
                int end = includeLRC ? 0 : 1;
                sMessage = Encoding.ASCII.GetString(bMessage, 0, bMessage.Length - end);
            }

            return sMessage;
        } 

        /// <summary>
        /// Send/write string to the serial port
        /// </summary>
        /// <param name="message"></param>
        public void SendString(string message)
        {
            if (_serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Write(message);

                    if (OnStatusChanged != null)
                        OnStatusChanged(this, string.Format(
                        "Message sent: {0}",
                        message));
                }
                catch (Exception ex)
                {
                    if (OnStatusChanged != null)
                        OnStatusChanged(this, string.Format(
                            "Failed to send string: {0}",
                            ex.Message));
                }
            }
        }
    }
}
