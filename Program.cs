using System;
using System.Collections.Generic;
using Dealership.Models;

namespace Dealership
{
  public class Program
  {
    public static Car volkswagen = new Car("1974 Volkswagen Thing", 1100, 368792);
    public static Car yugo = new Car("1980 Yugo Koral", 700, 56000);
    public static Car ford = new Car("1988 Ford Country Squire", 1400, 239001);
    public static Car amc = new Car("1976 AMC Pacer", 400, 198000);

    public static List<Car> Cars = new List<Car>() { volkswagen, yugo, ford, amc };

    public static void Main()
    {
      yugo.Price = 500;

      Console.WriteLine("Would you like to list a car for sale? (Y for yes, enter for no)");
      string answer = Console.ReadLine();
      if (answer == "y" || answer == "Y")
      {
        AddCar();
      }
      else
      {
        Console.WriteLine("Enter maximum price: ");
        string stringMaxPrice = Console.ReadLine();
        int maxPrice = int.Parse(stringMaxPrice);

        List<Car> CarsMatchingSearch = new List<Car>(0);

        foreach (Car automobile in Cars)
        {
          if (automobile.WorthBuying(maxPrice))
          {
            CarsMatchingSearch.Add(automobile);
          }
        }

        foreach(Car automobile in CarsMatchingSearch)
        {
          Console.WriteLine("----------------------");
          Console.WriteLine(automobile.MakeModel);
          Console.WriteLine(automobile.Miles + " miles");
          Console.WriteLine("$" + automobile.Price);
        }
      }
    }

    static void AddCar()
    {
      Console.WriteLine("NEW (used) CAR");
      Console.WriteLine("Enter the car's make/model:");
      string newMakeModel = Console.ReadLine();
      if (Cars.Exists(x => x.MakeModel == newMakeModel))
      {
        Console.WriteLine("That make and model is already in stock, we don't need another.");
      }
      else
      {
        Console.WriteLine("Enter the car's sell price:");
        string newPriceString = Console.ReadLine();
        int newPrice = int.Parse(newPriceString);
        Console.WriteLine("Enter the car's mileage:");
        string newMilesString = Console.ReadLine();
        int newMiles = int.Parse(newMilesString);
        Car newCar = new Car(newMakeModel, newPrice, newMiles);
        Cars.Add(newCar);
      }
      Main();
    }
  }  
}