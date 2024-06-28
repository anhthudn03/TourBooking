using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Dtos.SendMailModel;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TicketBusiness
    {
        private readonly IRepository<Ve, int> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<User, int> _userRepository;
        private readonly IRepository<Tour, int> _tourRepository;
        private readonly IRepository<ChiTietTour, int> _detailRepository;

        public TicketBusiness(IRepository<Ve,int> repository,IMapper mapper,IRepository<User,int> userRepository,
            IRepository<Tour,int> tourRepository,IRepository<ChiTietTour,int> detailRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _tourRepository = tourRepository;
            _detailRepository = detailRepository;
        }
        public async Task<List<VeModel>> GetAllTicket()
        {
            var ticket = _repository.GetAll();
            var ticketList = _mapper.Map<List<VeModel>>(ticket);
            return ticketList;
        }
        public async Task<VeModel> GetTicketById(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if(ticket == null)
            {
                throw new NotFoundException("Ve Not Found");
            }
            var ticketM = _mapper.Map<VeModel>(ticket);
            return ticketM;
        }
        public async Task<List<VeModel>> GetAllTicketOfUser(int userId)
        {
            var userExist = await _userRepository.GetByIdAsync(userId);
            if(userExist == null)
            {
                throw new NotFoundException("User not found");
            }
            var ticket = _repository.GetAll().Where(t => t.UserId == userId);
            var ticketList = _mapper.Map<List<VeModel>>(ticket);
            return ticketList;
        }
        public async Task<VeModel> CreateTicket(CreateTicketModel ticketModel,int userId)
        {
            var userExist = await _userRepository.GetByIdAsync(userId);
            if(userExist == null)
            {
                throw new NotFoundException("User not found");
            }
            var tourExist = await _tourRepository.GetByIdAsync(ticketModel.TourId);
            if(tourExist == null)
            {
                throw new NotFoundException("Tour Not found");
            }
            var tourDetail = await _detailRepository.FindByCondition(td => td.TourId == tourExist.Id).FirstOrDefaultAsync();
            if(ticketModel.SoNguoi > tourDetail.SoLuongTrong)
            {
                throw new BadRequestException("Amount of people exceeds available slots.");
            }
            var newTicket = new Ve
            {
                SoNguoi = tourDetail.SoLuongTrong,
                NgayDat = DateTime.UtcNow,
                Email = ticketModel.Email,
                HoVaTen = ticketModel.HoVaTen,
                PTTT = ticketModel.PTTT,
                TrangThai = SD.PM_Pending,
                SDT = ticketModel.SDT,
                TourId = ticketModel.TourId,
                UserId = userId,
                TongTien = ticketModel.SoNguoi * tourDetail.GiaMoiNguoi,

            };
            await _repository.AddAsync(newTicket);
            var rs = await _repository.Commit();
            var tkModel = _mapper.Map<VeModel>(newTicket);
            if(rs < 0)
            {
                throw new BadRequestException("Cannot Create");

            }
            return tkModel;

        }
        public async Task<bool> ChangeStatusTicket(int id,string status,int adminId)
        {
            var ticketExist = await _repository.GetByIdAsync(id);
            if(ticketExist == null)
            {
                throw new NotFoundException("Ve Not Found");
            }
            ticketExist.TrangThai = status;
            ticketExist.NguoiSua = adminId;
            ticketExist.NgaySua = DateTime.UtcNow;
            _repository.Update(ticketExist);
            var rs = await _repository.Commit();
            if( rs > 0 )
            {
                return true;
            }

            return false;
        }
        
    }
}
