using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobazar_konzolova_aplikacia
{
    public class Car
    {
        //Zadanie premenných
        private int _ID = 0;
        private int _year =0;
        private int _mileage= 25150;
        private string _make = "Opel";
        private string _model = "Corsa";
        private int _price = 12000;
        private string _city = "Žilina";
        private int _doors = 5;
        private bool _crashed = false;
        int lastID = 0;

        public int ID { get => _ID; set { }  }
        public int Year { get => _year; set { } }
        public int Mileage { get=> _mileage; set { } }
        public string Make { get => _make; set { } }
        public string Model { get => _model; set { } }
        public int Price { get => _price; set { } }
        public string City { get => _city; set { } }
        public int Doors { get => _doors; set { } }
        public bool Crashed { get => _crashed; set { } }


        public eFuelType _fuel ;

        //Zadanie random
        static Random randomInt = new Random();
        static Random randomStr = new Random();
        string[] randomModels = { "Adam", "Corsa", "Astra", "Insignia", "Cascada", "Crossland X"};
        string[] randomCities = { "Žilina", "Kysucké Nové Mesto", "Bytča", "Čadca", "Martin"};

        //konštruktor bez premenných
        public Car(int ID)
        {
            _ID = ID;
            //Random rok
            _year = randomInt.Next(1980, 2019);
            //random nájazd
            _mileage = randomInt.Next(1,250000);
            //random model
            int modelIndex = randomStr.Next(randomModels.Length);
            _model = randomModels[modelIndex];
            //random cena
            _price = randomInt.Next(2000, 45000);
            //random dvere
            _doors = randomInt.Next(2,5);
            //random mesto
            int cityIndex = randomStr.Next(randomCities.Length);
            _city = randomCities[cityIndex];
            //random havarované 
            int crashedInt = randomInt.Next(0, 1);
            if (crashedInt == 1) { _crashed = true; }
            else { _crashed = false; }
            //random pohonná hmota
            int fuelRnd = randomInt.Next(0,3);
            switch (fuelRnd)
            {
                case 0: _fuel = eFuelType.diesel; break;
                case 1: _fuel = eFuelType.benzin; break;
                case 2: _fuel = eFuelType.LPG; break;
                case 3: _fuel = eFuelType.elektrina; break;
            }
            lastID++;
        }

        //Konštruktor s premennými
        public Car(int ID, string make, string model, int year, int mileage, int door, bool crashed, string city, int price, eFuelType fuelkey)
        {
            _ID = ID;
            _make = make;
            _model = model;
            _year = year;
            _mileage = mileage;
            _doors = door;
            _crashed = crashed;
            _city = city;
            _price = price;
            _fuel = fuelkey;
            lastID++;
        }

        //Metoda vypis
        public string DescribeMe()
        {
            StringBuilder sb = new StringBuilder();
            string crash; //pre vypis ano/nie
            sb.Append($"ID: {_ID} {_make} {_model} / r.{_year}\n");
            sb.Append($"najazdených {_mileage}km  {_fuel}\n");
            if (_crashed == true)
            {
                 crash = "havarované";
            }
            else crash = "nehavarované";
            sb.Append($"{_doors} dverové, {crash}\n");
            sb.Append($"{_city} {_price}EUR\n");
            return sb.ToString();
        }

        //Metoda na zapis do suboru
        public string DescribeMeTxt()
        {
            return ($"{_make}\t{_model}\t{_year}\t{_mileage}\t{_fuel}\t{_crashed}\t{_doors}\t{_city}\t{_price}\n");
        }


    }
    public enum eFuelType
    {
        diesel,
        benzin,
        LPG,
        elektrina,
    }
}
