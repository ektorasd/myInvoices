using System;
using System.Collections.Generic;

namespace myInvoices
{
    public class SimpleInvoicesGenerator
    {
        public SimpleInvoice GetSimpleInvoice()
        {
            return new SimpleInvoice()
            {
                SupplierUID = Guid.NewGuid(), //this should be kept on the client database as a unique reference for the invoice
                DocumentTypeDescription = "Τιμολόγιο δελτίο αποστολής", //this is mandatory as invoice title
                IssuerVat = "936119573",
                IssuerName = "Orian SA",
                IssuerAddress = "Λ. Συγγρου 151",
                IssuerCityName = "Νέα Σμύρνη",
                IssuerPostalCode = "17121",
                AadeCategory = "1.1",
                Series = "A",
                InvoiceNumber = 1,
                InvoiceDate = DateTime.Now.Date,
                CustomerVat = "026883248",
                CustomerName = "TEST CUSTOMER",
                CustomerAddress = "Λ. Συγγρου 152",
                CustomerCityName = "Νέα Σμύρνη",
                CustomerPostalCode = "17121",
                CustomerCountry = "GR",
                CustomerEmail = "myinvoices@orian.gr",
                DeliveryDate = DateTime.Now.Date,
                DeliveryAddress = "Λ. Συγγρου 152",
                DeliveryCityName = "Νέα Σμύρνη",
                DeliveryPostalCode = "17121",
                DeliveryCountry = "GR",
                CreditTerms = "30 ημέρες",
                Lines = new List<SimpleInvoiceLine>()
                {
                    new SimpleInvoiceLine()
                    {
                        LineID = 1,
                        Description = "Software",
                        CpvCode = "03100000",
                        VatPercent = 24,
                        VatCategory = 1,
                        UnitPrice = 100,
                        Quantity = 1,
                        NetAmount = 100,
                        VatAmount = 24,
                        ClassificationType = "E3_561_001",
                        ClassificationCategory = "category1_1"
                    }
                }
            };
        }
    }
}
