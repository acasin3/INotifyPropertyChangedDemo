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
        private int _itemId;
        private decimal _lineTotal;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal PurchaseDetail(int itemId, decimal lineTotal)
        {
            _itemId = itemId;
            _lineTotal = lineTotal;
        }

        public int ItemId
        {
            get
            {
                return this._itemId;
            }

            set
            {
                if (value != this._itemId)
                {
                    this._itemId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal LineTotal
        {
            get
            {
                return _lineTotal;
            }
            set
            {
                // Reject negative values
                if (value != _lineTotal && value >= 0)
                {
                    _lineTotal = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
