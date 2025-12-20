// See https://aka.ms/new-console-template for more information
using Lab3.Models;


var continueAPP = true;
do
{
    Console.WriteLine("Wybierz opcje menu");
    Console.WriteLine("1.Wyświetl liste pojazdow");
    Console.WriteLine("2.Dodaj pojazd");
    Console.WriteLine("3.Usuń pojazd");
    Console.WriteLine("0.Exit");
    var vehicleList = new list<Vehicle>
    {
        car1 = new Car(2025,"honda","czarny"),
        car2 = new Car(2025,"honda","czarny")
    };
    var option = Console.ReadKey().KeyChar;

    switch (option)
    {
        case '1':
            for (int i = 0; i < vehicleList.Count; i++)
            {
                Console.Write("ID: {0}",i);
                vehicleList[i].ShowInfo();
            }
            break;
        case '2':
            AddCar();
            break;
        case '3':
            RemoveCar();
            break;
        case '0':
            continueAPP = false;
            break;
        default:
            Console.WriteLine("Nieznana opcja");
            break;
    }
    
    
} while (continueAPP);

void AddCar()
{
    Console.WriteLine("Podaj model");
    var model = Console.ReadLine();
    Console.WriteLine("Podaj rok produkcji");
    var success = int.TryParse(Console.ReadLine(), out int year);
    if (!success || model == null)
    {
        Console.WriteLine("Niepoprawne dane");
        return;
    }
    Console.WriteLine("Podaj kolor");
    var color = Console.ReadLine();
    vehicleList.Add(new Car(year, model, color));
    
}

void RemoveCar()
{
    
}