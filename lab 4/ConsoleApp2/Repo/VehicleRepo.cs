namespace ConsoleApp2.Repo;
using ConsoleApp2.Veh;
using Microsoft.EntityFrameworkCore;


public class VehicleRepo
{ 
    List<Vehicle> VehicleList = new List<Vehicle>();
   
   
   
   public void AddVehicle()
   {
       Console.WriteLine("Model pojazdu: ");
       string model = Console.ReadLine();
       Console.WriteLine("Kolor pojazdu: ");
       string color = Console.ReadLine();
       Console.WriteLine("Rok produkcji: ");
       int year = int.TryParse(Console.ReadLine(), out int result) ? result : 0000;
       Car car = new Car(model, color, year);
       VehicleList.Add(car);
   }
    
   public void RemoveVehicle()
   {
   
       Console.WriteLine("Podaj ID pojazdu");
       int id = int.TryParse(Console.ReadLine(), out int result)? result : 0;
       for (int i = 0; i < VehicleList.Count; i++)
       {
           if (VehicleList[i].Id == id)
           {
               VehicleList.RemoveAt(i);
           }
       }
   }
    
   public void ChangeVehicleColor()
   {
       Console.WriteLine("Podaj ID pojazdu, którego kolor chcesz zmienić");
       int id = int.TryParse(Console.ReadLine(), out int result)? result : 0;
       Console.WriteLine("Podaj nowy kolor");
       string color = Console.ReadLine();
       for (int i = 0; i < VehicleList.Count; i++)
       {
           if (VehicleList[i].Id == id)
           {
               if (VehicleList[i].Color == color)
               {
                   Console.WriteLine("Pojazd posiada obecnie wybrany kolor");
                   break;
               }
               else
               {
                   VehicleList[i].Color = color;
               }
               break;
           }
       }
   }

   public void ReadList()
   {
       foreach (var v in VehicleList)
       {
           v.ShowInfo();
       }
   }
}
