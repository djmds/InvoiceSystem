using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class InvoiceInputModel
    {
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
        public BillingType BillingType { get; set; }
        public PhaseType PhaseTyep { get; set; }
    }

    public interface IInvoice
    {
        Invoice GetInvoice(InvoiceInputModel invoiceInputModel);
    }

    public class InvoceService : IInvoice
    {
        private readonly IProvider _Provider;
        public InvoceService(IProvider provider)
        {
            _Provider = provider;
        }
        public Invoice GetInvoice(InvoiceInputModel invoiceInputModel)
        {

            Project project = null;
            if (invoiceInputModel.BillingType == BillingType.TimeBased)
            {
                project = new TimeBasedProject(invoiceInputModel.ProjectId, "abc");
            }
            else if (invoiceInputModel.BillingType == BillingType.MilestoneBased)
            {
                project = new MileStoneBasedProject(invoiceInputModel.ProjectId, "xyz", _Provider.GetMilstone(invoiceInputModel.PhaseTyep));
            }

            return new Invoice
            {
                Amount = project.GetInvoiceAmount(),
                CustomerName = "Techrangers",
                InvoiceDate = DateTime.UtcNow
            };
        }
    }
}
