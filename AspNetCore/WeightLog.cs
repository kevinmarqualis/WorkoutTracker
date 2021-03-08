using System;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore
{

    public class WeightLog
    {
        public int Id { get; set; }

        public int Weight { get; set; }
        
        public DateTime Date { get; set; }
    }
}
