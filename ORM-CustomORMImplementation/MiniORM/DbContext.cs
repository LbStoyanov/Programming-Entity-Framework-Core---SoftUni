using System;
using System.Runtime.InteropServices.ComTypes;

namespace CustomMiniORM
{
    public class DbContext
    {
        internal static Type[] AllowedSQLTypes = {typeof(int),typeof(string)};
    }
}