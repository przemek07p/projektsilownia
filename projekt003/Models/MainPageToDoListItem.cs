using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace projekt003.Models
{
    public class MainPageToDoListItem
    {
        public Image Background { get; set; }

        public string Title { get; set; }

        public bool IsTraining { get; set; }

        public bool IsMeal { get; set; }
    }
}
