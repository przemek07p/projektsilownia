using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Models
{
    public class SkladnikPosilkuDTO : MealToDoListItem
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public int KCal { get; set; }

        public float Weglowodany { get; set; }

        public float Bialko { get; set; }

        public float Tluszcz { get; set; }
    }
}
