using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//Automatic Validation Control
    public class HotelController : ControllerBase
    {
        private IHotelService hotelService;
        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var result = await hotelService.GetAllHotels();
            if(result!=null)
            {
                return Ok(result); 
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:min(1)}")]
        public async Task<IActionResult> GetByIdHotel(int id)
        {

            var result = await hotelService.GetByIdHotel(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();   
            }
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var result = await hotelService.GetHotelByName(name);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hotel hotel)
        {
            if(ModelState.IsValid)
            {
                var result = await hotelService.AddHotel(hotel);
                return CreatedAtAction("GetByIdHotel", new { id = result.Id }, result);//Location information Response
            }
            return BadRequest(hotel);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Hotel hotel)
        {
            if(ModelState.IsValid)
            {
                var result = await hotelService.UpdateHotel(hotel);
                return Ok(result);
            }
            return BadRequest(hotel);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id<=0)
            {
                return BadRequest();
            }
            else if(hotelService.GetByIdHotel(id)!=null)
            {
                await hotelService.DeleteHotel(id);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
