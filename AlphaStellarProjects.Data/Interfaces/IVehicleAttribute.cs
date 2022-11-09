using AlphaStellarProjects.Data.Enums;

namespace AlphaStellarProjects.Data.Models
{
    public interface IVehicleAttribute
    {
        public Wheels Wheel { get; set; }
        public HeadLights HeadLight { get; set; }
        public bool IsActiveHeadLights { get; set; } 
    }
}
