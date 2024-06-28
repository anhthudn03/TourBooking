using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TourLocationBusiness
    {
        private readonly IRepository<DiaDiemTour, int> _repository;
        private readonly IRepository<Tour, int> _tourRepository;
        private readonly IRepository<DiaDiem, int> _locationRepository;
        private readonly IMapper _mapper;

        public TourLocationBusiness(IRepository<DiaDiemTour,int> repository, IRepository<Tour, int> tourRepository, IRepository<DiaDiem, int> LocationRepository, IMapper mapper)
        {
            _repository = repository;
            _tourRepository = tourRepository;
            _locationRepository = LocationRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateTourLocation(CreateTourLocationModel createTourLocation)
        {
            var tourExist = await _tourRepository.GetByIdAsync(createTourLocation.TourId);
            if (tourExist == null)
            {
                throw new NotFoundException("Tour not found");
            }
            var locationExist = await _locationRepository.GetByIdAsync(createTourLocation.DiaDiemId);
            if (locationExist == null)
            {
                throw new NotFoundException("DiaDiem not found");
            }
            var newTourLocation = new DiaDiemTour
            {
                DiaDiemId = createTourLocation.DiaDiemId,
                TourId = createTourLocation.TourId,
            };
            await _repository.AddAsync(newTourLocation);
            var rs = await _repository.Commit();
            if (rs >0) { return true; }
            return false;
        } 
        public async Task<bool> UpdateTourLocation(int id,UpdateTourLocationModel updateTourLocation)
        {
            var tlExist = await _repository.GetByIdAsync(id);
            if(tlExist == null)
            {
                throw new NotFoundException("Tour Location not found");
            }
            var tourExist = await _tourRepository.GetByIdAsync(updateTourLocation.TourId);
            if(tourExist == null)
            {
                throw new NotFoundException("Tour Not Found");
            }
            var locaExist = await _locationRepository.GetByIdAsync(updateTourLocation.DiaDiemId);
            if(locaExist == null)
            {
                throw new NotFoundException("Location Not Found");
            }
            tlExist.TourId = updateTourLocation.TourId;
            tlExist.DiaDiemId = updateTourLocation.DiaDiemId;
            _repository.Update(tlExist);
            var rs = await _repository.Commit();
            if (rs >0) { return true;}
            return false;
        }
        public async Task<List<DiaDiemTourModel>> GetAllTourLocationByTourId(int tourId)
        {
            var tourExist = await _tourRepository.GetByIdAsync(tourId);
            if(tourExist == null)
            {
                throw new NotFoundException("Tour Not Found");
            }
            var tlList = await _repository.GetAll().Where(t => t.TourId == tourId).Select(l => l.DiaDiemId).ToListAsync();
            var tlModel = _mapper.Map<List<DiaDiemTourModel>>(tlList);
            return tlModel;
        }
        public async Task<bool> DeleteTourLocation(int id)
        {
            var tlExist = await _repository.GetByIdAsync(id);
            if(tlExist == null)
            {
                throw new NotFoundException("Tour Not Found");
            }
            _repository.Remove(id);
            var rs = await _repository.Commit();
            if (rs >0) { return true;}
            return false;
        }
    }
}
