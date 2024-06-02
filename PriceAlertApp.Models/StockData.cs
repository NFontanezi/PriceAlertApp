

using System.ComponentModel;

namespace PriceAlertApp.Models
{
    public class StockData
    {
        public string Symbol { get; set; }
        public List<DailyClose> DailyCloses { get; set; }

        public StockData()
        {
            DailyCloses = new List<DailyClose>();
        }
    }

    public class DailyClose
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }
}
