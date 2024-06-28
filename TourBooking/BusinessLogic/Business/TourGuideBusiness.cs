using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TourGuideBusiness
    {
        private readonly IRepository<HuongDanVien, int> _repository;
        private readonly IRepository<Ve, int> _ticketRepository;
        private readonly IMapper _mapper;

        public TourGuideBusiness(IRepository<HuongDanVien, int> repository, IRepository<Ve, int> ticketRepository, IMapper mapper)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<List<HuongDanVienModel>> GetAllTourGuide()
        {
            var touiG = _repository.GetAll();
            var tourGList = _mapper.Map<List<HuongDanVienModel>>(touiG);
            return tourGList;
        }
        public async Task<HuongDanVienModel> GetTourGuideById(int id)
        {
            var tourGuide = await _repository.GetByIdAsync(id);
            if (tourGuide == null)
            {
                throw new NotFoundException("Tour Guide Not Found");
            }
            var rs = _mapper.Map<HuongDanVienModel>(tourGuide);
            return rs;
        }
        public async Task<HuongDanVienModel> GetTourGuideByName(string name)
        {
            var tourGuide = await _repository.FindByCondition(tg => tg.HoVaTen == name.Trim()).FirstOrDefaultAsync();
            if (tourGuide == null)
            {
                throw new NotFoundException("Tour Guide Not Found");
            }
            var rs = _mapper.Map<HuongDanVienModel>(tourGuide);
            return rs;
        }
        public async Task<bool> CreateTourGuide(int adminId, CreateTourGuideModel createTourGuide)
        {
            var tgExist = await _repository.FindByCondition(tg => tg.HoVaTen == createTourGuide.HoVaTen).FirstOrDefaultAsync();
            if (tgExist != null)
            {
                throw new BadRequestException("Tour Guide has exist");
            }
            var newTourGuide = new HuongDanVien
            {
                Email = createTourGuide.Email,
                HoVaTen = createTourGuide.HoVaTen,
                SDT = createTourGuide.SDT,
                TrangThai = SD.ACTIVE,
                NguoiTao = adminId,
                NguoiSua = adminId,
                NgayTao = DateTime.UtcNow,
                NgaySua = DateTime.UtcNow,
            };
            _repository.AddAsync(newTourGuide);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTourGuide(int id, UpdateTourGuideModel updateTourGuide, int adminId)
        {
            var tgExist = await _repository.GetByIdAsync(id);
            if (tgExist == null)
            {
                throw new NotFoundException("Tour Guide Not Found");
            }
            tgExist.NgaySua = DateTime.UtcNow;
            tgExist.TrangThai = updateTourGuide.TrangThai;
            tgExist.Email = updateTourGuide.Email;
            tgExist.HoVaTen = updateTourGuide.HoVaTen;
            tgExist.SDT = updateTourGuide.SDT;
            _repository.Update(tgExist);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTicketForTourGuide(int id, int ticketId, int adminId)
        {
            var tgExist = await _repository.GetByIdAsync(id);
            if (tgExist == null)
            {
                throw new NotFoundException("Tour Guide not found");
            }
            var ticketExist = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticketExist == null)
            {
                throw new NotFoundException($"Ve not found");
            }
            tgExist.NguoiSua = adminId;
            tgExist.NgaySua = DateTime.UtcNow;
            tgExist.VeId = ticketId;
            _repository.Update(tgExist);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ChangeStatusTourGuide(int id, string status, int adminId)
        {
            var tgExist = await _repository.GetByIdAsync(id);
            if (tgExist == null)
            {
                throw new NotFoundException("Tour Guide not found");
            }
            tgExist.NgaySua = DateTime.UtcNow;
            tgExist.NguoiSua = adminId;
            tgExist.TrangThai = status;
            _repository.Update(tgExist);
            var rs = await _repository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
    }
}
