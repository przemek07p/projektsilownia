using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Models
{
    internal class Exercise
    {
       
            public string WorkoutName { get; set; }
            public int SeriesCounter { get; set; }
            public int RepetSeriesCounter { get; set; }
            public List<MiesienDTO> MusclesColection { get; set; }
            public DateTime WorkoutTime { get; set; }

    }
}
