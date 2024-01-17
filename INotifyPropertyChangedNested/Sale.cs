using System;
using System.ComponentModel;

namespace NotifyPropertyChangedNested
{
    public class Sale : SaleBase
    {
        
        public Sale() 
        {
            // Step 1 : Handle the event
            //base._purchaseDetails.ListChanged += new ListChangedEventHandler(this.PurchaseDetailsChanged);
        }
    }
}
