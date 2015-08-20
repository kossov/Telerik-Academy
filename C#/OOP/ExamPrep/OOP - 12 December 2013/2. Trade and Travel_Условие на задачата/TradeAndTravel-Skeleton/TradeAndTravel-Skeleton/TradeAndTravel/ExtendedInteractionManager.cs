namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }

        private void HandleGatherInteraction(string[] commandWords,Person actor)
        {
            List<Item> allActorItems = actor.ListInventory();
            foreach (var item in allActorItems)
            {
                if (actor.Location.LocationType == LocationType.Mine && item.ItemType == ItemType.Armor)
                {
                    this.AddToPerson(actor,(new Wood(commandWords[2])));
                    break;
                }
                else if (actor.Location.LocationType == LocationType.Forest && item.ItemType == ItemType.Weapon)
                {
                    this.AddToPerson(actor,new Iron(commandWords[2]));
                    break;
                }
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            List<Item> allActorItems = actor.ListInventory();
            bool haveWood = false;
            Wood tempWood = new Wood("");
            foreach (var item in allActorItems)
            {
                if (item.ItemType == ItemType.Wood)
                {
                    haveWood = true;
                    tempWood = (Wood)item;
                    this.RemoveFromPerson(actor,item);
                }
                if (item.ItemType == ItemType.Iron && commandWords[2] == "armor")
                {
                    this.AddToPerson(actor,new Armor(commandWords[3]));
                    this.RemoveFromPerson(actor,item);
                    break;
                }
                else if (haveWood && item.ItemType == ItemType.Iron && commandWords[2] == "weapon")
                {
                    this.AddToPerson(actor, new Weapon(commandWords[3]));
                    this.RemoveFromPerson(actor, item);
                }
            }
            if (!actor.ListInventory().Exists(x => x.Name == commandWords[3]) && haveWood == true)
            {
                this.AddToPerson(actor, tempWood);
            }
        }
    }
}
