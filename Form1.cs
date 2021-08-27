using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class Form1 : Form
    {
        private ConverterClass converter;
        public Form1()
        {
            InitializeComponent();
            converter = new ConverterClass();
            foreach(String item in converter.getUnitTypes())
            {
                cbUnit.Items.Add(item);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double i;
            if (cbUnit.SelectedIndex == -1)
            {
                epUnit.SetError(cbUnit, "Field required");
                return;
            }
            else
                epUnit.SetError(cbUnit, "");
            if (cbFrom.SelectedIndex == -1 || cbTo.SelectedIndex == -1)
            {
                epFrom.SetError(cbFrom, "Field required");
                epTo.SetError(cbTo, "Field required");
                return;
            }
            else
            {
                epFrom.SetError(cbFrom, "");
                epTo.SetError(cbTo, "");
            }
            if (!double.TryParse(tbValue.Text, out i))
            {
                epValue.SetError(tbValue, "Insert a number");
                return;
            }
            else
                epValue.SetError(tbValue, "");
            String selectedUnitType = cbUnit.SelectedItem.ToString();
            double result = converter.convert(cbFrom.SelectedItem.ToString(), cbTo.SelectedItem.ToString(), Convert.ToDouble(tbValue.Text), selectedUnitType);
            tbConvertedValue.Text = result.ToString();
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFrom.Items.Clear();
            cbTo.Items.Clear();
            foreach (Unit item in converter.getUnits(cbUnit.SelectedItem.ToString()))
            {
                cbFrom.Items.Add(item);
                cbTo.Items.Add(item);
            }
        }

    }
}
