using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrack
{
    public class ElectricVehicle : Vehicle
    {
        public double BatteryCapacity { get; set; }
        public double ElectricityRate { get; set; }

        public ElectricVehicle(int id, string model, double baseCost, double batteryCapacity, double electricityRate)
            : base(id, model, baseCost)
        {
            BatteryCapacity = batteryCapacity;
            ElectricityRate = electricityRate;
        }

        public override double CalculateOperatingCost()
        {
            return BaseCost + (BatteryCapacity * ElectricityRate);
        }
    }
}
