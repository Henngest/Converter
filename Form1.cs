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
        private CurrencyService currencyService;
        public Form1()
        {
            InitializeComponent();
            converter = new ConverterClass();
            currencyService = new CurrencyService();
            foreach(String item in converter.getUnitTypes())
            {
                cbUnit.Items.Add(item);
            }
            TimeSpan periodTimeSpan = TimeSpan.FromMinutes(1);
            System.Threading.Timer timer = new System.Threading.Timer((e) =>
            {
                backgroundWorker1.RunWorkerAsync();
            }, null, TimeSpan.Zero, periodTimeSpan);
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

        private void btnSwap_Click(object sender, EventArgs e)
        {
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
            int tempIndex;
            string tempValue;
            tempIndex = cbTo.SelectedIndex;
            cbTo.SelectedIndex = cbFrom.SelectedIndex;
            cbFrom.SelectedIndex = tempIndex;
            tempValue = tbValue.Text;
            tbValue.Text = tbConvertedValue.Text;
            tbConvertedValue.Text = tempValue;
        }

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lbStatus.Invoke(new Action(() => {
                lbStatus.Text = "Loading currencies...";
                lbStatus.ForeColor = Color.Yellow;
            }));
            try
            {
                List<Unit> listCurrencies = await currencyService.getCurrencies();
                converter.addUnits("Currency", listCurrencies);
                cbUnit.Invoke(new Action(() => {
                    cbUnit.Items.Clear();
                    foreach (String item in converter.getUnitTypes())
                        cbUnit.Items.Add(item);
                }));
            }
            catch
            {
                lbStatus.Invoke(new Action(() => {
                    lbStatus.Text = "Loading currencies failed";
                    lbStatus.ForeColor = Color.Red;
                }));
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbStatus.Invoke(new Action(() => {
                lbStatus.Text = "Loaded currencies at " + DateTime.Now.ToString("hh:mm:ss");
                lbStatus.ForeColor = Color.Green;
            }));
            
        }
    }
}
