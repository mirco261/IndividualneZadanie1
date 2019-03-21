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
                        Console.Write("\nPre návrat do menu stlač tlačidlo na klávesnici.");
                        Console.ReadKey();
                        break;

                    case "2":   //Vypísanie auta
                        Console.WriteLine("**Zoznam áut v katalógu**\n");
                        if (Catalogue.IsEmptyCatalogue())
                        {
                            Console.WriteLine("Katalóg áut je prázdny.\n");
                        }
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
                            if (Catalogue.ExistID(int.Parse(idEdit)))
                            {
                                Catalogue.EditCar(int.Parse(idEdit));
                            }
                            else
                            {
                                Console.WriteLine($"\nAuto s ID: {int.Parse(idEdit)} neexistuje.\n");
                                Console.Write("Pre návrat do menu stlač tlačidlo na klávesnici.");
                                Console.ReadKey();
                            }
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
                        Console.Write("Pre návrat do menu stlač tlačidlo na klávesnici.");
                        Console.ReadKey();
                        break;

                    case "7":  //načítanie zo súboru
                        Catalogue.LoadCars(path);
                        Console.Write("Pre návrat do menu stlač tlačidlo na klávesnici.");
                        Console.ReadKey();
                        break;

                    case "0": //ukončiť a zatvoriť
                        Catalogue.SaveCars(path);
                        string[] exit = { "Ukladám do súboru", "Zametám za za sebou", "Zhasínam", "Zatváram", };
                        for (int j = 0; j < 4; j++)
                        {
                            for (int f = 0; f < 11; f++)
                            {
                                Console.Clear();
                                Console.Write($"\n  {f * 10}%  **{exit[j]}**");
                                Thread.Sleep(50);
                            }
                        }
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Write("Zadaj číslo z ponuky: ");
                        break;

                }
            } while (true);
        }
    }
}
