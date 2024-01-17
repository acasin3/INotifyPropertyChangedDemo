using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChangedNested
{
    public class SaleDetail : INotifyPropertyChanged
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

        internal SaleDetail(int itemId, string taxCode, decimal lineTotal)
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

        public decimal Tax
        {
            get
            {
                decimal tax = 0;
                switch (mstrTaxCode)
                {
                    case "PT":
                        tax = 0.03M * mdecGrossAmount;
                        break;
                    case "VT":
                        tax = 0.12M * mdecGrossAmount / (1.12M);
                        break;
                    case "ZR":
                        tax = 0;
                        break;
                }
                return tax;
            }
        }
    }
}
