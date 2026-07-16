using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrack
{
    public class GasVehicle : Vehicle
    {
        public double FuelEfficiency { get; set; }
        public double FuelCostPerLiter { get; set; }

        public GasVehicle(int id, string model, double baseCost, double fuelEfficiency, double fuelCostPerLiter)
            : base(id, model, baseCost)
        {
            FuelEfficiency = fuelEfficiency;
            FuelCostPerLiter = fuelCostPerLiter;
        }
        public override double CalculateOperatingCost()
        {
            return BaseCost + ((100 / FuelEfficiency) * FuelCostPerLiter);
        }
    }
}
