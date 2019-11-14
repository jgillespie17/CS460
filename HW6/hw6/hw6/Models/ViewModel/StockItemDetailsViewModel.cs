using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            StockItemTags = json["Tags"].ToString();
            StockItemPhoto = stockItem.Photo;


        }

        public string StockItemName { get; set; }

        public string StockItemSize { get; set; }

        public decimal StockItemPrice { get; set; }

        public decimal StockItemWeight { get; set; }

        public int StockItemLeadTime { get; set; }

        public DateTime StockItemDate { get; set; }

        public string StockItemOrigin { get; set; }

        public string StockItemTags { get; set; }

        public byte[] StockItemPhoto { get; set; }
    }
}