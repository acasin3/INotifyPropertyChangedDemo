using System;

namespace NotifyPropertyChangedNested
{
    public class PercentageTaxSale : Sale
    {
        public PercentageTaxSale(int docEntry, int docNo, DateTime docDate) 
        {
            base.DocEntry = docEntry;
            base.DocNo = docNo;
            base.DocDate = docDate;
        }
    }
}
