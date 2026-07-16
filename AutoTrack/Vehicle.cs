using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoTrack
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public double BaseCost { get; set; }

        protected Vehicle(int id, String model, double baseCost)
        {
            Id = id;
            Model = model;
            BaseCost = baseCost;
        }

        public abstract double CalculateOperatingCost();
    }
}
