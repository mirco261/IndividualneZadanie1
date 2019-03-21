using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Autobazar_konzolova_aplikacia
{
    public static class  Catalogue
    {
        public static int lastID = 0;

        //vytvorený katalóg (list) do ktorého vchádzajú autá
        public static List<Car> catalogue = new List<Car>();

        /// <summary>
        /// Vytvorí ti auto pomocou manuálne zadaných parametrov
        /// </summary>
        public static void CreateCar()
        {
            int year=1950;
            int door;
            int mileage;
            int price;
            eFuelType fuelKey;
            fuelKey = eFuelType.benzin;
            bool crashed = false; //použité crash ano==true
            string crash; //pre zadanie ano/nie pre búranost auta

            //Zadávanie vlastného auta
            Console.WriteLine("**Zadávaš nové auto**");

            //Zadanie automatického ID
            int ID = lastID;
            lastID++;

            //Zadanie značky auta
            Console.Write("\nZnačka: ");
            string make = Console.ReadLine();

            //Zadanie modelu auta
            Console.Write("\nModel: ");
            string model = Console.ReadLine();

            //Zadanie benzin/diesel
            Console.Write("\nPonuka pohonnýh hmôt auta:\nb - Benzin\nd - Diesel\ne - Elektrina\nl - LPG\nStlač písmeno pohonnej hmoty: ");
            string choice = Console.ReadLine();
            choice = choice.ToLower();
            do
            {
                if (choice == "b")
                {
                    fuelKey = eFuelType.benzin;
                    break;
                }
                else if (choice == "d")
                {
                    fuelKey = eFuelType.diesel;
                    break;
                }
                else if (choice == "e")
                {
                    fuelKey = eFuelType.elektrina;
                    break;
                }
                else if (choice == "l")
                {
                    fuelKey = eFuelType.LPG;
                    break;
                }
                else
                {
                    Console.Write("Zadaj prvé písmeno pohonnej hmoty: ");
                    choice = Console.ReadLine();
                    choice = choice.ToLower();
                }

            } while (choice != "b" || choice != "d" || choice != "e" || choice != "l");
            Console.WriteLine($"Zadal si palivo auta: {fuelKey}");

            //Zadanie ročníka (ošetrenie chyby vstupu)
            Console.Write("\nRočník: ");
            do
            {
                try
                {
                    int expYear = int.Parse(Console.ReadLine());
                    year = expYear;
                    break;
                }
                catch (Exception)
                {
                    Console.Write("POZOR: Zadaj ročník auta v číselnom formáte: ");
                }
            } while (true);
            Console.WriteLine($"Zadal si ročník: {year}");

            //Zadanie najazdeného počtu km
            Console.Write("\nNajazdené: ");
            do
            {
                try
                {
                    int ExpMileage = int.Parse(Console.ReadLine());
                    mileage = ExpMileage;
                    break;
                }
                catch (Exception)
                {
                    Console.Write("POZOR: Zadaj počet najazdených km v číselnom formáte: ");
                }
            } while (true);
            Console.WriteLine($"Zadal si počet najazdených: {mileage}km");

            //Zadanie počtu dverí
            Console.Write("\nPočet dverí: ");
            do
            {
                try
                {
                    int ExpDoor = int.Parse(Console.ReadLine());
                    door = ExpDoor;
                    break;
                }
                catch (Exception)
                {
                    Console.Write("POZOR. Zadaj počet dverí v číselnom formáte: ");

                }
            } while (true);
            Console.WriteLine($"Vložil si počet dverí : {door}");

            //Zadanie či bolo búrane
            Console.Write("\nHavarované (ano/nie): ");
            crash = Console.ReadLine();
            crash = crash.ToLower();
            do
            {
                if (crash == "ano")
                {
                    crashed = true;
                    Console.Write("Auto bolo havarované\n");
                    break;
                }
                else if (crash == "nie")
                {
                    crashed = false;
                    Console.WriteLine("Auto nebolo havarované\n");
                    break;
                }
                else
                {
                    Console.Write("Napíš ano alebo nie: ");
                    crash = Console.ReadLine();
                    crash = crash.ToLower();
                }
            } while (crash != "ano" || crash != "nie");

            //Zadanie mesta predajcu
            Console.Write("Mesto: ");
            string city = Console.ReadLine();

            //Zadanie ceny auta
            Console.Write("\nCena: ");
            do
            {
                try
                {
                    int ExpPrice = int.Parse(Console.ReadLine());
                    price = ExpPrice;
                    break;
                }
                catch (Exception)
                {
                    Console.Write("POZOR. Zadajte cenu v číselnom formáte: ");
                }
            } while (true);
            Console.WriteLine($"Auto má novú cenu: {price}EUR");

            Car car = new Car(ID, make, model, year, mileage, door, crashed, city, price, fuelKey);
            catalogue.Add(car);
            Console.WriteLine("\nNové auto bolo vytvorené");
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Vytvorí ti random parametre auta a zapíše
        /// </summary>
        public static void CreateRandomCar()
        {
            int ID = lastID;
            lastID++;
            Car car = new Car(ID);
            catalogue.Add(car);
        }

        /// <summary>
        /// Vypíše ti zoznam áut z katalógu
        /// </summary>
        public static void YourCars()
        {
            foreach (Car c in catalogue)
            {
                Console.WriteLine(c.DescribeMe());
            }
            Console.Write("Pre návrat do menu stlač tlačidlo na klávesnici.");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Vymaže auto z katalógu - vložiť vygenerované ID auta
        /// </summary>
        public static void DeleteCar(int id)
        {
            try
            {
                catalogue.RemoveAt(id);
                Console.Write($"\n**Auto s číslom ID {id} bolo zmazané**\nPre návrat do menu stlač tlačidlo na klávesnici.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.Write($"\nZadané ID:{id} neexistuje.\nNabudúce zadaj ID existujúceho auta v katalógu.\n\nStlačením klávesy sa vrátiš do menu");
                Console.ReadKey();
            }
            
        }

        /// <summary>
        /// Edituje ti už vytvorené aut
        /// </summary>
        public static void EditCar(int id)
        {
            Console.WriteLine($"\n**Editácia auta číslo {id}**\n\n" +
                $"MENU 1 = Značka\n" +
                "MENU 2 = Model\n" +
                "MENU 3 = Ročník\n"+
                "MENU 4 = Počet km\n"+
                "MENU 5 = Počet dverí\n"+
                "MENU 6 = Stav auta\n"+
                "MENU 7 = Mesto\n"+
                "MENU 8 = Cena\n"+
                "MENU 9 = Palivo\n"+
                "MENU 0 = Späť do menu\nZadajte číslo:");

            string switchKey = Console.ReadLine();
            switch (switchKey)
            {
                case "1":
                    Console.WriteLine("Zadaj novú značku auta: ");
                    string newMake = Console.ReadLine();
                    catalogue[id]._make = newMake;
                    break;

                case "2":
                    Console.WriteLine("Zadaj nový model auta: ");
                    string newModel = Console.ReadLine();
                    catalogue[id]._model = newModel;
                    break;

                case "3":
                    Console.WriteLine("Zadaj nový ročník auta: ");
                    do
                    {
                        try
                        {
                            string newYear = Console.ReadLine();
                            catalogue[id]._year = int.Parse(newYear);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.Write("POZOR. Zadajte ročník auta v číselnom formáte: ");
                        }
                    } while (true);
                    break;

                case "4":
                    Console.WriteLine("Zadaj nový počet km: ");
                    do
                    {
                        try
                        {
                            catalogue[id]._mileage = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("Pozor. Zadaj počet km v číselnom tvare");
                        }
                    } while (true);
                    break;

                case "5":
                    Console.WriteLine("Zadaj nový počet dverí: ");
                    do
                    {
                        try
                        {
                            catalogue[id]._doors = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("POZOR. Zadaj nový počet dverí v číselnom tvare: ");
                        }
                    } while (true);
                    break;

                case "6":
                    Console.WriteLine("Zadaj nový stav auta: ");
                    do
                    {
                        try
                        {
                            string crashed = Console.ReadLine();
                            crashed = crashed.ToLower();
                            if (crashed == "ano")
                            {
                                catalogue[id]._crashed = true;
                                break;
                            }
                            else if (crashed == "nie")
                            {
                                catalogue[id]._crashed = false;
                                break;
                            }
                            else
                            {
                                Console.Write("Zadaj slovom 'ano' alebo 'nie': ");
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        
                    } while (true);
                    Console.WriteLine("Stav vozidla bol úspešne zmenený");
                    break;

                case "7":
                    Console.WriteLine("Zadaj nový názov mesta: ");
                    string newCity = Console.ReadLine();
                    catalogue[id]._city = newCity;
                    Console.WriteLine("Nové mesto predaja auta bol úspešne zmenený");
                    break;

                case "8":
                    Console.WriteLine("Zadaj novú cenu auta: ");
                    string newPrice = Console.ReadLine();
                    catalogue[id]._price = int.Parse(newPrice);
                    Console.WriteLine("Nová cena auta bola úspešne zmenená");
                    break;

                case "9":
                    Console.WriteLine("Zadaj nový typ paliva auta: ");
                    Console.Write("Typy pohonnýh hmôt:\nb - Benzin\nd - Diesel\ne - Elektrina\nl - LPG\nStlač písmeno pohonnej hmoty: ");
                    string choice = Console.ReadLine();
                    choice = choice.ToLower();
                    do
                    {
                        if (choice == "b")
                        {
                            Console.WriteLine("Zadal si benzin\n");
                            catalogue[id]._fuel = eFuelType.benzin;
                            break;
                        }
                        else if (choice == "d")
                        {
                            Console.WriteLine("Zadal si diesel\n");
                            catalogue[id]._fuel = eFuelType.diesel;
                            break;
                        }
                        else if (choice == "e")
                        {
                            Console.WriteLine("Zadal si elektrina\n");
                            catalogue[id]._fuel = eFuelType.elektrina;
                            break;
                        }
                        else if (choice == "l")
                        {
                            Console.WriteLine("Zadal si LPG\n");
                            catalogue[id]._fuel = eFuelType.LPG;
                            break;
                        }
                        else
                        {
                            Console.Write("Zadaj prvé písmeno pohonnej hmoty: ");
                            choice = Console.ReadLine();
                            choice = choice.ToLower();
                        }

                    } while (choice != "b" || choice != "d" || choice != "e" || choice != "l");
                    break;

                case "0":
                    break;


                default: break;
            }
        }

        public static void SaveCars(string path)
        {
            File.Delete(path);
            int i = 0;
            while (i < catalogue.Count())
            {
                File.AppendAllText(path,catalogue[i].DescribeMeTxt() );
                i++;
            }
            string[] exit = { "Zatváram za sebou", "Ukladám do súboru", "Zametám za sebou", "Zhasínam" };
            for (int j = 0; j < 4; j++)
            {
                for (int f = 0; f < 11; f++)
                {
                    Console.Clear();
                    Console.Write($"\n  {f * 10}%  **{exit[i]}**");
                    Thread.Sleep(50);
                }
            }

        }

        public static void LoadCars(string path)
        {
            string curFile = path;
            bool exist = File.Exists(curFile);
            if (exist == true)
            {
                string[] txt = File.ReadAllLines(path);
                int i = 0;
                do
                {
                    Car newcar = new Car(i);
                    newcar._make = txt[i].Split('\t')[0];
                    newcar._model = txt[i].Split('\t')[1];
                    newcar._year = int.Parse(txt[i].Split('\t')[2]);
                    newcar._mileage = int.Parse(txt[i].Split('\t')[3]);
                    if (txt[i].Split('\t')[4] == "benzin")
                    {
                        newcar._fuel = eFuelType.benzin;
                    }
                    else if (txt[i].Split('\t')[4] == "diesel")
                    {
                        newcar._fuel = eFuelType.diesel;
                    }
                    else if (txt[i].Split('\t')[4] == "elektrina")
                    {
                        newcar._fuel = eFuelType.elektrina;
                    }
                    else if (txt[i].Split('\t')[4] == "LPG")
                    {
                        newcar._fuel = eFuelType.LPG;
                    }
                    newcar._crashed = bool.Parse(txt[i].Split('\t')[5]);
                    newcar._doors = int.Parse(txt[i].Split('\t')[6]);
                    newcar._city = txt[i].Split('\t')[7];
                    newcar._price = int.Parse(txt[i].Split('\t')[8]);
                    catalogue.Add(newcar);
                    i++;
                } while (i < txt.Length);
                {
                    for (int j = 1; j < 101; j++)
                    { 
                    Console.Clear();
                    Console.WriteLine("**Načítavam zo súboru**");
                    Console.Write($"  {i}% načítaných údajov zo súboru");
                    Thread.Sleep(10);
                    }
                }
                Console.WriteLine("\n\n**Načítanie zo súboru bolo úspešné**\n");
                Console.Write("Pre návrat do menu stlač tlačidlo na klávesnici.");
                Console.ReadKey();

            }
            else Console.WriteLine("**Databáza sa nenašla**\nZoznam áut nemohol byť načítaný\n");
            Console.Write("Pre návrat do menu stlač tlačidlo na klávesnici.");
            Console.ReadKey();
        }

        /// <summary>
        /// Vráti TRUE ak načítaný string je možné skonvertovať do integeru
        /// </summary>
        public static bool CheckInt(string input)
        {
            int outParse;
            do
            {
                if (int.TryParse(input, out outParse))
                {
                    return true;
                }
                else Console.Write("\n!!Nabudúce zadaj číslo (nie písmeno)!!\nNávrat do menu stlačením tlačidla na klávesnici: ");
                Console.ReadKey();
                return false;
            } while (true);
        }
    }
}





