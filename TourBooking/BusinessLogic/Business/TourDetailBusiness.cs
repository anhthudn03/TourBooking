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
    public class TourDetailBusiness
    {
        private readonly IRepository<ChiTietTour, int> _repository;
        private readonly IMapper _mapper;

        public TourDetailBusiness(IRepository<ChiTietTour,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ChiTietTourModel> GetTourDetailByTourId(int TourId)
        {
            var tourd = _repository.FindByCondition(t => t.TourId == TourId).FirstOrDefault();
            if(tourd == null)
            {
                throw new NotFoundException("Tour Detail Not found");
            }
            var tourDM = _mapper.Map<ChiTietTourModel>(tourd);
            return tourDM;
        }
        public async Task<ChiTietTourModel> GetTourDetailById(int id)
        {
            var tourdetail = await _repository.GetByIdAsync(id);
            if(tourdetail == null)
            {
                throw new NotFoundException("Tour Detail Not Found");
            }
            var tourDM = _mapper.Map<ChiTietTourModel>(tourdetail);
            return tourDM;
        }
        public async Task<bool> CreateTourDetail(CreateTourDetailModel model)
        {
            var newTourDetail = new ChiTietTour
            {
                SoLuongTrong = model.SoLuongTrong,
                NoiKhoiHanh = model.NoiKhoiHanh,
                MoTa = model.MoTa,
                NoiDen = model.NoiDen,
                GiaMoiNguoi = model.GiaMoiNguoi,
                TongGia = model.TongGia,
                SoLuongNguoi = model.SoLuongNguoi,
                TourId = model.TourId,
                PhuongTien = model.PhuongTien,
            };
            await _repository.AddAsync(newTourDetail);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> UpdateTourDetail(int id,UpdateTourDetailModel model)
        {
            var tourDExist= await _repository.GetByIdAsync(id);
            if(tourDExist == null)
            {
                throw new NotFoundException("Not found");
            }
            tourDExist.SoLuongTrong = model.SoLuongTrong;
            tourDExist.SoLuongNguoi = model.TongSoLuongNguoi;
            tourDExist.TongGia = model.TongTen;
            tourDExist.GiaMoiNguoi = model.GiaMoiNguoi;
            tourDExist.PhuongTien = model.PhuongTien;
            tourDExist.NoiKhoiHanh = model.DiemXuatPhat;
            tourDExist.NoiDen = model.DiemDen;
            tourDExist.MoTa = model.MoTa;
            _repository.Update(tourDExist);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> ChangeAvailebleSlot(int id,int slot)
        {
            var tourExist =  await _repository.GetByIdAsync(id);
            if(tourExist == null)
            {
                throw new NotFoundException("not found");
            }
            tourExist.SoLuongTrong = slot;
            _repository.Update(tourExist);
            var rs = await _repository.Commit();
            return rs > 0;
        }
       
    }
}
