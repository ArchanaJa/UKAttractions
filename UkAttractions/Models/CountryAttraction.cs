//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UKAttractions.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CountryAttraction
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string City { get; set; }
        [StringLength(1000, MinimumLength = 2)]
        [Required]
        public string Image { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        [StringLength(5000, MinimumLength = 2)]
        [Required]
        public string Description1 { get; set; }
        [StringLength(5000, MinimumLength = 2)]
        [Required]
        public string Description2 { get; set; }
        [StringLength(2000, MinimumLength = 2)]
        [Required]
        public string LinktoAttrctn { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Nullable<double> Cost { get; set; }
        [Range(0.0, 1000000000000)]
        public Nullable<double> Latitude { get; set; }
        [Range(-1000000000000, 0.0)]
        public Nullable<double> Longitude { get; set; }
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Post_Code { get; set; }
    }
}
