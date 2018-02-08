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
        public string ResearchField { get; set; }

        [Required]
        public string Authors { get; set; }

        [Required]
        public bool National { get; set; }

        [Required(ErrorMessage = "You must specifiy the year the publication was published.")]
        public int ResearchYear { get; set; }

        [Required(ErrorMessage = "You must specifiy the publication type.")]
        public PublicationType PubType { get; set; }

        public string Details { get; set; }
        
        public string Identifier { get; set; }

        [Required]
        public string Abstract { get; set; }

        public enum PublicationType
        {
            Journal,
            Confrance,
            Book
        }
    }
}