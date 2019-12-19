using System;
using System.Collections.Generic;
using MVC_Testbed.Models;

namespace MVC_Testbed.ViewModels
{
    public class BourbonWithRating
    {
        public Bourbon Bourbon { get; set; }
        public decimal? Rating { get; set; }
    }

    public class DistilleryDetails
    {
        public Distillery Distillery { get; set; }
        public ICollection<BourbonWithRating> Bourbons { get; set; }
    }
}
