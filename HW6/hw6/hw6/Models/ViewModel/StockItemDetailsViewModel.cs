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
            StockItemName = stockItem.StockItemName;
            StockItemSize = stockItem.Size;
            StockItemPrice = stockItem.UnitPrice;
            StockItemWeight = stockItem.TypicalWeightPerUnit;
            StockItemLeadTime = stockItem.LeadTimeDays;
            StockItemDate = stockItem.ValidFrom;
            //var json = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(stockItem.CustomFields);
            JObject json = JObject.Parse(stockItem.CustomFields);
            StockItemOrigin = (string)json["CountryOfManufacture"];
            //StockItemTags = ;
            string pattern = @"^(\[){1}(.*?)(\]){1}$";
            StockItemTags = Regex.Replace(json["Tags"].ToString(), pattern, "");
            StockItemPhoto = stockItem.Photo;


        }
        [Display(Name = "Name: ")]
        public string StockItemName { get; set; }

        [Display(Name = "Size: ")]
        public string StockItemSize { get; set; }

        [Display(Name = "Price(in USD): ")]
        public decimal StockItemPrice { get; set; }

        [Display(Name = "Weight: ")]
        public decimal StockItemWeight { get; set; }

        [Display(Name = "Lead Time(in days): ")]
        public int StockItemLeadTime { get; set; }

        [Display(Name = "Valid from: ")]
        public DateTime StockItemDate { get; set; }

        [Display(Name = "Origin: ")]
        public string StockItemOrigin { get; set; }

        [Display(Name = "Tags: ")]
        public string StockItemTags { get; set; }

        [Display(Name = "Photo: ")]
        public byte[] StockItemPhoto { get; set; }
    }
}