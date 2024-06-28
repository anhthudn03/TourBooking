using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class HotelImageBusiness
    {
        private readonly IRepository<HinhKhachSan, int> _repository;
        private readonly IMapper _mapper;

        public HotelImageBusiness(IRepository<HinhKhachSan,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<HinhKhachSanModel>> GetAllHotelImage()
        {
            var hotelI = _repository.GetAll();
            var hotelIList = _mapper.Map<List<HinhKhachSanModel>>(hotelI);
            return hotelIList;
        }
        public async Task<HinhKhachSanModel> GetHotelImageById(int id)
        {
            var hotelI = await _repository.GetByIdAsync(id);
            if(hotelI == null)
            {
                throw new NotFoundException("KhachSan Image not found");
            }
            var him = _mapper.Map<HinhKhachSanModel>(hotelI);
            return him;
        }
        public async Task<bool> CreateHotelImage(int  Hotelid,CreateHotelImageModel createHotelImage)
        {
            var hotelExist = await _repository.GetByIdAsync(Hotelid);
            if (hotelExist == null)
            {
                throw new NotFoundException("KhachSan not found");
            }
            var newHtI = new HinhKhachSan
            {
                KhachSanId = Hotelid,
               
                Url = createHotelImage.Url,
            };
            await _repository.AddAsync(newHtI);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> DeleteHotelImage(int id)
        {
            var hmtExist = await _repository.GetByIdAsync(id);
            if(hmtExist == null)
            {
                throw new NotFoundException("KhachSan image not found");
            }
            _repository.Remove(id);
            var rs = await _repository.Commit();
            return rs > 0;
        }
    }
}
