using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myInvoices
{
    public class SendInvoiceExample
    {
        public async Task SendInvoiceToYpahes(string userName, string password,bool isTest)
        {
            var client = new Client(isTest);
            var token = await client.LoginAsync(userName, password);
            var eInvoice = CreateSampleInvoice();
            await client.SendInvoiceToYpahesAsync(eInvoice);
        }

        private EInvoiceBody CreateSampleInvoice()
        {
            var eInvoice = new EInvoiceBody();
            var simpleInvoice = new SimpleInvoicesGenerator().GetSimpleInvoice();
            var sbd = GetStandardBusinessDocument(simpleInvoice);
            eInvoice.Data = Utils.PrepareInvoiceDataXML(sbd);
            return eInvoice;
        }

        private StandardBusinessDocument GetStandardBusinessDocument(SimpleInvoice simpleInvoice)
        {
            var res = new StandardBusinessDocument();
            res.Invoice = new InvoiceType[] { CreatePeppolInvoice(simpleInvoice) };
            res.InvoicesDoc = CreateMyDataContents(simpleInvoice);
            return res;
        }

        private MyDATA.InvoicesDoc CreateMyDataContents(SimpleInvoice simpleInvoice)
        {
            var res = new MyDATA.InvoicesDoc();
            res.invoice = new MyDATA.AadeBookInvoiceType[]
            {
                new MyDATA.AadeBookInvoiceType()
                {
                    issuer = new MyDATA.PartyType()
                    {
                        vatNumber = simpleInvoice.IssuerVat,
                        country = (MyDATA.CountryType)
                            System.Enum.Parse(typeof(MyDATA.CountryType), "GR"),
                        branch = 0
                    },
                    counterpart = new MyDATA.PartyType()
                    {
                        vatNumber = simpleInvoice.CustomerVat,
                        country = (MyDATA.CountryType)
                            System.Enum.Parse(typeof(MyDATA.CountryType), "GR"),
                        branch = 0
                    },
                    invoiceHeader = new MyDATA.InvoiceHeaderType()
                    {
                        invoiceType = Utils.GetCode<MyDATA.InvoiceType>(simpleInvoice.AadeCategory),
                        series = simpleInvoice.Series,
                        aa = simpleInvoice.InvoiceNumber.ToString(),
                        issueDate = simpleInvoice.InvoiceDate,
                        currency = MyDATA.CurrencyType.EUR,
                        currencySpecified = true
                    },
                    paymentMethods = new MyDATA.PaymentMethodDetailType[]
                    {
                        new MyDATA.PaymentMethodDetailType()
                        {
                            type = 5,
                            amount = simpleInvoice.Lines.Sum(x => x.NetAmount + x.VatAmount)
                        }
                    },
                    invoiceSummary = new MyDATA.InvoiceSummaryType()
                    {
                        totalNetValue = simpleInvoice.Lines.Sum(x => x.NetAmount),
                        totalVatAmount = simpleInvoice.Lines.Sum(x => x.VatAmount),
                        totalGrossValue = simpleInvoice.Lines.Sum(x => x.NetAmount + x.VatAmount)
                    }
                }
            };
            var lines = new List<MyDATA.InvoiceRowType>();
            foreach (var line in simpleInvoice.Lines)
            {
                var myDataLine = new MyDATA.InvoiceRowType()
                {
                    lineNumber = line.LineID,
                    vatCategory = line.VatCategory,
                    vatAmount = line.VatAmount,
                    netValue = line.NetAmount,
                    incomeClassification = new MyDATA.IncomeClassificationType[]
                    {
                        new MyDATA.IncomeClassificationType()
                        {
                            classificationCategory = (MyDATA.IncomeClassificationCategoryType)
                                System.Enum.Parse(
                                    typeof(MyDATA.IncomeClassificationCategoryType),
                                    line.ClassificationCategory
                                ),
                            classificationType = (MyDATA.IncomeClassificationValueType)
                                System.Enum.Parse(
                                    typeof(MyDATA.IncomeClassificationValueType),
                                    line.ClassificationType
                                ),
                            amount = line.NetAmount
                        }
                    }
                };
                lines.Add(myDataLine);
            }
            res.invoice[0].invoiceDetails = lines.ToArray();
            res.invoice[0].invoiceSummary = new MyDATA.InvoiceSummaryType()
            {
                totalNetValue = simpleInvoice.Lines.Sum(x => x.NetAmount),
                totalVatAmount = simpleInvoice.Lines.Sum(x => x.VatAmount),
                totalGrossValue = simpleInvoice.Lines.Sum(x => x.NetAmount + x.VatAmount)
            };
            var incomesClassificationList = res
                .invoice.First()
                .invoiceDetails.SelectMany(s => s.incomeClassification)
                .GroupBy(l =>
                    (
                        classificationCategory: l.classificationCategory,
                        classificationType: l.classificationType
                    )
                )
                .Select(x => new MyDATA.IncomeClassificationType
                {
                    classificationCategory = x.Key.classificationCategory,
                    classificationType = x.Key.classificationType,
                    amount = x.Sum(s => s.amount)
                })
                .ToList();
            res.invoice[0].invoiceSummary.incomeClassification =
                incomesClassificationList.ToArray();
            return res;
        }

        private InvoiceType CreatePeppolInvoice(SimpleInvoice simpleInvoice)
        {
            var res = new InvoiceType();
            res.CustomizationID = new CustomizationIDType()
            {
                Value =
                    @"urn:cen.eu:en16931:2017#compliant#urn:fdc:peppol.eu:2017:poacc:billing:3.0"
            }; //fixed
            res.ProfileID = new ProfileIDType()
            {
                Value = "urn:fdc:peppol.eu:2017:poacc:billing:01:1.0"
            }; //fixed
            res.ID = new IDType()
            {
                Value =
                    $"{simpleInvoice.IssuerVat}|{simpleInvoice.InvoiceDate.ToString(@"dd\/MM\/yyyy")}|0|{simpleInvoice.AadeCategory}|{simpleInvoice.Series}|{simpleInvoice.InvoiceNumber}"
            };
            res.IssueDate = new IssueDateType() { Value = simpleInvoice.InvoiceDate };
            res.InvoiceTypeCode = new InvoiceTypeCodeType() { Value = "380" };
            res.DocumentCurrencyCode = new DocumentCurrencyCodeType
            {
                listID = @"ISO 4217 Alpha",
                listURI =
                    @"http://docs.oasis-open.org/ubl/os-UBL-2.1/cl/gc/default/CurrencyCode-2.1.gc",
                Value = "EUR"
            };
            res.BuyerReference = new BuyerReferenceType
            {
                Value = $"{simpleInvoice.Series}.{simpleInvoice.InvoiceNumber}"
            };
            res.AdditionalDocumentReference = new DocumentReferenceType[]
            {
                new DocumentReferenceType
                {
                    ID = new IDType { Value = simpleInvoice.SupplierUID.ToString() },
                    DocumentDescription = new DocumentDescriptionType[]
                    {
                        new DocumentDescriptionType { Value = "SupplierUID" } //mandatory , unique identifier for the invoice
                    }
                },
                new DocumentReferenceType
                {
                    ID = new IDType { Value = simpleInvoice.DocumentTypeDescription.ToString() },
                    DocumentDescription = new DocumentDescriptionType[]
                    {
                        new DocumentDescriptionType { Value = "DocumentTypeDescription" } //mandatory , printed title of the invoice
                    }
                },
            };
            res.AccountingSupplierParty = new SupplierPartyType
            {
                Party = new PartyType
                {
                    EndpointID = new EndpointIDType { Value = "099876810", schemeID = "9933" }, //fixed:endpoint παρόχου για λήψη απάντησης
                    PartyName = new PartyNameType[]
                    {
                        new PartyNameType()
                        {
                            Name = new NameType1 { Value = simpleInvoice.IssuerName }
                        }
                    },
                    PostalAddress = new AddressType
                    {
                        StreetName = new StreetNameType { Value = simpleInvoice.IssuerAddress },
                        CityName = new CityNameType { Value = simpleInvoice.IssuerCityName },
                        PostalZone = new PostalZoneType { Value = simpleInvoice.IssuerPostalCode },
                        Country = new CountryType
                        {
                            IdentificationCode = new IdentificationCodeType { Value = "GR" }
                        }
                    },
                    PartyTaxScheme = new PartyTaxSchemeType[]
                    {
                        new PartyTaxSchemeType
                        {
                            CompanyID = new CompanyIDType
                            {
                                Value = $"EL{simpleInvoice.IssuerVat}"
                            },
                            TaxScheme = new TaxSchemeType { ID = new IDType { Value = "VAT" } }
                        }
                    },
                    PartyLegalEntity = new PartyLegalEntityType[]
                    {
                        new PartyLegalEntityType
                        {
                            RegistrationName = new RegistrationNameType
                            {
                                Value = simpleInvoice.IssuerName
                            }
                        }
                    }
                }
            };
            res.AccountingCustomerParty = new CustomerPartyType
            {
                Party = new PartyType
                {
                    EndpointID = new EndpointIDType
                    {
                        Value = simpleInvoice.CustomerVat,
                        schemeID = "9933"
                    }, //shemeID for Greek customers
                    PartyName = new PartyNameType[]
                    {
                        new PartyNameType()
                        {
                            Name = new NameType1 { Value = simpleInvoice.CustomerName }
                        }
                    },
                    PostalAddress = new AddressType
                    {
                        StreetName = new StreetNameType { Value = simpleInvoice.CustomerAddress },
                        CityName = new CityNameType { Value = simpleInvoice.CustomerCityName },
                        PostalZone = new PostalZoneType
                        {
                            Value = simpleInvoice.CustomerPostalCode
                        },
                        Country = new CountryType
                        {
                            IdentificationCode = new IdentificationCodeType
                            {
                                Value = simpleInvoice.CustomerCountry
                            }
                        }
                    },
                    PartyTaxScheme = new PartyTaxSchemeType[]
                    {
                        new PartyTaxSchemeType
                        {
                            CompanyID = new CompanyIDType
                            {
                                Value = $"EL{simpleInvoice.CustomerVat}"
                            },
                            TaxScheme = new TaxSchemeType { ID = new IDType { Value = "VAT" } }
                        }
                    },
                    PartyLegalEntity = new PartyLegalEntityType[]
                    {
                        new PartyLegalEntityType
                        {
                            RegistrationName = new RegistrationNameType
                            {
                                Value = simpleInvoice.CustomerName
                            },
                            CompanyID = new CompanyIDType { Value = simpleInvoice.CustomerVat }
                        }
                    },
                    Contact = new ContactType
                    {
                        ElectronicMail = new ElectronicMailType
                        {
                            Value = simpleInvoice.CustomerEmail
                        }
                    }
                }
            };
            res.Delivery = new DeliveryType[]
            {
                new DeliveryType()
                {
                    ActualDeliveryDate = new ActualDeliveryDateType
                    {
                        Value = simpleInvoice.DeliveryDate
                    },
                    DeliveryLocation = new LocationType1
                    {
                        Address = new AddressType
                        {
                            StreetName = new StreetNameType
                            {
                                Value = simpleInvoice.DeliveryAddress
                            },
                            CityName = new CityNameType { Value = simpleInvoice.DeliveryCityName },
                            PostalZone = new PostalZoneType
                            {
                                Value = simpleInvoice.DeliveryPostalCode
                            },
                            Country = new CountryType
                            {
                                IdentificationCode = new IdentificationCodeType
                                {
                                    Value = simpleInvoice.DeliveryCountry
                                }
                            }
                        }
                    }
                }
            };
            res.PaymentTerms = new PaymentTermsType[]
            {
                new PaymentTermsType
                {
                    Note = new NoteType[] { new NoteType { Value = simpleInvoice.CreditTerms } }
                }
            };

            var pepolLines = new List<InvoiceLineType>();
            foreach (var line in simpleInvoice.Lines)
            {
                var peppolLine = new InvoiceLineType();
                pepolLines.Add(peppolLine);
                peppolLine.ID = new IDType { Value = line.LineID.ToString() };
                peppolLine.InvoicedQuantity = new InvoicedQuantityType
                {
                    Value = line.Quantity,
                    unitCode = "H87"
                }; //H87 is the unit code for "piece"
                peppolLine.LineExtensionAmount = new LineExtensionAmountType
                {
                    Value = line.NetAmount,
                    currencyID = "EUR"
                };
                peppolLine.Item = new ItemType
                {
                    Name = new NameType1 { Value = line.Description },
                    CommodityClassification = new CommodityClassificationType[]
                    {
                        new CommodityClassificationType
                        {
                            ItemClassificationCode = new ItemClassificationCodeType
                            {
                                listID = "STI",
                                Value = line.CpvCode
                            }
                        }
                    },
                    ClassifiedTaxCategory = new TaxCategoryType[]
                    {
                        new TaxCategoryType
                        {
                            Percent = new PercentType1 { Value = line.VatPercent },
                            ID = new IDType { Value = line.PeppolVatClassification },
                            TaxScheme = new TaxSchemeType { ID = new IDType { Value = "VAT" } }
                        }
                    }
                };
                peppolLine.Price = new PriceType
                {
                    PriceAmount = new PriceAmountType
                    {
                        Value = line.UnitPrice,
                        currencyID = "EUR"
                    },
                    BaseQuantity = new BaseQuantityType { Value = line.Quantity }
                };
            }
            res.InvoiceLine = pepolLines.ToArray();
            res.LegalMonetaryTotal = new MonetaryTotalType
            {
                LineExtensionAmount = new LineExtensionAmountType
                {
                    Value = simpleInvoice.Lines.Sum(x => x.NetAmount),
                    currencyID = "EUR"
                },
                TaxExclusiveAmount = new TaxExclusiveAmountType
                {
                    Value = simpleInvoice.Lines.Sum(x => x.NetAmount),
                    currencyID = "EUR"
                },
                TaxInclusiveAmount = new TaxInclusiveAmountType
                {
                    Value = simpleInvoice.Lines.Sum(x => x.NetAmount + x.VatAmount),
                    currencyID = "EUR"
                },
                PayableAmount = new PayableAmountType
                {
                    Value = simpleInvoice.Lines.Sum(x => x.NetAmount + x.VatAmount),
                    currencyID = "EUR"
                }
            };
            res.TaxTotal = new TaxTotalType[]
            {
                new TaxTotalType()
                {
                    TaxAmount = new TaxAmountType
                    {
                        Value = simpleInvoice.Lines.Sum(x => x.VatAmount),
                        currencyID = "EUR"
                    },
                }
            };
            var taxSubTotals = new List<TaxSubtotalType>();
            var lineVatTotals = simpleInvoice
                .Lines.GroupBy(x =>
                    (Percent: x.VatPercent, PeppolVatClassification: x.PeppolVatClassification)
                )
                .Select(x =>
                    (
                        VatPercent: x.Key.Percent,
                        PeppolClassification: x.Key.PeppolVatClassification,
                        NetAmount: x.Sum(s => s.NetAmount),
                        VatAmount: x.Sum(s => s.VatAmount)
                    )
                )
                .ToList();
            foreach (var vatTotal in lineVatTotals)
                taxSubTotals.Add(
                    new TaxSubtotalType()
                    {
                        TaxableAmount = new TaxableAmountType()
                        {
                            Value = vatTotal.NetAmount,
                            currencyID = "EUR"
                        },
                        TaxAmount = new TaxAmountType()
                        {
                            Value = vatTotal.VatAmount,
                            currencyID = "EUR"
                        },
                        TaxCategory = new TaxCategoryType()
                        {
                            Percent = new PercentType1 { Value = vatTotal.VatPercent },
                            ID = new IDType { Value = vatTotal.PeppolClassification },
                            TaxScheme = new TaxSchemeType { ID = new IDType { Value = "VAT" } }
                        }
                    }
                );
            res.TaxTotal[0].TaxSubtotal = taxSubTotals.ToArray();
            return res;
        }
    }
}
