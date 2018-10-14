using MemberClubDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberClubUI.Models
{
    public class MemberGamesSelectionVM
    {
       public Member Member { get; set; }
       public List<SelectableGame> SelectableGames { get; set; }

        public MemberGamesSelectionVM()
        {
            SelectableGames = new List<SelectableGame>();
        }

    }
    public class SelectableGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isSelected { get; set; }
    }
}