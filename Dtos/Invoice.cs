using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class Invoice
    {
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string BillingType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public TRansactionType TRansactionType { get; set; }

        public int Amount { get; set; }
    }
}
