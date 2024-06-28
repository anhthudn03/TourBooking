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
    public class LocationBusiness
    {
        private readonly IRepository<DiaDiem, int> _repository;
        private readonly IMapper _mapper;

        public LocationBusiness(IRepository<DiaDiem, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<DiaDiemModel>> GetAllLocation()
        {
            var location = _repository.GetAll();
            var locationList = _mapper.Map<List<DiaDiemModel>>(location);
            return locationList;
        }
        public async Task<DiaDiemModel> GetLocationById(int id)
        {
            var location = await _repository.GetByIdAsync(id);
            if(location == null)
            {
                throw new NotFoundException("DiaDiem not found");
            }
            var locationM = _mapper.Map<DiaDiemModel>(location);
            return locationM;
        }
        public async Task<DiaDiemModel> GetLocationByName(string name)
        {
            var location = await _repository.FindByCondition(l => l.TenDiaDiem == name.Trim()).FirstOrDefaultAsync();
            if(location == null)
            {
                throw new NotFoundException("DiaDiem not found");
            }
            var locationM = _mapper.Map<DiaDiemModel>(location);
            return locationM;
        }
       
        public async Task<bool> CreateLocaiton(CreateLocationModel createLocation,int adminId)
        {
            var locationExít = await _repository.FindByCondition(l => l.TenDiaDiem == createLocation.TenDiaDiem.Trim()).FirstOrDefaultAsync();
            if(locationExít != null)
            {
                throw new BadRequestException("Locatin has exist");
            }
            var newLocaiton = new DiaDiem
            {
                NguoiTao = adminId,
                DiaChi = createLocation.DiaChi,
                MoTa = createLocation.DiaChi,
                TenDiaDiem = createLocation.TenDiaDiem,
                NgayTao = DateTime.UtcNow,
                NguoiSua = adminId,
                NgaySua = DateTime.UtcNow,
                TrangThai = SD.ACTIVE
            };
            await _repository.AddAsync(newLocaiton);
            var rs = await _repository.Commit(); 
            if(rs > 0)
            {
                return true;
            }
            return false;

        }
        public async Task<bool> UpdateLocation(int loId,UpdateLocationModel updateLocation,int adminId)
        {
            var locaExist = await _repository.GetByIdAsync(loId);
            if(locaExist == null) {
                throw new NotFoundException("DiaDiem not found");
            }
            locaExist.TenDiaDiem = updateLocation.TenDiaDiem;
            locaExist.NgaySua = DateTime.UtcNow;
            locaExist.NguoiSua = adminId;
            locaExist.DiaChi = updateLocation.DiaChi;
            locaExist.MoTa = updateLocation.MoTa;
            _repository.Update(locaExist);
            var rs = await _repository.Commit();
            if(rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ChangeStatusLocation(int locaId,string status,int adminId)
        {
            var locaExist = await _repository.GetByIdAsync(locaId);
            if(locaExist == null)
            {
                throw new NotFoundException("DiaDiem not found");
            }

            locaExist.NguoiSua = adminId;
            locaExist.TenDiaDiem = status;
            locaExist.NgaySua = DateTime.UtcNow;
            _repository.Update(locaExist);
            var rs = await _repository.Commit();
            if(rs > 0)
            {
                return true;
            }
            return false;
        }
    }
}
