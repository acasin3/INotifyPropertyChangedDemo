using System;

namespace NotifyPropertyChangedNested
{
    public class VATSale : Sale
    {
        public VATSale(int docEntry, int docNo, DateTime docDate) 
        {
            base.DocEntry = docEntry;
            base.DocNo = docNo;
            base.DocDate = docDate;
        }
    }
}
