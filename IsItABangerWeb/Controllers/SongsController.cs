using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsItABangerWeb.Models;

namespace IsItABangerWeb.Controllers
{
    public class SongsController : Controller
    {
        private BangerDbContext db = new BangerDbContext();

        private readonly IBangerCalculator _bangerCalculator;

        public SongsController() :
            this(new BangerCalculator(new HaverfordBangerStrategy()))
        {

        }

        public SongsController(IBangerCalculator bangerCalculator)
        {
            _bangerCalculator = bangerCalculator;
        }

        // GET: Songs
        public ActionResult Index()
        {
            return View(db.Songs.ToList());
        }

        // POST: Songs/Result
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result([Bind(Include = "Bpm,Drops,DropsAreDope,HasAcousticInstruments")] Song song)
        {
            if (ModelState.IsValid)
            {
                _bangerCalculator.SetBanger(song);
                return View(song);
            }

            return View(song);
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Artist,Bpm,Drops,DropsAreDope,HasAcousticInstruments,IsItABanger")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(song);
        }

        //// GET: Songs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Song song = db.Songs.Find(id);
        //    if (song == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(song);
        //}

        //// POST: Songs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name,Bpm,Drops,DropsAreDope,HasAcousticInstruments")] Song song)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(song).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(song);
        //}

        //// GET: Songs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Song song = db.Songs.Find(id);
        //    if (song == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(song);
        //}

        //// POST: Songs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Song song = db.Songs.Find(id);
        //    db.Songs.Remove(song);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
