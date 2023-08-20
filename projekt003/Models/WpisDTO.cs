using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Models
{
    internal class WpisDTO
    {
        //kolekcja mięśni z klasy MiesienDTO
        public List<MiesienDTO> MusclesColection { get; set; }
        //Data pomiaru mięśni
        public DateTime MusclesMeasureDate { get; set; }
        //Waga Ciała (masa całego ciała)
        public int BodyWeight { get; set; }
        //zadowolenie z treningu (skala 1 do 10)

        public int TodayScale { get; set; }


    }
    
    
    

}
