using System;
using System.Linq;
using System.Collections.Generic;
using RandomDataGenerator.Randomizers;
using RandomDataGenerator.FieldOptions;

namespace LAB7
{
    public class Osoba
    {
        public int id;
        public string imie;
        public string nazwisko;
        public int wiek;
        public string kraj;

        public Osoba(int id, string imie, string nazwisko, int wiek, string kraj)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
            this.kraj = kraj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nameGen = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var lastnameGen = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            var ageGen = RandomizerFactory.GetRandomizer(new FieldOptionsInteger { Min = 1, Max = 100 });
            var countryGen = RandomizerFactory.GetRandomizer(new FieldOptionsCountry());
            List<Osoba> osoby = Enumerable.Range(1, 150).Select(
                x =>
                new Osoba(x, nameGen.Generate(), lastnameGen.Generate(), ageGen.Generate().Value, countryGen.Generate())).ToList();
            List<Osoba> sortowane = osoby.OrderBy(x => x.nazwisko).ThenBy(x => x.imie).ToList();
            //szukaj po kraju i po wieku min max
     

            foreach (var item in sortowane)
            {
                Console.WriteLine($"{item.id}: {item.imie} {item.nazwisko} {item.wiek} {item.kraj}");
            }

            Console.WriteLine("Podaj min wiek");
            string wiekmin = Console.ReadLine();
            Console.WriteLine("Podaj max wiek");
            string wiekmax = Console.ReadLine();
            Console.WriteLine("Podaj kraj");
            string kraj = Console.ReadLine();

            int min = Convert.ToInt32(wiekmin);
            int max = Convert.ToInt32(wiekmax);

            List<Osoba> wybrane = osoby.Where(x => x.kraj == kraj && x.wiek >= min && x.wiek <= max).ToList();


            foreach (var item in wybrane)
            {
                Console.WriteLine($"{item.id}: {item.imie} {item.nazwisko} {item.wiek} {item.kraj}");
            }








            //List<int> lista = Enumerable.Range(100, 150).ToList();
            //List<Osoba> osoby = lista.Select(x => new Osoba() { id = x, imie = x.ToString(), nazwisko = "aaa" }).ToList();

            //osoby[45].nazwisko = "bbb";
            //Osoba szukana = osoby.Where(x => x.nazwisko == "aaa").First();
            //List<string> nazwiska = osoby.Select(x => x.nazwisko).ToList();
            //List<string> unikalneNazwiska = osoby.Select(x => x.nazwisko).Distinct().ToList();

            //Console.WriteLine($"{szukana.id} {szukana.imie} {szukana.nazwisko}" );
            //foreach (var item in unikalneNazwiska)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //int numerStrony = 2;
            //int elementyNaStronie = 10;
            //IEnumerable<int> strona = lista.Skip(elementyNaStronie * (numerStrony - 1)).Take(elementyNaStronie);
            //foreach (var item in strona)
            //{
            //    Console.WriteLine(item);
            //}
            //List<int> podzielnePrzez3 = lista.Where(x => x % 3 == 0).ToList();
            //double srednia = podzielnePrzez3.Average();
            //double suma = podzielnePrzez3.Sum();

            //foreach (var item in lista)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine($"Srednia to {srednia}");
            //Console.WriteLine($"Suma to {suma}");
        }
    }
}
