// See https://aka.ms/new-console-template for more information

// Zadanie 5
/*class KontoBankowe
{
    private double saldo;

    public void Wplata(double kwota)
    {
        saldo += kwota;
    }

    public double PobierzSaldo()
    {
        return saldo;
    }
    public void Wyplata(double kwota)
    {
        if (saldo >= kwota)
        {
            saldo -= kwota;
            Console.WriteLine($"Wyplacono: {kwota} zł");
            Console.WriteLine($"Na koncie pozostało: {saldo} zł");
        }
        else
        {
            Console.WriteLine($"Nie mozna ukonczyc operacji,\n Saldo to {saldo} zł");
        }
    }
}*/
// Zadanie 6
/*
Kot Filemons = new Kot();
Filemons.Miaucz();
Filemons.Jedz();

class Zwierze
{
    public void Jedz() => Console.WriteLine("Zwierze je");
}

class Pies : Zwierze
{
    public void Szczekaj() => Console.WriteLine("Hau Hau");
}

class Kot : Zwierze
{
    public void Miaucz() => Console.WriteLine("Miau Miau");
}
*/
// Zadanie 7 
/*
Pies pies = new Pies();
Kot kot = new Kot();
Krowa krowa = new Krowa();

Zwierze[] Zwierzeta =
{
pies,kot,krowa
};

foreach (var v in Zwierzeta)
{
    v.DajGlos();
}

class Zwierze
{
    public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
}
class Pies:Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Hau Hau");
    }
}
class Kot:Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Miau");
    }
}
class Krowa:Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Muu");
    }
}
*/
// Zadanie 8
/*
ElektrycznySamochod Tesla = new ElektrycznySamochod();
Tesla.Start();
Tesla.Jedz();
Tesla.Laduj();

class Pojazd
{
    public void Start() => Console.WriteLine("Pojazd uruchomiony");
}

class Samochod : Pojazd
{
    public void Jedz() => Console.WriteLine("Samochod jedzie");
}

class ElektrycznySamochod : Samochod
{
    public void Laduj() => Console.WriteLine("Ładowanie");
}
*/