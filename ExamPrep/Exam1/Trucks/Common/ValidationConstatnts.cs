using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Trucks.Common
{
    public static class ValidationConstatnts
    {
        //Truck
        public const int RegistrationNumberLength = 8;
        public const int VinNumberLength = 17;
        public const string TruckRegistrationNumberRegex = @"[A-Z]{2}\d{4}[A-Z]{2}";

        public const int TankCapacityMin = 950;
        public const int TankCapacityMax = 1420;

        public const int CargoCapacityMin = 5000;
        public const int CargoCapacityMax = 29000;

        public const int CategoryTypeMin = 0;
        public const int CategoryTypeMax = 3;

        public const int MakeTypeMin = 0;
        public const int MakeTypeMax = 4;

        //Client
        public const int ClientNameLength = 40;
        public const int NationalityLength = 40;

        //Despatcher
        public const int DespatcherNameLength = 40;
    }
}
