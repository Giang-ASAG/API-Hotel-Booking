using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> getAllRoomTypeAsync();
        Task<IEnumerable<RoomType>> getAllRoomTypebyHotelIdAsync(int id);
        Task<RoomType> addAsync(RoomType roomType);
        Task<int> getCount(int id, bool status);
        Task<int> getCountSearch(int roomtypeid, DateTime checkin, DateTime checkout);
        Task<IEnumerable<RoomType>> getAllRoomTypebyUserIdAsync(int id);
        Task<IEnumerable<RoomType>> searchRoomType(RoomTypeSearchRequest request);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomType roomType);
        Task<RoomType> findAsync(int id);
    }
}
public class RoomTypeSearchRequest
{
    public int hotelId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
}