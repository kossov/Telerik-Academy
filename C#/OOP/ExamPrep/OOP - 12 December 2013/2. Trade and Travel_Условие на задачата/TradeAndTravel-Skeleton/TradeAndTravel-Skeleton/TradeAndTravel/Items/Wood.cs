namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wood : Item
    {
        const int GeneralArmorValue = 2;
        // TODO IF NEEDED: fix location = null
        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralArmorValue, ItemType.Wood, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Wood };
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value -= 1;
            }
        }
    }
}
