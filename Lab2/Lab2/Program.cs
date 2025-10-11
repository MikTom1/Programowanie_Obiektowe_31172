// See https://aka.ms/new-console-template for more information

Osoba osoba1 = new Osoba("Marek",18);
Osoba osoba2 = new Osoba("Marcin",21);
Osoba osoba3 = new Osoba("Adrian",25);

osoba1.PrzedstawSie();
osoba2.PrzedstawSie();
osoba3.PrzedstawSie();
class Osoba
{
    private string Imie;
    private int Wiek;

    public Osoba(string imie, int wiek)
    {
        this.Imie = imie;
        this.Wiek = wiek;
    }
    
    
    public void PrzedstawSie()
    {
        Console.WriteLine($"Imie: {Imie}, Wiek: {Wiek}");
    }
}