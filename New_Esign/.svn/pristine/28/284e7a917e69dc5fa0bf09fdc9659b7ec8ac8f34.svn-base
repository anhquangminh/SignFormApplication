using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewModel.EF;

namespace New_Esign.Areas.Administrators.Controllers
{
    public class AddApproverController : Controller
    {
        private DBConnectData db = new DBConnectData();

        // GET: Administrators/AddApprover
        public ActionResult Index()
        {
            var approvers = db.Approvers.Include(a => a.BU).Include(a => a.Site);
            return View(approvers.ToList());
        }

        // GET: Administrators/AddApprover/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approver approver = db.Approvers.Find(id);
            if (approver == null)
            {
                return HttpNotFound();
            }
            return View(approver);
        }

        // GET: Administrators/AddApprover/Create
        public ActionResult Create()
        {
            
            ViewBag.BUID = new SelectList(db.BUs, "BUID", "BUName");
            ViewBag.SiteID = new SelectList(db.Sites, "SiteID", "SiteName");
            ViewBag.ApproverType = new SelectList(db.ApproverTypes, "ApproverTypeID", "ApproverTypeID");
            return View();
        }

        // POST: Administrators/AddApprover/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApproverID,SiteID,BUID,ApproverType,ApproverEmpNo,ApproverEmpName,SetupEmp,SetupTime,LevelApprover")] Approver approver)
        {
            if (ModelState.IsValid)
            {
                db.Approvers.Add(approver);
                approver.SetupTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BUID = new SelectList(db.BUs, "BUID", "BUName", approver.BUID);
            ViewBag.SiteID = new SelectList(db.Sites, "SiteID", "SiteName", approver.SiteID);
            ViewBag.ApproverType = new SelectList(db.ApproverTypes, "ApproverTypeID", "ApproverTypeID", approver.ApproverType);
            return View(approver);
        }

        // GET: Administrators/AddApprover/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approver approver = db.Approvers.Find(id);
            if (approver == null)
            {
                return HttpNotFound();
            }
            ViewBag.BUID = new SelectList(db.BUs, "BUID", "BUName", approver.BUID);
            ViewBag.SiteID = new SelectList(db.Sites, "SiteID", "SiteName", approver.SiteID);
            return View(approver);
        }

        // POST: Administrators/AddApprover/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApproverID,SiteID,BUID,ApproverType,ApproverEmpNo,ApproverEmpName,SetupEmp,SetupTime,LevelApprover")] Approver approver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BUID = new SelectList(db.BUs, "BUID", "BUName", approver.BUID);
            ViewBag.SiteID = new SelectList(db.Sites, "SiteID", "SiteName", approver.SiteID);
            return View(approver);
        }

        // GET: Administrators/AddApprover/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approver approver = db.Approvers.Find(id);
            if (approver == null)
            {
                return HttpNotFound();
            }
            return View(approver);
        }

        // POST: Administrators/AddApprover/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Approver approver = db.Approvers.Find(id);
            db.Approvers.Remove(approver);
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
