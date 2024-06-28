using AutoMapper;
using BusinessLogic.Business.FirebaseBusiness;
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
    public class HotelBusiness
    {
        private readonly IRepository<KhachSan, int> _repository;
        private readonly IRepository<HinhKhachSan, int> _imageRepository;


        private readonly IMapper _mapper;
        private readonly FirebaseService _firebaseService;

        public HotelBusiness(IRepository<KhachSan, int> repository, IRepository<HinhKhachSan, int> imageRepository, IMapper mapper, FirebaseService firebaseService)
        {
            _imageRepository = imageRepository;
            _repository = repository;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }
        public async Task<List<KhachSanModel>> GetAllHotel()
        {
            var hotel = _repository.GetAll();
            var hotelList = _mapper.Map<List<KhachSanModel>>(hotel);
            return hotelList;
        }
        public async Task<KhachSanModel> GetHotelById(int id)
        {
            var hotel = await _repository.GetByIdAsync(id);
            if (hotel == null)
            {
                throw new NotFoundException("KhachSan not found");
            }
            var hotelM = _mapper.Map<KhachSanModel>(hotel);
            return hotelM;
        }
        public async Task<KhachSanModel> GetHotelByName(string name)
        {
            var hotel = await _repository.FindByCondition(h => h.TenKhachSan == name.Trim()).FirstOrDefaultAsync();
            if (hotel == null)
            {
                throw new NotFoundException("KhachSan not found");
            }
            var hotelM = _mapper.Map<KhachSanModel>(hotel);
            return hotelM;
        }
        public async Task<bool> CreateHotel(CreateHotelModel createHotel, int adminId)
        {
            var hotelExist = await _repository.FindByCondition(h => h.TenKhachSan == createHotel.TenKhachSan.Trim()).FirstOrDefaultAsync();
            if (hotelExist != null)
            {
                throw new BadRequestException("KhachSan has exist");
            }
            var newHotel = new KhachSan
            {
                NguoiSua = adminId,

                DiaChi = createHotel.DiaChi,
                TenKhachSan = createHotel.TenKhachSan,
                NgayTao = DateTime.UtcNow,
                NgaySua = DateTime.UtcNow,
                MoTa = createHotel.MoTa,
                TrangThai = SD.ACTIVE,
                SoPhong = createHotel.SoPhong,
                NguoiTao = adminId,
            };
            if (newHotel == null)
            {
                throw new InternalServerErrorException("Cannot create hotel");
            }
            await _repository.AddAsync(newHotel);
            await _repository.Commit();
            var imageUrl = createHotel.Files;
            foreach (var url in imageUrl)
            {
                var newUrl = new HinhKhachSan
                {
                    KhachSanId = newHotel.Id,
                };
                await _imageRepository.AddAsync(newUrl);
                await _imageRepository.Commit();
                var imagePath = FirebasePathName.HOTELIMAGE + $"{newUrl.Id}";
                var imageUploadResult = await _firebaseService.UploadFileToFirebase(url, imagePath);
                if (!imageUploadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                newUrl.Url = (string)imageUploadResult.Result;
                _imageRepository.Update(newUrl);
            }
            var rs = await _imageRepository.Commit();
            return rs > 0;
        }
        public async Task<bool> UpdateHotel(int id, UpdateHotelModel updateHotel, int modifyBy)
        {
            var hotelExist = await _repository.GetByIdAsync(id);
            if (hotelExist != null)
            {
                throw new NotFoundException("KhachSan not found");
            }
            hotelExist.NguoiSua = modifyBy;
            hotelExist.TenKhachSan = updateHotel.TenKhachSan;
            hotelExist.DiaChi = updateHotel.DiaChi;
            hotelExist.NgaySua = DateTime.UtcNow;
            hotelExist.MoTa = updateHotel.MoTa;
            hotelExist.SoPhong = updateHotel.SoPhong;
            _repository.Update(hotelExist);
           
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> ChangeStatusHotel(int id, string status, int modifyby)
        {
            var hotelExit = await _repository.GetByIdAsync(id);
            if (hotelExit != null)
            {
                throw new NotFoundException("KhachSan not found");
            }
            hotelExit.NgaySua = DateTime.UtcNow;
            hotelExit.NguoiSua = modifyby;
            hotelExit.TrangThai = status;
            _repository.Update(hotelExit);
            var rs = await _repository.Commit();
            return rs > 0;
        }
        public async Task<bool> UpdateImageHotel(int id, UpdateHotelImageModel updateHotelImage)
        {
            var hotelExist = await _repository.GetByIdAsync(id);
            if (hotelExist == null)
            {
                throw new NotFoundException("KhachSan not found");
            }
            var imageUrl = updateHotelImage.Url;
            foreach (var url in imageUrl)
            {
                var newUrl = new HinhKhachSan
                {
                    KhachSanId = hotelExist.Id,
                };
                await _imageRepository.AddAsync(newUrl);
                await _imageRepository.Commit();
                var imagePath = FirebasePathName.HOTELIMAGE + $"{newUrl.Id}";
                var imageUploadResult = await _firebaseService.UploadFileToFirebase(url, imagePath);
                if (!imageUploadResult.IsSuccess)
                {
                    throw new InternalServerErrorException("Error uploading files to Firebase.");
                }
                newUrl.Url = (string)imageUploadResult.Result;
                _imageRepository.Update(newUrl);
            }
            var rs = await _imageRepository.Commit();   
            return rs > 0;
        }
        public async Task<bool> DeleteImageHotel(int imageId)
        {
            try
            {
                
                var imageUrl = await _imageRepository.GetByIdAsync(imageId);
                if (imageUrl == null)
                {
                    throw new NotFoundException("Image not found");
                }

                string url = $"{FirebasePathName.HOTELIMAGE}{imageId}";
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

