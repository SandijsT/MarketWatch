using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallScheduler.HttpCaller.Requests
{
    internal class VehicleResponse
    {
        public string? Category { get; set; }
        public string? Make { get; set; }
        public int PostsSaved { get; set; }
    }
}
