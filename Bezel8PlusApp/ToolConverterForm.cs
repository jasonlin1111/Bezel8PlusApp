using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezel8PlusApp
{
    public partial class ToolConverterForm : Form
    {
        enum ConvertMode
        {
            HexToAscii,
            AsciiToHex
        };

        private ConvertMode _mode;
        private readonly string _hexIn = "Hex Input";
        private readonly string _hexOut = "Hex Output";
        private readonly string _textIn = "Text Input";
        private readonly string _textOut = "Text Output";


        public ToolConverterForm()
        {
            InitializeComponent();

            _mode = ConvertMode.HexToAscii;
            gbInput.Text = _hexIn;
            gbOutput.Text = _textOut;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbInput.Clear();
            tbOutput.Clear();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (_mode == ConvertMode.AsciiToHex)
            {
                _mode = ConvertMode.HexToAscii;
                gbInput.Text = _hexIn;
                gbOutput.Text = _textOut;
            }
            else
            {
                _mode = ConvertMode.AsciiToHex;
                gbInput.Text = _textIn;
                gbOutput.Text = _hexOut;

            }
                
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mode == ConvertMode.AsciiToHex)
                {
                    tbOutput.Text = DataHandler.ConvertAsciiToHex(tbInput.Text);
                }
                else
                {
                    tbOutput.Text = DataHandler.ConvertHexToAscii(tbInput.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
