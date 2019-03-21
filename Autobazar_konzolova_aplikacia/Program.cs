using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Autobazar_konzolova_aplikacia
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Public\Documents\dtb.txt";
            do
            {
                // Hlavne menu
                Console.Clear();
                Console.Write("**Vitajte v katalogu aut**\n\n" +
                    "MENU 1 = Vloženie auta\n" +
                    "MENU 2 = Zobrazenie auta\n" +
                    "MENU 3 = Vymazanie auta\n" +
                    "MENU 4 = Editovanie auta\n" +
                    "MENU 5 = Vloženie default auta\n" +
                    "MENU 6 = Zapísanie do súboru\n" +
                    "MENU 7 = Načítanie údajov zo súboru\n" +
                    "MENU 0 = Ukončiť a uložiť do súboru\n\n"+
                    "Zadajte číslom svoj výber: ");

                string menu = Console.ReadLine();
                Console.Clear();
                switch (menu)
                {
                    case "1":  //vloženie nového auta
                        Catalogue.CreateCar();
                        break;

                    case "2":   //Vypísanie auta
                        Console.WriteLine("**Zoznam áut v katalógu**\n");
                        Catalogue.YourCars(); 
                        break;

                    case "3":  //Vymazanie auta
                        Console.WriteLine("**Zadaj id auta, ktoré chceš vymazať**");
                        string idRemove = Console.ReadLine();
                        if (Catalogue.CheckInt(idRemove))
                        {
                            Catalogue.DeleteCar(int.Parse(idRemove));
                        }
                        break;

                    case "4":  //Editovanie auta
                        Console.WriteLine("**Edituješ auto**\n\nZadaj id auta na vykonanie zmien: ");
                        string idEdit = Console.ReadLine();
                        if (Catalogue.CheckInt(idEdit))
                        {
                            Catalogue.EditCar(int.Parse(idEdit));
                        }
                        break;

                    case "5":  //vloženie random áut
                        Console.Write("**Vkladanie random áut**\nZadaj počet áut, ktoré chceš vytvoriť: ");
                        string pocetAut = Console.ReadLine();
                        if (Catalogue.CheckInt(pocetAut))
                        {
                            for (int i = 0; i < int.Parse(pocetAut); i++)
                            {
                                Catalogue.CreateRandomCar();
                            }
                            Console.WriteLine("**Nasledovné autá boli vytvorené**\n");
                            Catalogue.YourCars();
                        }
                        break;

                    case "6":  //ukladanie do súboru
                        for (int i = 1; i < 101; i++)
                        {
                            Console.Clear();
                            Console.WriteLine("**Zapisujem do súboru**");
                            Console.Write($"  {i}% zapísaných údajov zo súboru");
                            Thread.Sleep(10);
                        }
                        Catalogue.SaveCars(path);
                        Console.WriteLine("\n**Zapísanie do súboru bolo úspešné**\n");
                        break;

                    case "7":  //načítanie zo súboru
                        Catalogue.LoadCars(path); 
                        break;

                    case "0": //ukončiť a zatvoriť
                        Catalogue.SaveCars(path);
                        break;

                    default:
                        Console.Write("Zadaj číslo z ponuky: ");
                        break;

                }
            } while (true);
        }
    }
}
