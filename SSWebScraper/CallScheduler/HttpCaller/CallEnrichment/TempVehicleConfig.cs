﻿namespace SSWebScraper.ScraperService
{
    public static class TempVehicleConfig
    {
        public static string PostType = "transport";
        public static string Category = "cars";

        public static string[] GetConfig()
        {
            string[] vehicleTypes = {"audi", "bmw", "chevrolet", "ford", "honda",
            "hyundai", "jaguar", "kia", "lexus", "mazda", "mercedes", "mitsubishi", "nissan",
            "opel", "peugeot", "porsche", "renault", "skoda", "subaru", "toyota", "volkswagen", "volvo"};
            return vehicleTypes;
        }
        /*string alfaRomeo = "alfa-romeo";
        string audi = "audi";
        string bmw = "bmw";
        string chevrolet = "chevrolet";
        string chrysler = "chrysler";
        string citroen = "citroen";
        string dacia = "dacia";
        string dodge = "dodge";
        string fiat = "fiat";
        string ford = "ford";
        string honda = "honda";
        string hyundai = "hyundai";
        string infiniti = "infiniti";
        string jaguar = "jaguar";
        string jeep = "jeep";
        string kia = "kia";
        string lancia = "lancia";
        string landRover = "land-rover";
        string lexus = "lexus";
        string mazda = "mazda";
        string mercedes = "mercedes";
        string mini = "mini";
        string mitsubishi = "mitsubishi";
        string nissan = "nissan";
        string opel = "opel";
        string peugeot = "peugeot";
        string porsche = "porsche";
        string renault = "renault";
        string saab = "saab";
        string seat = "seat";
        string skoda = "skoda";
        string smart = "smart";
        string subaru = "subaru";
        string suzuki = "suzuki";
        string toyota = "toyota";
        string volkswagen = "volkswagen";
        string volvo = "volvo";
        string gaz = "gaz";
        string vaz = "vaz";
        string others = "others";*/
    }
}
