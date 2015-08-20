namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Weapon : Item
    {
        const int GeneralArmorValue = 10;
        // TODO IF NEEDED: fix location = null
        public Weapon(string name, Location location = null)
            : base(name, Weapon.GeneralArmorValue, ItemType.Weapon, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Weapon };
        }
    }
}
