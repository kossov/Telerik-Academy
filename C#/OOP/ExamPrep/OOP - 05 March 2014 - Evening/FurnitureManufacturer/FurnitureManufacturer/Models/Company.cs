using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (value.Any(x => !char.IsDigit(x)))
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.registrationNumber = value;
                }
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            private set
            {
                this.furnitures = value;
            }
        }

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            furnitures = new List<IFurniture>();
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException();
            }
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            IFurniture foundFurniture = null;

            if (string.IsNullOrWhiteSpace(model.Trim()))
            {
                throw new ArgumentNullException();
            }
            try
            {
                foundFurniture = this.furnitures.First(x => x.Model.ToLower() == model.ToLower());
            }
            catch (InvalidOperationException)
            {
                return foundFurniture;
            }
            return foundFurniture;
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("{0} - {1} - {2} {3}",
this.Name,
this.RegistrationNumber,
this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
this.Furnitures.Count != 1 ? "furnitures" : "furniture"
));
            if (this.Furnitures.Count > 0)
            {
                result.Append("\n");
                this.Furnitures = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();
            }
            result.Append(string.Join("\n", this.Furnitures));
            return result.ToString();
        }
    }
}
