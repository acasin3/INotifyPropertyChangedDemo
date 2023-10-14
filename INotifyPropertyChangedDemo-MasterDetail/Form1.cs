using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifyPropertyMasterDetailDemo
{
    public partial class Form1 : Form
    {
        Purchase mobjPurchase = new Purchase(1, 1, new DateTime(2023, 1, 12));

        public Form1()
        {
            InitializeComponent();
            mobjPurchase.Details.Add(new PurchaseDetail(1, 100));
            mobjPurchase.Details.Add(new PurchaseDetail(2, 30));

            BindControls();
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
            //MessageBox.Show(e.ColumnIndex.ToString());
            //MessageBox.Show(e.Exception.Message);
            e.Cancel = false;
        }
    }
}
