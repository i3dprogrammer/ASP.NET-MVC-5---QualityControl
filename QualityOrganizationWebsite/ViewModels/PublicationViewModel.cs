using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualityOrganizationWebsite.ViewModels
{
    public class PublicationViewModel : Models.Publication
    {
        public SelectList ResearchFieldsList { get; set; }
        public SelectList ResearchYearsList { get; set; }
    }
}