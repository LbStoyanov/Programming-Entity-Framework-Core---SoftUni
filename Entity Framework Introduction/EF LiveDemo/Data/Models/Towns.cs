using System;
using System.Collections.Generic;

namespace EF_LiveDemo.Data.Models
{
    public partial class Towns
    {
        public Towns()
        {
            this.Addresses = new HashSet<Addresses>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
