using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardesktop
{
    
    internal class Statisztika
    {
       private List<Car> cars;
        public Statisztika()
        {
            try
            {
                cars= new List<Car>();
                ReadAllCar();
                CheaperThan20k();
                MoreExpensiveThan26();
                MostExpensiveCar();
                GroupByBrand();
                DailyCostFromPlate();
            }catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DailyCostFromPlate()
        {
            Console.WriteLine("Adjon meg egy rendszámot");
           string licensePlate = Console.ReadLine();
            var car=cars.FirstOrDefault(car=>car.License_plate_number.Equals(licensePlate,StringComparison.OrdinalIgnoreCase));
            if (car != null)
            {
                if (car.Daily_cost > 25000)
                {
                    Console.WriteLine( "nagyobb mint 25k");
                }
                else
                {
                    Console.WriteLine("kisebb");
                }
            }
            else { Console.WriteLine( "nincs ilyen autó"); }
        }

        private void GroupByBrand()
        {
            var groupByBrand=cars.GroupBy(car=>car.Brand).Select(group=> new {Brand=group.Key,Count =group.Count()});
            Console.WriteLine("Autók márka szerint:");
            foreach(var item in groupByBrand)
            {
                Console.WriteLine(item.Brand+":"+item.Count);
            }
        }

        private void MostExpensiveCar()
        {
            var mostExpensiveCar=cars.OrderByDescending(car=>car.Daily_cost).FirstOrDefault();
            Console.WriteLine($"Legdrágább autó:{mostExpensiveCar.License_plate_number}-{mostExpensiveCar.Brand}-{mostExpensiveCar.Brand}-{mostExpensiveCar.Daily_cost}");
        }

        private void MoreExpensiveThan26()
        {
            bool moreExpensiveThan26 = cars.Any(car => car.Daily_cost > 26000);
            Console.WriteLine(moreExpensiveThan26? "Van 26000-ft-nál drágább" : "Nincs 26000-ft-nál drágább");
        }

        private void CheaperThan20k()
        {
            int cheaperThan20k = cars.Count(car => car.Daily_cost < 20000);
            Console.WriteLine("20.000 Ft-nál olcsóbb napidíjú autók száma:{0}",cheaperThan20k);
        }

        private void ReadAllCar()
        {
           CarService carService = new CarService();
            cars=carService.GetCars();

        }
    }
}
