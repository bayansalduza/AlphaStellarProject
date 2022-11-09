using AlphaStellarProjects.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaStellarProjects.Data.Models
{
    public class Buses : IVehicle
    {
        public int Id { get; set; }
        public VehicleColorEnum VehicleColor { get; set; }
    }
}
