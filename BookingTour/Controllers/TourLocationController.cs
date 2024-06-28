using AutoMapper;
using BookingTourAPI.Common.RequestModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingTourAPI.Controllers
{
    [Route("tour-location")]
    [Controller]
    public class TourLocationController : ControllerBase
    {
        private readonly TourLocationBusiness _tourLocationBusiness;
        private readonly IMapper _mapper;

        public TourLocationController(TourLocationBusiness tourLocationBusiness,IMapper mapper)
        {
            _tourLocationBusiness = tourLocationBusiness;
            _mapper = mapper;
        }
        [HttpPost("create-tourlocation")]
        public async Task<IActionResult> CreateTourLocation([FromBody] CreateTourLocationRequest createTourLocation)
        {
            var tourlo = _mapper.Map<CreateTourLocationModel>(createTourLocation);
            var newtour = await _tourLocationBusiness.CreateTourLocation(tourlo);
            if (!newtour)
            {
                return BadRequest();
            }
            return Ok(newtour);
        }
        [HttpGet("tourid/{tourId}")]
        public async Task<IActionResult> GetTourLocationByTourId([FromRoute] int tourId)
        {
            var tl = await _tourLocationBusiness.GetAllTourLocationByTourId(tourId);
            if(tl == null)
            {
                return BadRequest();
            }
            return Ok(tl);
        }
        [HttpPut("Update-tourlocaiton/{id}")]
        public async Task<IActionResult> UpdateTourLocation([FromRoute] int id, [FromForm] UpdateTourLocationRequest updateTourLocation)
        {
            var tlUpdate = _mapper.Map<UpdateTourLocationModel>(updateTourLocation);
            var rs = await _tourLocationBusiness.UpdateTourLocation(id, tlUpdate);
            if (!rs)
            {
                return BadRequest();
            }
            return Ok("Update Success");
        }
        [HttpDelete("delete-tourlocation/{id}")]
        public async Task<IActionResult> DeleteTourLocation([FromRoute] int id)
        {
            var rs = await _tourLocationBusiness.DeleteTourLocation(id);
            if (!rs)
            {
                return BadRequest();
            }
            return Ok("Delete Success");
        }
    }
}
