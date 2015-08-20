using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private string material;
        private MaterialType materialType;
        private decimal height;

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 3)
                {
                    throw new IndexOutOfRangeException();
                }
                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.materialType.ToString();
            }
            protected set
            {
                switch (value.ToLower())
                {
                    case "leather": this.materialType = MaterialType.Leather; break;
                    case "plastic": this.materialType = MaterialType.Plastic; break;
                    case "wooden": this.materialType = MaterialType.Wooden; break;
                    default:
                        this.material = value;
                        break;
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.height = value;
            }
        }

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }
    }
}
