using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo01.Models
{
    public class DailyReportVM
    {
        //Nned member joined today
        public List<Member> NewMember;

        //top rated game of the day
        public Game TopRatedGame;
        public DailyReportVM()
        {
            NewMember = new List<Member>();
        }
    }
}