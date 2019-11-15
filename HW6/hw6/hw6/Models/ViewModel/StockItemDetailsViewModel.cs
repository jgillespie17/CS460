using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace hw6.Models.ViewModel
{
    public class StockItemDetailsViewModel
    {
        public StockItemDetailsViewModel(StockItem stockItem)
        {
            //Stock Item details 
            StockItemName = stockItem.StockItemName;
            StockItemSize = stockItem.Size;
            StockItemPrice = stockItem.RecommendedRetailPrice;
            StockItemWeight = stockItem.TypicalWeightPerUnit;
            StockItemLeadTime = stockItem.LeadTimeDays;
            StockItemDate = stockItem.ValidFrom;
            JObject json = JObject.Parse(stockItem.CustomFields);
            StockItemOrigin = (string)json["CountryOfManufacture"];
            StockItemTags = stockItem.Tags.Trim('[', ']');
            StockItemPhoto = stockItem.Photo;

            //Stock item supplier details
            SupplierName = stockItem.Supplier.SupplierName;
            SupplierPhone = stockItem.Supplier.PhoneNumber;
            SupplierFax = stockItem.Supplier.FaxNumber;
            SupplierWebsite = stockItem.Supplier.WebsiteURL;
            SupplierContact = stockItem.Supplier.Person2.FullName;

            //Sales details
            SalesOrderNum = stockItem.OrderLines.Count();
            SalesGrossSales = stockItem.InvoiceLines.Sum(x => x.ExtendedPrice);
            SalesGrossProfit = stockItem.InvoiceLines.Sum(x => x.LineProfit);

            //Disgusting Linq
            Top10List = stockItem.InvoiceLines.GroupBy(y => y.Invoice.Customer.CustomerName).Select(x => (CustomerName: x.Key, Orders: x.Sum(z => z.Quantity))).OrderByDescending(x => x.Orders).Take(10);

        }
        //StockItem details
        [Display(Name = "Name: ")]
        public string StockItemName { get; set; }

        [Display(Name = "Size: ")]
        public string StockItemSize { get; set; }

        [Display(Name = "Price: ")]
        [DataType(DataType.Currency)]
        public decimal? StockItemPrice { get; set; }

        [Display(Name = "Weight: ")]
        public decimal StockItemWeight { get; set; }

        [Display(Name = "Lead Time: ")]
        public int StockItemLeadTime { get; set; }

        [Display(Name = "Valid from: ")]
        [DataType(DataType.Date)]
        public DateTime StockItemDate { get; set; }

        [Display(Name = "Origin: ")]
        public string StockItemOrigin { get; set; }

        [Display(Name = "Tags: ")]
        public string StockItemTags { get; set; }

        [Display(Name = "Photo: ")]
        public byte[] StockItemPhoto { get; set; }


        //Stock item supplier profile
        [Display(Name = "Company")]
        public string SupplierName { get; set; }

        [Display(Name = "Phone")]
        public string SupplierPhone { get; set; }

        [Display(Name = "Fax")]
        public string SupplierFax { get; set; }

        [Display(Name = "Website")]
        public string SupplierWebsite { get; set; }

        [Display(Name = "Contact")]
        public string SupplierContact { get; set; }

        //Sales History Summary
        [Display(Name = "Orders: ")]
        public int SalesOrderNum { get; set; }
        [Display(Name = "Gross Sales: ")]
        [DataType(DataType.Currency)]
        public decimal SalesGrossSales { get; set; }
        [Display(Name = "Gross Profit: ")]
        [DataType(DataType.Currency)]
        public decimal SalesGrossProfit { get; set; }

        //Gross list of gross stuff
        public IEnumerable<(string name, int quantity)> Top10List { get; set; }
    }
}