using MVCDemo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public String Action1()
        {
            return "String returned by Action1 Demo";
        }

        public ActionResult Action2()
        {
            return View();
        }
        public ActionResult Action3()
        {
            // Viewbag is a dynamic 
            ViewBag.msg = "Viewbag messege from Action3 of Demo.";
            return View();
        }
        public ActionResult Action4()
        {
            // Viewbag is a dynamic 
            ViewData["msg"] = "Viewbag messege from Action3 of Demo.";
            return View();
        }
        public ActionResult action5()
        {
            ViewBag.msg = "view bag making its own model : wrong approch";
            return View();
        }

        public ActionResult action6()
        {
            ViewBag.msg = "view receieving model from action5" +
                "right approch";

            MVCDemo01.Models.Member m = new Models.Member();

            m.ID = 1;
            m.FirstName = "kiranpreet";
            m.LastName = "kaur";
            return View(m);

        }
        public ActionResult Action7()
        {
            ViewBag.msg = "View is receiving as  list from action7";
            //DB simulation to fetch multiple records
            List<Member> members = new List<Member>();
            Member m1 = new Member();
            m1.FirstName = "Kiranpreet";
            m1.LastName = "Kaur";
            m1.ID = 1;
            members.Add(m1);
            Member m2 = new Member()
            {
                ID = 2,
                FirstName = "Aman",
                LastName = "Kaur"

            };
            members.Add(m2);
            members.Add(new Member() { ID = 3, FirstName = "Nidhi", LastName = "Shukla" });
            return View(members);
        }

        public ActionResult DailyReport()
        {
            ViewBag.msg = "ViewModel Demo";
            DailyReportVM drvm = new DailyReportVM();
            //db simulate to fetch new members
            drvm.NewMember.Add(new Member() { ID = 101, FirstName = "Kiranpreet", LastName = "Kaur" });
            drvm.NewMember.Add(new Member() { ID = 3, FirstName = "Nidhi", LastName = "Shukla" });
            drvm.TopRatedGame = new Game() { Id = 1, Title = "Contra", Rating = 9 };
            return View(drvm);
        }
    }
}