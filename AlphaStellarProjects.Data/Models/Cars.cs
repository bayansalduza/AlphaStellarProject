using AlphaStellarProjects.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaStellarProjects.Data.Models
{
    public class Cars : IVehicle, IVehicleAttribute
    {
        public VehicleColorEnum VehicleColor { get; set; }
        public Wheels Wheel { get; set; }
        public HeadLights HeadLight { get; set; }
        public int CarID { get; set; }
        public int CarName { get; set; }
        public bool IsActiveHeadLights { get; set; }
    }
}
