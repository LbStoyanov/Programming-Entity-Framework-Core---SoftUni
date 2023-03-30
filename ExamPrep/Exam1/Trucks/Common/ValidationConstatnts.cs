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

        //Client
        public const int ClientNameLength = 40;
        public const int NationalityLength = 40;

        //Despatcher
        public const int DespatcherNameLength = 40;
    }
}
