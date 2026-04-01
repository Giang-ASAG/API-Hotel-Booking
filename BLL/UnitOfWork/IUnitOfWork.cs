using DH52110843_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.UnitOfWork
{
    public interface IUnitOfWork
    {

        IBookingService bookingService { get; }
        IHotelImageService hotelImageService { get; }
        IHotelImageStorageService hotelImageStorageService { get; }
        IHotelService hotelService { get; }
        IHotelServiceService hotelServiceService { get; }
        IRoomService roomService { get; }
        IRoomTypeService roomTypeService { get; }
        IUserService userService { get; }
        
        IPaymentService paymentService { get; }
        IRoomImageService roomImageService { get; }
        IRoomImagesStorageService roomImagesStorageService { get; }
        IRoomService_Service roomService_Service { get; }
        IReviewService reviewService { get; }

        IEmailService emailService { get; }
        IUserDocumentService userDocumentService { get; }
    }
}
