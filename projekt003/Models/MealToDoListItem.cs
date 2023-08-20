using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Models
{
    public class MealToDoListItem : MainPageToDoListItem
    {
        public int ID { get; set; }
        public string MealType { get; set; }

        public int Calories { get; set; }

        public DateTime DateTime { get; set; }
    }
}
