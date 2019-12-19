using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Testbed.Models
{
    public class Bourbon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DistilleryId { get; set; }
        public Distillery Distillery { get; set; }

        public ICollection<BourbonRating> Ratings { get; set; }
    }
}
