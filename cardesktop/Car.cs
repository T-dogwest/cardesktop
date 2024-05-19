using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardesktop
{
    internal class Car
    {
        public Car(int id, string license_plate_number, string brand, string model, int daily_cost)
        {
            Id = id;
            License_plate_number = license_plate_number;
            Brand = brand;
            Model = model;
            Daily_cost = daily_cost;
        }

        public int Id {  get; set; }
        public string License_plate_number { get; set; }
        public string Brand {  get; set; }
        public string Model {  get; set; }
        public int Daily_cost {  get; set; }
    }
}
