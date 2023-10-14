using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifyPropertyMasterDetailDemo
{
    public class Purchase : INotifyPropertyChanged // Step 4 : Implement the INotifyProperyChanged interface
    {
        private int _docEntry;
        private int _docNo;
        private DateTime _docDate;
        private decimal _total;
        // Step 1 : Add a module-level variable of type BindingList for the details
        BindingList<PurchaseDetail> _purchaseDetails = new BindingList<PurchaseDetail>();

        // Step 5 : Implement member of the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        public Purchase(int docEntry, int docNo, DateTime docDate) 
        {
            _docEntry = docEntry;
            _docNo = docNo;
            _docDate = docDate;
            // Step 2 : Add a ListChanged event for the details
            _purchaseDetails.ListChanged += new ListChangedEventHandler(this.PurchaseDetailsChanged);
        }

        // Step 6 : Create the event that handle changes in properties 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int DocEntry
        {
            get { return _docEntry; }
            set { _docEntry = value; }
        }
        
        public int DocNo
        {
            get { return _docNo; }
            set { _docNo = value; }
        }

        public DateTime DocDate
        {
            get { return _docDate; }
            set { _docDate = value; }
        }

        public decimal Total
        {
            get 
            { 
                return _total; 
            }
        }

        public BindingList<PurchaseDetail> Details
        { 
           get
           {
                return _purchaseDetails;
           }
        }

        // Step 3 : Handle the event
        private void PurchaseDetailsChanged(object sender, ListChangedEventArgs e)
        {
            _total = 0;
            foreach (PurchaseDetail d in _purchaseDetails)
            {
                _total += d.LineTotal;
            }

            // Step 7 :  Notify event handler
            NotifyPropertyChanged("Total");     // Note that class' property is specified
        }

    }
}
