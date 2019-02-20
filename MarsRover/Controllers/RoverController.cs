using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Data;
using MarsRover.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private IAppRepository _appRepository; 
        public RoverController(IAppRepository appRepository)
        {
            _appRepository = appRepository; 
        }


        [HttpGet("Access")]
        public ActionResult Access()
        {
            var msg = "Arrived to the Service";
            //var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(msg);
        }

        // POST api/values
        [HttpPost]
        [Route("SendRover")]
        public ActionResult Post([FromBody] EntryParameters entry)
        {
            var rectangleSize = _appRepository.DefineRectangle(entry.FirstParameter);  //dikdörtgen boyutunu belirledik
            var FirstRoverStart = _appRepository.DefineLocation(entry.SecondParameter);  //ilk konumun modeline göre parametreleri belirledik.
            var SecondRoverStart = _appRepository.DefineLocation(entry.FourthParameter);  //ilk konumun modeline göre parametreleri belirledik.

            var FirstRoverStop = _appRepository.FinalLocation(entry.ThirdParameter, FirstRoverStart); // ilk roverın son konumu belirlenir
            FirstRoverStop.X = (FirstRoverStop.X > rectangleSize.MaxX) ? rectangleSize.MaxX : FirstRoverStop.X; // eğer sınır dışına çıkarsa soruda ifade edildiği gibi max konumda dursun
            FirstRoverStop.Y = (FirstRoverStop.Y > rectangleSize.MaxY) ? rectangleSize.MaxY : FirstRoverStop.Y; // eğer sınır dışına çıkarsa soruda ifade edildiği gibi max konumda dursun
            var SecondRoverStop = _appRepository.FinalLocation(entry.FifthParameter , SecondRoverStart);  // ikinci rover ın son konumu belirlenir
            SecondRoverStop.X = (SecondRoverStop.X > rectangleSize.MaxX) ? rectangleSize.MaxX : SecondRoverStop.X; // eğer sınır dışına çıkarsa soruda ifade edildiği gibi max konumda dursun
            SecondRoverStop.Y = (SecondRoverStop.Y > rectangleSize.MaxY) ? rectangleSize.MaxY : SecondRoverStop.Y; // eğer sınır dışına çıkarsa soruda ifade edildiği gibi max konumda dursun

            string result = FirstRoverStop.X + " " + FirstRoverStop.Y + " " + FirstRoverStop.Direction; // ilk rover sonuç
            result += " \r\n";  // satır atlamak için
            result += SecondRoverStop.X + " " + SecondRoverStop.Y + " " + SecondRoverStop.Direction;  // ikinci rover sonuç

            return Ok(result);
        }

    }
}
