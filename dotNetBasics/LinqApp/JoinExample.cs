using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqApp
{
    class Car
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }

    class Company
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    static class JoinExample
    {
        public static void Run()
        {
            var cars = GetCars();
            var companies = GetCompanies();

            var result = from car in cars
                         join company in companies on car.Company equals company.Name
                         select new { Car = car.Name, Company = car.Company, Country = company.Country };
            // То же самое
            result = cars.Join(companies, car => car.Company, company => company.Name,
                (car, company) => new { Car = car.Name, Company = car.Company, Country = company.Country });
            foreach ( var item in result)
            {
                Console.WriteLine($"Model: {item.Car}; Company: {item.Company}; Country: {item.Country}");
            }
            Console.WriteLine();
            var groupResult = companies.GroupJoin(cars, company => company.Name, car => car.Company,
                (company, crs) => new { Company = company.Name, Country = company.Country, Cars = crs.Select(car => car.Name) });
            foreach (var company in groupResult )
            {
                Console.WriteLine(company.Company);
                foreach (var car in company.Cars)
                {
                    Console.WriteLine(car);
                }
                Console.WriteLine();
            }
        } 

        public static Car[] GetCars() => new Car[]
        {
            new Car {Name="Corolla", Company="Toyota"},
            new Car {Name="X-trail", Company="Nissan"},
            new Car {Name="Camry", Company="Toyota"},
            new Car {Name="Skyline", Company="Nissan"},
            new Car {Name="M5", Company="BMW"}
        };

        public static Company[] GetCompanies() => new Company[]
        {
            new Company{Name="Toyota", Country="Japan"},
            new Company{Name="Nissan", Country="Japan"},
            new Company{Name="BMW", Country="Germany"}
        };
    }
}
