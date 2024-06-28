using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class BookingBusiness
    {
        private readonly IRepository<DataAccess.Entites.GioHang, int> _repository;
        private readonly IRepository<User, int> _userRepositoty;
        private readonly IRepository<Tour, int> _tourRepository;
        private readonly IMapper _mapper;

        public BookingBusiness(IRepository<DataAccess.Entites.GioHang,int> repository,IRepository<User,int> userRepositoty,IRepository<Tour,int> tourRepository,IMapper mapper)
        {
            _repository = repository;
            _userRepositoty = userRepositoty;
            _tourRepository = tourRepository;
            _mapper = mapper;
        }
        public async Task<List<Dtos.GioHangModel>> GetAllBookingByUserId(int userId)
        {
            var userExist =  await _userRepositoty.GetByIdAsync(userId);
            if (userExist == null)
            {
                throw new NotFoundException("User not found");
            }
            var booking = _repository.GetAll().Where(x => x.UserId == userId).ToList();
            var bookingList = _mapper.Map<List<Dtos.GioHangModel>>(booking);
            return bookingList;
        }
        public async Task<Dtos.GioHangModel> getBookingById(int id)
        {
            var booking = await _repository.GetByIdAsync(id);
            if(booking == null)
            {
                throw new NotFoundException("Booking not found");
            }
            var bkM = _mapper.Map<Dtos.GioHangModel>(booking);
            return bkM;
        }
        public async Task<bool> CreateBooking(CreateBookingModel model,int userId)
        {
            var userExist = await _userRepositoty.GetByIdAsync(userId);
            if(userExist == null)
            {
                throw new NotFoundException("User not found");
            }
            var tourExist = await _tourRepository.GetByIdAsync(model.TourId);
            if(tourExist == null)
            {
                throw new NotFoundException("tour not found");
            }
            var newBooking = new DataAccess.Entites.GioHang
            {
                TourId = model.TourId,
                NgayTao = DateTime.UtcNow,
                TrangThai = SD.ACTIVE,
                UserId = userId,
                NgaySua = DateTime.UtcNow,
            };
            await _repository.AddAsync(newBooking);
            var rs = await _repository.Commit(); 
            if(rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteBooking(int id)
        {
            var bkExist = await _repository.GetByIdAsync(id);
            if(bkExist == null)
            {
                throw new NotFoundException("Booking not found");
            }
            _repository.Remove(id);
            var rs = await _repository.Commit();
            if(rs > 0)
            {
                return true;
            }
            return false;
        }
    }
}
