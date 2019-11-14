using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw6.Models.ViewModel
{
    public class StockItemDetailsViewModel
    {
        public StockItemDetailsViewModel(StockItem stockItem)
        {

        }

        public string StockItemName { get; set; }

        public string StockItemSize { get; set; }
    }
}