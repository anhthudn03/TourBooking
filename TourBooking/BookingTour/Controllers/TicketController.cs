using AutoMapper;
using BookingTourAPI.Common;
using BookingTourAPI.Common.RequestModel;
using BookingTourAPI.Common.ResponseModel;
using BusinessLogic.Business;
using BusinessLogic.Business.SendmailService;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Dtos.SendMailModel;
using BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingTourAPI.Controllers
{
    [Route("ticket")]
    [Controller]
    public class TicketController : ControllerBase
    {
        private readonly TicketBusiness _ticketBusiness;
        private readonly TourBusiness _tourBusiness;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailSender;

        public TicketController(TicketBusiness ticketBusiness,TourBusiness tourBusiness,IMapper mapper,IEmailService emailSender)
        {
            _ticketBusiness = ticketBusiness;
            _tourBusiness = tourBusiness;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        [HttpGet("all-ticket")]
        public async Task<IActionResult> GetAllTicket()
        {
            var ticket = await _ticketBusiness.GetAllTicket();
            var ticketList = _mapper.Map<List<GetTicketResponse>>(ticket);
            if(ticket != null)
            {
                return Ok(ticketList);
            }
            return BadRequest();
        }
        [HttpGet("ticket-user")]
        [Authorize]
        public async Task<IActionResult> GetTicketOfUser()
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var ticket = await _ticketBusiness.GetAllTicketOfUser(currentUserId);
            var ticketList = _mapper.Map<List<GetTicketResponse>>(ticket);
            if(ticket != null)
            {
                return Ok(ticketList);
            }
            return BadRequest();
        }
        [HttpPost("create-ticket")]
        [Authorize]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest createTicket)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var ticket = _mapper.Map<CreateTicketModel>(createTicket);
            var newTicket = await _ticketBusiness.CreateTicket(ticket, currentUserId);
            if (newTicket == null)
            {
                return BadRequest();
            }

            var mailData = new EmailDto
            {
                EmailToName = createTicket.Email,
                EmailBody = GenerateEmailBody(newTicket.Id, newTicket.TourId),
                EmailSubject = "Thông Tin Đặt Tour Du lịch"

            };
            var email = await _emailSender.SendMail(mailData);
            return Ok(ApiResponse<CreateTicketModel>.Succeed(ticket));
        }
        [HttpPut("change-status/{tickId}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatusTicket([FromRoute] int tickId, [FromForm] string status) {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var ticket = await _ticketBusiness.ChangeStatusTicket(tickId, status,currentUserId);
            if(!ticket)
            {
                return BadRequest();
            }
            return Ok("Success");
        }
        private string GenerateEmailBody(int ticketId,int tourId) {
            var ticketExist =   _ticketBusiness.GetTicketById(ticketId).Result;
            if(ticketExist == null)
            {
                throw new NotFoundException("Ticket not found");
            }
            var tourExist =  _tourBusiness.GetTourById(tourId).Result;

            var emailBody = $@"
        TenTour: {tourExist.TenTour}
        NgayDat: {ticketExist.NgayDat.ToString("yyyy-MM-dd HH:mm:ss")}
        NgayKhoiHanh: {tourExist.NgayKhoiHanh.ToString("yyyy-MM-dd HH:mm:ss")}
        SoNguoi: {ticketExist.SoNguoi}
        TongTien: {ticketExist.TongTien.ToString("C")}
    ";

            return emailBody;
        }
    }
}
