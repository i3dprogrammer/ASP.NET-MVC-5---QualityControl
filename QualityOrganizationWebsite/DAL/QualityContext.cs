using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QualityOrganizationWebsite.DAL
{
    public class QualityContext : DbContext
    {
        public DbSet<Models.Publication> Publications { get; set; }

        public System.Data.Entity.DbSet<QualityOrganizationWebsite.ViewModels.PublicationViewModel> PublicationViewModels { get; set; }
    }
}