// See https://aka.ms/new-console-template for more information
using ConsoleApp2.Veh;
using Newtonsoft.Json;
using ConsoleApp2.Repo;
List<Car> CarList = new List<Car>();
var path = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
var json = File.ReadAllText(path);
var data = JsonConvert.DeserializeObject<List<Car>>(json);

data ??= new List<Car>();
Car car1 = new Car("Tesla", "White", 2012);
data.Add(car1);
var jsonOut = JsonConvert.SerializeObject(data, Formatting.Indented);
File.WriteAllText(path,jsonOut);

var repo = new VehicleRepo();
Car car3 = new Car("Honda", "Black", 1999);
Car car2 = new Car("Fiat", "Blue", 2002);


bool continueApp = true;
do
{   
    Console.WriteLine("Wybierz opcje:");
    Console.WriteLine("1.Pokaż listę pojazdów");
    Console.WriteLine("2.Dodaj pojazd");
    Console.WriteLine("3.Usuń pojazd");
    Console.WriteLine("4.Zmień kolor");
    Console.WriteLine("0.Exit");
    var option = Console.ReadKey().KeyChar;
    
    switch (option)
    {
        case '1':

            repo.ReadList();
            break;
        case '2':
            
            repo.AddVehicle();
            break;
        case '3':
            
            repo.RemoveVehicle();
            break;
        case '4':
            repo.ChangeVehicleColor();
            break;
        case '0':
            continueApp = false;
            break;
        default:
        {
            Console.WriteLine("unkown option");
        }
            break;
    }
}
while (continueApp);





