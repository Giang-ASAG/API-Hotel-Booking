using DH52110843_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBookingService _bookingService;
        private readonly IHotelImageService _hotelImageService;
        private readonly IHotelImageStorageService _hotelImageStorageService;
        private readonly IHotelService _hotelService;
        private readonly IHotelServiceService _hotelserviceService;
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;
        private readonly IRoomImageService _roomImageService;
        private readonly IRoomImagesStorageService _roomImagesStorageService;
        private readonly IRoomService_Service _roomService_Service;
        private readonly IReviewService _reviewService;
        private readonly IEmailService _emailService;
        private readonly IUserDocumentService _userDocument;


        public UnitOfWork(
            IBookingService bookingService,
            IHotelImageService hotelImageService,
            IHotelImageStorageService hotelImageStorageService,
            IHotelService hotelService,
            IHotelServiceService hotelServiceService,
            IRoomService roomService,
            IRoomTypeService roomTypeService,
            IUserService userService,
            IPaymentService paymentService,
            IRoomImageService roomImageService,
            IRoomImagesStorageService roomImagesStorageService,
            IRoomService_Service roomService_Service,
            IReviewService reviewService,
            IEmailService emailService,
            IUserDocumentService userDocument
)
        {
            _bookingService = bookingService;
            _hotelImageService = hotelImageService;
            _hotelImageStorageService = hotelImageStorageService;
            _hotelService = hotelService;
            _hotelserviceService = hotelServiceService;
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _userService = userService;
            _paymentService = paymentService;
            _roomImageService = roomImageService;
            _roomImagesStorageService = roomImagesStorageService;
            _roomService_Service = roomService_Service;
            _reviewService = reviewService;
            _emailService = emailService;
            _userDocument = userDocument;
        }

        public IBookingService bookingService => _bookingService;
        public IHotelImageService hotelImageService => _hotelImageService;
        public IHotelImageStorageService hotelImageStorageService => _hotelImageStorageService;
        public IHotelService hotelService => _hotelService;
        public IHotelServiceService hotelServiceService => _hotelserviceService;
        public IRoomService roomService => _roomService;
        public IRoomTypeService roomTypeService => _roomTypeService;
        public IUserService userService => _userService;
        public IPaymentService paymentService => _paymentService;

        public IRoomImageService roomImageService => _roomImageService;

        public IRoomImagesStorageService roomImagesStorageService => _roomImagesStorageService;

        public IRoomService_Service roomService_Service => _roomService_Service;

        public IReviewService reviewService => _reviewService;


        public IEmailService emailService => _emailService;

        public IUserDocumentService userDocumentService => _userDocument;
    }
}
