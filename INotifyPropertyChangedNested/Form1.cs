using System;
using System.Windows.Forms;

namespace NotifyPropertyChangedNested
{
    public partial class Form1 : Form
    {
        VATSale mobjPurchase;

        public Form1()
        {
            InitializeComponent();
            try
            {
                mobjPurchase = new VATSale(1, 1, new DateTime(2024, 1, 12));
                mobjPurchase.Details.Add(new SaleDetail(1, "VT", 1120));
                mobjPurchase.Details.Add(new SaleDetail(2, "ZR", 30));

                BindControls();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindControls()
        {
            this.txtDocNo.DataBindings.Add("Text", mobjPurchase, "DocNo");
            this.dateTimePicker1.DataBindings.Add("Value", mobjPurchase, "DocDate");
            this.dataGridView1.DataSource = mobjPurchase.Details;
            this.lblTotal.DataBindings.Add("Text", mobjPurchase, "Total");
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
