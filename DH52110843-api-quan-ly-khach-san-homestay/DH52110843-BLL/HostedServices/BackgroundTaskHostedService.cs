using DH52110843_BLL.Interfaces;
using DH52110843_BLL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace DH52110843_BLL.HostedServices
{
    public class BackgroundTaskHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public BackgroundTaskHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using(var scope = _serviceProvider.CreateScope())
                {
                    var _service = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var list = await _service.bookingService.GetBookingrooms();
                    Debug.WriteLine($"[BackgroundTask] Chạy lúc {DateTime.Now}");
                    Console.WriteLine($"[BackgroundTask] Chạy lúc {DateTime.Now}");
                    // TODO: Gọi service xử lý công việc tại đây nếu cần
                    var processedBookingIds = new HashSet<int>();
                    foreach (var item in list)
                    {
                        if (processedBookingIds.Contains(item.BookingId))
                            continue;
                        var booking = await _service.bookingService.GetBooking(item.BookingId);
                        var room = await _service.roomService.findByIdAsync(item.RoomId);
                        var now = DateTime.Now;
                        if((now - item.CreatedAt).TotalHours >= 24 && booking.Status== 0 && room.Status==true)
                        {
                            Console.WriteLine($"Room {room.RoomNumber} đã quá hạn 24 giờ!");
                            Console.WriteLine($"Booking {item.BookingId} đã quá hạn 24 giờ!");
                            Console.WriteLine($"BookingRoom {item.BkroomsId} đã quá hạn 24 giờ!");
                            Console.WriteLine($"[BackgroundTask] Chạy lúc {item.CreatedAt}");
                            await _service.bookingService.deleteBookingRoom(item.BookingId);
                            processedBookingIds.Add(item.BookingId);
                        }

                    }


                    // Đợi 5 phút (300.000ms) trước lần chạy tiếp theo
                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                }

            }
        }
    }
}
