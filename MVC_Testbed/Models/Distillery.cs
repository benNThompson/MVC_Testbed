using System;
using System.Collections.Generic;

namespace MVC_Testbed.Models
{
    public class Distillery
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bourbon> Bourbons { get; set; }
    }
}
