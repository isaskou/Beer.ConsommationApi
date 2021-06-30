using Beer.servicesAPI;
using Bier.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bier.ConsommationAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DrinkRepository repo = new DrinkRepository();
            IEnumerable<Drink> drinks = repo.GetAll();
            foreach (Drink drink in drinks)
            {
                Console.WriteLine(drink.Name);
            }

            Console.WriteLine("********************");

            //Drink insertDrink = new Drink()
            //{
            //    Name = "Chimay",
            //    AlcoholIntensity = 8,
            //    Color = DrinkColors.Brown,
            //    Type = DrinkTypes.Trappist,
            //    BrewerId = 1
            //};
            //insertDrink = repo.Insert(insertDrink);

            //Console.WriteLine($"nouvelle bière : {insertDrink.Id}");

            //DrinkRepository repo2 = new DrinkRepository();
            //IEnumerable<Drink> drinksAll = repo.GetAll();
            //foreach (Drink drink in drinks)
            //{
            //    Console.WriteLine(drink.Name);
            //}


        }
    }
}
