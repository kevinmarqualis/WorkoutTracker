using System;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore
{
    [Keyless]
    public class WeightLog
    {
        public int Weight { get; set; }

        public DateTime Date { get; set; }
    }
}
