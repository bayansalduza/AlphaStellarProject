using AlphaStellarProjects.Data.Enums;
using AlphaStellarProjects.Data.FakeContext;
using AlphaStellarProjects.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace AlphaStellarProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet("GetCars")]
        public async Task<IActionResult> GetCars(VehicleColorEnum color)
        {
            var cars = new FakeContext<Cars>().Cars.Where(x => x.VehicleColor == color).ToList();
            return Ok(cars);
        }

        [HttpGet("GetBuses")]
        public async Task<IActionResult> GetBuses(VehicleColorEnum color)
        {
            var buses = new FakeContext<Buses>().Buses.Where(x => x.VehicleColor == color).ToList();
            return Ok(buses);
        }

        [HttpGet("GetBoats")]
        public async Task<IActionResult> GetBoats(VehicleColorEnum color)
        {
            var boats = new FakeContext<Boats>().Boats.Where(x => x.VehicleColor == color).ToList();
            return Ok(boats);
        }

        [HttpPost("ChangeHeadLights")]
        public async Task<IActionResult> ChangeHeadLights(int carId, bool headLightsActive)
        {
            try
            {
                var _context = new FakeContext<Cars>();
                var cars = _context.Cars.FirstOrDefault(x => x.CarID == carId);
                cars.IsActiveHeadLights = headLightsActive;
                _context.Update(cars); //Fake
                if (_context.SaveChanges() == 1)
                {
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("RemoveVehicle")]
        public async Task<IActionResult> RemoveVehicle(VehicleTypeEnum vehicleType, int ID)
        {
            switch (vehicleType)
            {
                case VehicleTypeEnum.Car:
                    new FakeContext<Cars>().Remove(new FakeContext<Cars>().Cars.FirstOrDefault(x => x.CarID == ID));
                    break;
                case VehicleTypeEnum.Boats:
                    new FakeContext<Boats>().Remove(new FakeContext<Cars>().Boats.FirstOrDefault(x => x.Id == ID));
                    break;
                case VehicleTypeEnum.Buses:
                    new FakeContext<Buses>().Remove(new FakeContext<Cars>().Buses.FirstOrDefault(x => x.Id == ID));
                    break;
                default:
                    break;
            }

            if (new FakeContext<Cars>().SaveChanges() == 1)
                return Ok("Succes");
            else
                return BadRequest("Failed");
        }

        /*
         * Öncelikle kodun özensiz ve çok iyi yazılmadığının farkındayım. İstenilen yapıları da tam kavrayamadığımı hissettim, ondan dolayı da eksikleri olmuş olabilir.
         * Projeyi bir db ye vesayre bağlamaya zamanım yoktu yarın bir sınavım var ve şuanki iş yerimde biraz yoğunluk var. Bu kodu yazmaya bile çok zaman ayıramadım.
         * abstract class ve Interface'ler hakkında bilgi birikim olarak görmek istediniz sanırım, fakat şuan çok daha basic yapılarla anladıklarımı geçirmeye çalıştım.
         * Farklı projelerime bakarak daha farklı neler kullandığıma bakabilirsiniz. Service yapılarını da yeni yeni çok kullanmaya başladım. Projelerimde güncel olarak bildiğim uygulamadığım bu yapı var.
         * Scoped ve singleton olduğunu program.cs dosyasında tanımlamam gerektiğini çok fazla new FakeContext() attığımın farkındayım fakat dediğim gibi çok kısıtlı bir zamanım vardı.
         * Teşekkür ediyorum bana vakit ayırdığınız için.
         */
    }
}
