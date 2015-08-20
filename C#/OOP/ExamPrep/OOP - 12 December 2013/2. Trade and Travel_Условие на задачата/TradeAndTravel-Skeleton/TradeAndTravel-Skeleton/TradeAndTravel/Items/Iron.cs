namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Iron : Item
    {
        const int GeneralArmorValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.GeneralArmorValue, ItemType.Iron, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron };
        }
    }
}
