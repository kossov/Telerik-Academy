using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;
    
        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.numberOfLegs = value;
            }
        }

        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model,materialType,price,height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
