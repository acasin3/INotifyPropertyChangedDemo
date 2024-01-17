using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotifyPropertyMasterDetailDemo
{
    public class PurchaseDetail : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.  
        private int mintItemID;
        private string mstrTaxCode;
        private decimal mdecGrossAmount;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal PurchaseDetail(int itemId, string taxCode, decimal lineTotal)
        {
            mintItemID = itemId;
            mstrTaxCode = taxCode;
            mdecGrossAmount = lineTotal;
        }

        public int ItemID
        {
            get
            {
                return this.mintItemID;
            }

            set
            {
                if (value != this.mintItemID)
                {
                    this.mintItemID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaxCode
        {
            get
            {
                return mstrTaxCode;
            }
        }

        public decimal GrossAmount
        {
            get
            {
                return mdecGrossAmount;
            }
            
            set
            {
                // Reject negative values
                if (value != mdecGrossAmount && value >= 0)
                {
                    mdecGrossAmount = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
