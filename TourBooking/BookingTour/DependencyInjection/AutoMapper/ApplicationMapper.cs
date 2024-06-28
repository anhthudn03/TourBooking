using AutoMapper;
using BookingTourAPI.Common.AuthViewModel;
using BookingTourAPI.Common.RequestModel;
using BookingTourAPI.Common.ResponseModel;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.AuthDtos;
using BusinessLogic.Dtos.RequestDtos;
using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //Entiti => Model
            CreateMap<GioHang, GioHang>().ReverseMap();
            CreateMap<LoaiTourModel, LoaiTour>().ReverseMap();
            CreateMap<HinhKhachSan, HinhKhachSanModel>().ReverseMap();
            CreateMap<KhachSan, KhachSanModel>().ReverseMap();
            CreateMap<DiaDiem, DiaDiemModel>().ReverseMap();
            CreateMap<Ve, VeModel>().ReverseMap();
            CreateMap<ChiTietTour, ChiTietTourModel>().ReverseMap();
            CreateMap<HuongDanVien, HuongDanVienModel>().ReverseMap();
            CreateMap<HinhTour, HinhTourModel>().ReverseMap();
            CreateMap<DiaDiemTour, DiaDiemTourModel>().ReverseMap();
            CreateMap<Tour, TourModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            //Model => Requset
            CreateMap<CreateBookingModel, CreateBookingRequest>().ReverseMap();
            CreateMap<CreateCategoryModel, CreateCategoryRequest>().ReverseMap();
            CreateMap<CreateHotelModel, CreateHotelRequest>().ReverseMap();
            CreateMap<CreateLocationModel, CreatelocationRequest>().ReverseMap();
            CreateMap<CreateTicketModel, CreateTicketRequest>().ReverseMap();
            CreateMap<CreateTourDetailModel, CreateTourDetailRequset>().ReverseMap();
            CreateMap<CreateTourGuideModel, CreateTourGuideRequest>().ReverseMap();
            CreateMap<CreateTourLocationModel, CreateTourLocationRequest>().ReverseMap();
            CreateMap<CreateTourLocationRequest, CreateTourModel>().ReverseMap();
            CreateMap<CreateTourRequest, CreateTourModel>().ReverseMap();
            CreateMap<CreateUserReques, CreateUserModel>().ReverseMap();
            CreateMap<UpdateHotelImageModel, UpdateHotelImageRequest>().ReverseMap();
            CreateMap<UpdateHotelModel, UpdateHotelRequest>().ReverseMap();
            CreateMap<UpdateSlotTourModel, UpdateSlotTourRequset>().ReverseMap();
            CreateMap<UpdateStatusTicketModel, UpdateStatusTicketModel>().ReverseMap();
            CreateMap<UpdateTicketModel, UpdateStatusTicketRequset>().ReverseMap();
            CreateMap<UpdateTourDetailModel, UpdateTourDetailRequset>().ReverseMap();
            CreateMap<UpdateTourImageModel, UpdateTourImageRequest>().ReverseMap();
            CreateMap<UpdateTourModel, UpdateTourRequest>().ReverseMap();
            CreateMap<UpdateTourLocationModel, UpdateTourLocationRequest>().ReverseMap();
            CreateMap<UpdateUserModel, UpdateUserRequest>().ReverseMap();
            CreateMap<UpdateCategoryModel, UpdateCategoryRequset>().ReverseMap();
            CreateMap<UpdateTourGuideModel, UpdateTourGuideRequest>().ReverseMap();
            CreateMap<UpdateLocationModel, UpdateLocationRequest>().ReverseMap();
            //Model => Response
            CreateMap<GetBookingResponse, BusinessLogic.Dtos.GioHangModel>().ReverseMap();
            CreateMap<GetCategoryResponse, LoaiTourModel>().ReverseMap();
            CreateMap<GetHotelImageResponse, HinhKhachSanModel>().ReverseMap();
            CreateMap<GetHotelResponse, KhachSanModel>().ReverseMap();
            CreateMap<GetLocationResponse, DiaDiemModel>().ReverseMap();
            CreateMap<GetTicketResponse, VeModel>().ReverseMap();
            CreateMap<GetTourDetailResponse, ChiTietTourModel>().ReverseMap();
            CreateMap<GetTourResponse, HuongDanVienModel>().ReverseMap();
            CreateMap<GetTourImageRepsonse, HinhTourModel>().ReverseMap();
            CreateMap<GetTourResponse, TourModel>().ReverseMap();
            CreateMap<GetUserRepsonse, UserModel>().ReverseMap();
            //Token
            CreateMap<TokenRequest, TokenModel>().ReverseMap();
            CreateMap<LoginModel, LoginRequest>().ReverseMap();
            CreateMap<LoginResponse, LoginResponseModel>().ReverseMap();
        }
    }
}
