using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Models
{
    public class MealDTO
    {
        public string Name { get; set; }

        public List<SkladnikPosilkuDTO> ListaSkladnikow { get; set; }

        public int KalorycznoscPosilku { 
            get 
            {
                var i = 0;
                foreach (var item in ListaSkladnikow)
                {
                    i += item.KCal;
                }

                return i;
                  
            } 
            set
            {
                this.KalorycznoscPosilku = value;
            } 
        }



    }
}
