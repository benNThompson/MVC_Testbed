using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Testbed.Models
{
    public class BourbonRating
    {
        public int Id { get; set; }

        public int BourbonId { get; set; }
        public Bourbon Bourbon { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Rating { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Tasting Date")]
        public DateTime TastingDate { get; set; }
    }
}
