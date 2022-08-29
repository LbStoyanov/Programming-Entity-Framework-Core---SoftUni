using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;

namespace SoftUni
{
    public class StartUp
    {
        static async Task Main()
        {
            await using var context = new SoftUniContext();
            var firstEmployee = await context.Employees
                .Include(e => e.Address)
                .ThenInclude(a => a.Town)
                .FirstOrDefaultAsync();
        }
    }
}