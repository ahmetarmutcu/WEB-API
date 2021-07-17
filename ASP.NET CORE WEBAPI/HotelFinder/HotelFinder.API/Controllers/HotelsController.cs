using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Otomatik olarak validation kontrollerini yapar.
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetHotels();
            return Ok(hotels); //Response code olarak 200+data
        }

        /// <summary>
        /// Get hotel by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("[action]/{id}")] //api/hotels/GetHotelByID/2
        public IActionResult GetHotelByID(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
                return Ok(hotel);//200+Hotel
            return NotFound(); //404
        }


        [HttpGet]
        [Route("[action]/{name}")] //api/hotels/GetHotelByID/2
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
                return Ok(hotel);//200+Hotel
            return NotFound(); //404
        }

        [HttpGet]
        [Route("[action]/{id}/{name}")] //api/hotels/GetHotelByID/2
        public IActionResult GetHotelByIDAndName(int id,string name)
        {
            var hotel = _hotelService.GetHotelByIDAndName(id,name);
            if (hotel != null)
                return Ok(hotel);//200+Hotel
            return NotFound(); //404
        }



        /// <summary>
        /// Create an hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Hotel hotel)
        {
            var createdHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel);
        }

        /// <summary>
        /// Update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }

        /// <summary>
        /// Delete the hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
