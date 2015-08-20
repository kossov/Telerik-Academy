namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Merchant : Person,ITraveller,IShopkeeper
    {
        public Merchant(string name, Location location) : base(name, location) { }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }

        public int CalculateSellingPrice(Item item)
        {
            return item.Value;
        }

        public int CalculateBuyingPrice(Item item)
        {
            return item.Value/2;
        }
    }
}
