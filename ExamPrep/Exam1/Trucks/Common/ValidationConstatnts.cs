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

        //VIN
        public const int VinNumberLength = 17;

        //Client
        public const int ClientNameLength = 40;
        public const int NationalityLength = 40;
    }
}
