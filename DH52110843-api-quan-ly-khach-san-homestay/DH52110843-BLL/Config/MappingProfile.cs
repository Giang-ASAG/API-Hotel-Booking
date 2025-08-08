using AutoMapper;
using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Booking,BookingDTO>().ReverseMap();
            CreateMap<Booking, BookingMVVMDTO>().ReverseMap();
            CreateMap<Hotel,HotelDTO>().ReverseMap();
            CreateMap<HotelImage,HotelImageDTO>().ReverseMap();
            CreateMap<HotelImagesStorage, HotelImageStorageDTO>().ReverseMap();
            CreateMap<HotelService, HotelServiceDTO>().ReverseMap();
            CreateMap<RoomImagesStorage, RoomImageStorageDTO>().ReverseMap();
            CreateMap<Month, MonthDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<RoomImage,RoomImageDTO>().ReverseMap();
            CreateMap<RoomService, RoomServiceDTO>().ReverseMap();
            CreateMap<RoomType, RoomTypeDTO>().ReverseMap();
            CreateMap<RoomType, RoomTypeCountDTO>().ReverseMap();
            CreateMap<Statistic, StatisticDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<User, UserNoPasswordDTO>().ReverseMap();
            CreateMap<Bookingroom, BookingRoomDTO>().ReverseMap();
            CreateMap<UserDocument,  UserDocumentDTO>().ReverseMap();   

        }
    }
}
