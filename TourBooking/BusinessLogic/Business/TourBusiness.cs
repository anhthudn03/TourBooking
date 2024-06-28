using AutoMapper;
using BusinessLogic.Business.FirebaseBusiness;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class TourBusiness
    {
        private readonly IRepository<Tour, int> _repository;
        private readonly IRepository<HinhTour, int> _imageRepository;
        private readonly IMapper _mapper;
        private readonly FirebaseService _firebaseService;

        public TourBusiness(IRepository<Tour, int> repository, IRepository<HinhTour, int> imageRepository, IMapper mapper, FirebaseService firebaseService)
        {
            _repository = repository;
            _imageRepository = imageRepository;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }
        public async Task<List<TourModel>> GetAllTour()
        {
            var tour = _repository.GetAll();
            var tourList = _mapper.Map<List<TourModel>>(tour);
            return tourList;
        }
        public async Task<TourModel> GetTourById(int id)
        {
            var tour = await _repository.GetByIdAsync(id);
            if (tour == null)
            {
                throw new NotFoundException("Tour not found");
            }
            var tourM = _mapper.Map<TourModel>(tour);
            return tourM;
        }
        public async Task<TourModel> GetTourByName(string name)
        {
            var tour = await _repository.FindByCondition(t => t.TenTour == name.Trim()).FirstOrDefaultAsync();
            if (tour == null)
            {
                throw new NotFoundException("tour not found");
            }
            var tourM = _mapper.Map<TourModel>(tour);
            return tourM;
        }
        public async Task<bool> CreateTour(CreateTourModel createTour, int adminId)
        {
            var tourExist = await _repository.FindByCondition(t => t.TenTour == createTour.TenTour).FirstOrDefaultAsync();
            if (tourExist != null)
            {
                throw new BadRequestException("Tour has exist");
            }
            var newTour = new Tour
            {
                TenTour = createTour.TenTour,
                LoaiTuorId = createTour.LoaiTuorId,
                MoTa = createTour.MoTa,
                NguoiTao = adminId,
                KhachSanId = createTour.KhachSanId,
                NguoiSua = adminId,
                GiaTour = createTour.GiaTour,
                TrangThai = SD.ACTIVE,
                NgayKhoiHanh = createTour.NgayKhoiHanh,
                SoNgay = createTour.SoNgay,
                NgayTao = DateTime.UtcNow,
                NgaySua = DateTime.UtcNow,
            };
            await _repository.AddAsync(newTour);
            await _repository.Commit();
            var imageUrl = createTour.Files;
            foreach (var url in imageUrl)
            {
                var imageTour = new HinhTour
                {
                    TourId = newTour.Id,
                };
                await _imageRepository.AddAsync(imageTour);
                await _imageRepository.Commit();
                var imagePath = FirebasePathName.TOURIMAGE + $"{imageTour.Id}";
                var imageLoadResult = await _firebaseService.UploadFileToFirebase(url, imagePath);
                if (!imageLoadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                imageTour.Url = (string)imageLoadResult.Result;
                _imageRepository.Update(imageTour);
            }
            var rs = await _imageRepository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTour(int tourId, UpdateTourModel updateTour, int adminId)
        {
            var TourExist = await _repository.GetByIdAsync(tourId);
            if (TourExist == null)
            {
                throw new NotFoundException("Tour not found");
            }
            TourExist.TenTour = updateTour.TenTour;
            TourExist.NgayKhoiHanh = updateTour.NgayKhoiHanh;
            TourExist.NguoiSua = adminId;
            TourExist.GiaTour = updateTour.Gia;
            TourExist.NgaySua = DateTime.UtcNow;
            TourExist.MoTa = updateTour.MoTa;
            TourExist.LoaiTuorId = updateTour.CategoryTourId;
            TourExist.KhachSanId = updateTour.KhachSanId;
            _repository.Update(TourExist);
            var imageUrl = updateTour.Files;
            foreach (var url in imageUrl)
            {
                var newImage = new HinhTour
                {
                    TourId = tourId
                };
                await _imageRepository.AddAsync(newImage);
                await _imageRepository.Commit();

                var imagePath = FirebasePathName.TOURIMAGE + $"{newImage.Id}";
                var imageLoadResult = await _firebaseService.UploadFileToFirebase(url, imagePath);
                if (!imageLoadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                newImage.Url = (string)imageLoadResult.Result;
                _imageRepository.Update(newImage);
            }
            var rs = await _imageRepository.Commit();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateStatusTour(int tourId, int adminId)
        {
            var tourExist = await _repository.FindByCondition(t => t.Id == tourId).FirstOrDefaultAsync();
            if (tourExist == null)
            {
                throw new NotFoundException("Tour not found");
            }
            tourExist.TrangThai = SD.INACTIVE;
            tourExist.NguoiSua = adminId;
            _repository.Update(tourExist);
            var rs = await _repository.Commit();
            if (rs > 0) { return true; }
            return false;
        }
        public async Task<bool> DeleteImageTour(int imageId)
        {

            try
            {

                var imageUrl = await _imageRepository.GetByIdAsync(imageId);
                if (imageUrl == null)
                {
                    throw new NotFoundException("Image not found");
                }

                string url = $"{FirebasePathName.TOURIMAGE}{imageId}";
                var deleteResult = await _firebaseService.DeleteFileFromFirebase(url);
                if (!deleteResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Failed to delete old image");
                }

                _imageRepository.Update(imageUrl);
                var rs = await _imageRepository.Commit();
                return rs > 0;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi chi tiết
                Console.WriteLine($"Error in DeleteImageHotel: {ex.Message}");
                throw;
            }
        }
    }
}
