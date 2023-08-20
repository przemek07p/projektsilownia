using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Models
{
    internal class TrainingDay
    {
        
        //public string ExerciseOne { get; set; }
        //public string ExerciseTwo { get; set; }
        //public string ExerciseThree { get; set; }
        
        public DateTime TimeTrainingDay { get; set; }
        public DateTime DateDay { get; set; }
        public List<Exercise> ExerciseList { get; set; }




    }
}
