using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemberClubDBModel;
using MemberClubUI.Models;
namespace MemberClubUI.Controllers
{
    public class MembersController : Controller
    {
        private DBModelContainer db = new DBModelContainer();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Type")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Type")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public ActionResult GamesSelection(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            MemberGamesSelectionVM mgsm = new MemberGamesSelectionVM();
            mgsm.Member = member;
            foreach (Game g in db.Games.ToList())
            {
                /*
                SelectableGame sg = new SelectableGame();
                sg.Id = g.Id;
                sg.Title = g.Title;
                sg.isSelected = member.Games.Contains(g);
                
                */
                mgsm.SelectableGames.Add(new SelectableGame()
                {
                   Id = g.Id,
                Title = g.Title,
                isSelected = member.Games.Contains(g)
            });
        }

            return View(mgsm);
    }
    [HttpPost]
    public ActionResult GamesSelection(MemberGamesSelectionVM mgsm)
    {
        if (ModelState.IsValid)
        {
            Member member = db.Members.Find(mgsm.Member.Id);
            db.Entry(member).State = EntityState.Modified;

            foreach (SelectableGame sg in mgsm.SelectableGames)
            {
                Game g = db.Games.Find(sg.Id);
                if (sg.isSelected)
                {
                    member.Games.Add(g);
                }
                else
                {
                    member.Games.Remove(g);
                }
            }
        }
        return View(mgsm);
    }

    // GET: Members/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Member member = db.Members.Find(id);
        if (member == null)
        {
            return HttpNotFound();
        }
        return View(member);
    }

    // POST: Members/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Member member = db.Members.Find(id);
        db.Members.Remove(member);
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
