using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QualityOrganizationWebsite.DAL;
using QualityOrganizationWebsite.Models;
using QualityOrganizationWebsite.ViewModels;
using System.IO;

namespace QualityOrganizationWebsite.Controllers
{
    public class PublicationsController : Controller
    {
        private QualityContext db = new QualityContext();
        private string[] ResearchFields;
        private int[] ResearchYears;
        private int ResearchYearStart = 1950;

        public PublicationsController() : base()
        {
            System.Diagnostics.Debug.WriteLine("Yo");
            ResearchFields = System.IO.File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Fields.txt"));
            ResearchYears = Enumerable.Range(ResearchYearStart, DateTime.Now.Year - ResearchYearStart + 1).ToArray();
        }

        public ActionResult Add()
        {
            PublicationViewModel viewModel = new PublicationViewModel();
            viewModel.ResearchFieldsList = new SelectList(ResearchFields);
            viewModel.ResearchYearsList = new SelectList(ResearchYears);
            viewModel.NationalityList = new SelectList(new string[] { "National", "International" }, "National");
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(PublicationViewModel viewModel)
        {
            // Research field
            if (!ResearchFields.Contains(viewModel.ResearchField))
                ModelState.AddModelError("ResearchField", "The research field you chosen doesn't exist.");

            // Research year
            if (!ResearchYears.Contains(viewModel.ResearchYear))
                ModelState.AddModelError("ResearchYear", "The year you chosen were incorrect.");


            // Fill our database model data.
            Publication pub = new Publication();
            pub.Abstract = viewModel.Abstract;
            pub.Authors = viewModel.Authors;
            pub.National = viewModel.National == "National";
            pub.ResearchField = viewModel.ResearchField;
            pub.ResearchYear = viewModel.ResearchYear;
            pub.Title = viewModel.Title;

            if (Request.Form["published_in"] == "journal")
            {
                pub.Details = viewModel.JournalName;
                pub.Identifier = viewModel.JournalDOI;
                pub.PubType = Publication.PublicationType.Journal;
            }
            else if (Request.Form["published_in"] == "confrance")
            {
                pub.Details = viewModel.ConfranceDetails;
                pub.PubType = Publication.PublicationType.Confrance;
            }
            else
            {
                pub.Details = viewModel.BookName;
                pub.Identifier = viewModel.BookISSN;
                pub.PubType = Publication.PublicationType.Book;
            }

            if (ModelState.IsValid)
            {
                db.Publications.Add(pub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.ResearchFieldsList = new SelectList(ResearchFields, pub.ResearchField);
            viewModel.ResearchYearsList = new SelectList(ResearchYears, pub.ResearchYear);
            viewModel.NationalityList = new SelectList(new string[] { "National", "International" }, viewModel.National);
            return View(viewModel);
        }

        // GET: Publications
        public ActionResult Index()
        {
            return View(db.Publications.ToList());
        }

        // GET: Publications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // GET: Publications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ResearchField,Authors,National,ResearchYear,PubType,Details,Identifier,Abstract")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publication);
        }

        // GET: Publications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }

            PublicationViewModel viewModel = new PublicationViewModel(publication);
            viewModel.ResearchFieldsList = new SelectList(ResearchFields);
            viewModel.ResearchYearsList = new SelectList(ResearchYears);
            viewModel.NationalityList = new SelectList(new string[] { "National", "International" });

            return View(viewModel);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublicationViewModel viewModel)
        {
            // Research field
            if (!ResearchFields.Contains(viewModel.ResearchField))
                ModelState.AddModelError("ResearchField", "The research field you chosen doesn't exist.");

            // Research year
            if (!ResearchYears.Contains(viewModel.ResearchYear))
                ModelState.AddModelError("ResearchYear", "The year you chosen were incorrect.");


            // Fill our database model data.
            Publication pub = new Publication();
            pub.Id = viewModel.Id;
            pub.Abstract = viewModel.Abstract;
            pub.Authors = viewModel.Authors;
            pub.National = viewModel.National == "National";
            pub.ResearchField = viewModel.ResearchField;
            pub.ResearchYear = viewModel.ResearchYear;
            pub.Title = viewModel.Title;

            if (Request.Form["published_in"] == "journal")
            {
                pub.Details = viewModel.JournalName;
                pub.Identifier = viewModel.JournalDOI;
                pub.PubType = Publication.PublicationType.Journal;
            }
            else if (Request.Form["published_in"] == "confrance")
            {
                pub.Details = viewModel.ConfranceDetails;
                pub.PubType = Publication.PublicationType.Confrance;
            }
            else
            {
                pub.Details = viewModel.BookName;
                pub.Identifier = viewModel.BookISSN;
                pub.PubType = Publication.PublicationType.Book;
            }


            if (ModelState.IsValid)
            {
                db.Entry(pub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.ResearchFieldsList = new SelectList(ResearchFields, pub.ResearchField);
            viewModel.ResearchYearsList = new SelectList(ResearchYears, pub.ResearchYear);
            viewModel.NationalityList = new SelectList(new string[] { "National", "International" }, viewModel.National);
            return View(viewModel);
        }

        // GET: Publications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publication publication = db.Publications.Find(id);
            db.Publications.Remove(publication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
