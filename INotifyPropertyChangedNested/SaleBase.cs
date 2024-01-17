using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChangedNested
{
    public class SaleBase : INotifyPropertyChanged // Step 4 : Implement the INotifyProperyChanged interface
    {
        protected int _docEntry;
        protected int _docNo;
        protected DateTime _docDate;
        protected decimal _total;
        // Step 1 : Add a module-level variable of type BindingList for the details
        protected BindingList<SaleDetail> _purchaseDetails = new BindingList<SaleDetail>();

        // Step 4 : Implement member of the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        public SaleBase() 
        {
            // Step 2 : Add a ListChanged event for the details
            _purchaseDetails.ListChanged += new ListChangedEventHandler(this.PurchaseDetailsChanged);
        }

        // Step 5 : Create the event that handle changes in properties 
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
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
            set
            { 
                _docNo = value; 
                NotifyPropertyChanged();
            }
        }

        public DateTime DocDate
        {
            get { return _docDate; }
            set 
            { 
                if (_docDate != value)
                {
                    _docDate = value;
                    if (value > DateTime.Today)
                    {
                        throw new ApplicationException("Date cannot be in the future");
                    }
                }
            }
        }

        public decimal Total
        {
            get 
            { 
                return _total; 
            }
        }

        public BindingList<SaleDetail> Details
        { 
           get
           {
                return _purchaseDetails;
           }
        }

        // Step 3 : Handle the event
        protected void PurchaseDetailsChanged(object sender, ListChangedEventArgs e)
        {
            _total = 0;
            foreach (SaleDetail d in _purchaseDetails)
            {
                _total += d.GrossAmount;
            }

            // Step 6 :  Notify event handler
            NotifyPropertyChanged("Total");     // Note that class' property is specified
        }

    }
}
