using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QualityOrganizationWebsite.Models
{
    public class Publication
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The publication title is required.")]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Research Field")]
        public string ResearchField { get; set; }

        [Required]
        public string Authors { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public bool National { get; set; }

        [Required(ErrorMessage = "You must specifiy the year the publication was published.")]
        [Display(Name = "Year of research")]
        public int ResearchYear { get; set; }

        [Required(ErrorMessage = "You must specifiy the publication type.")]
        public PublicationType PubType { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty.")]
        public string Details { get; set; }

        public string Identifier { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        public enum PublicationType
        {
            Journal,
            Confrance,
            Book
        }
    }
}