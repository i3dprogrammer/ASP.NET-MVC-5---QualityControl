using QualityOrganizationWebsite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QualityOrganizationWebsite.Models.Publication;

namespace QualityOrganizationWebsite.ViewModels
{
    public class PublicationViewModel
    {
        public PublicationViewModel()
        {

        }

        public PublicationViewModel(Publication pub)
        {
            this.Id = pub.Id;
            this.Title = pub.Title;
            this.Authors = pub.Authors;
            this.Abstract = pub.Abstract;
            this.ResearchField = pub.ResearchField;
            this.ResearchYear = pub.ResearchYear;
            this.National = pub.National ? "National" : "International";
            if (pub.PubType == Publication.PublicationType.Journal)
            {
                this.JournalName = pub.Details;
                this.JournalDOI = pub.Identifier;
            } else if(pub.PubType == Publication.PublicationType.Confrance)
            {
                this.ConfranceDetails = pub.Details;
            } else
            {
                this.BookName = pub.Details;
                this.BookISSN = pub.Identifier;
            }
        }
        public int Id;

        [Required(ErrorMessage = "The publication title is required.")]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string Authors { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        [Required]
        [Display(Name = "Research Field")]
        public string ResearchField { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public string National { get; set; }

        [Required(ErrorMessage = "You must specifiy the year the publication was published.")]
        [Display(Name = "Year of research")]
        public int ResearchYear { get; set; }

        public PublicationType PubType { get; set; }

        public SelectList ResearchFieldsList { get; set; }
        public SelectList ResearchYearsList { get; set; }
        public SelectList NationalityList { get; set; }

        [StringLength(100)]
        public string JournalName { get; set; }
        [StringLength(100)]
        public string JournalDOI { get; set; }

        [StringLength(100)]
        public string ConfranceDetails { get; set; }

        [StringLength(100)]
        public string BookName { get; set; }
        [StringLength(100)]
        public string BookISSN { get; set; }
    }
}