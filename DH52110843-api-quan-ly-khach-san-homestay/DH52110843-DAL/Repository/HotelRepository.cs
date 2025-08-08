using DH52110843_DAL.Data;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HethonghotelContext db;
        public HotelRepository(HethonghotelContext db)
        {
            this.db= db;
        }
        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            if (hotel!=null)
            {
                hotel.CreatedAt = DateTime.Now;
                await db.AddAsync(hotel);
                await db.SaveChangesAsync();
                return hotel;
            }
            else
            {
                throw new KeyNotFoundException($"Hotel = null");
            }

        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await db.Hotels.FindAsync(id);
            if (hotel != null)
            {
                var roomtypes=await db.RoomTypes.CountAsync(x=>x.HotelId==hotel.HotelId);
                if(roomtypes>0)
                {
                    throw new KeyNotFoundException($"Cant delete Hotel with ID {id}");
                }
                db.Hotels.Remove(hotel);
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found Hotel with ID {id}");
            }
        }

        public async Task<Hotel> findHotelbyId(int id)
        {
            var hotel = await db.Hotels.FindAsync(id);
            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                throw new KeyNotFoundException($"Not found Hotel with ID {id}");
            }
        }

        public async Task<IEnumerable<Hotel>> findHotelByIdAdress(string address)
        {
            address = RemoveDiacritics(address).ToLower();

            var hotels = await db.Hotels.Where(x=>x.Status==true).ToListAsync(); // lấy toàn bộ về

            return hotels
                .Where(h => RemoveDiacritics(h.Address).ToLower().Contains(address))
                .ToList();
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var normalized = text.Normalize(NormalizationForm.FormD);
            var chars = normalized
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        public async Task<IEnumerable<Hotel>> getAllHotel()
        {
            return await db.Hotels.ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> getAllHotelByIdUser(int id)
        {
            return await db.Hotels.Where(x=>x.UserId==id).ToListAsync();
        }
        public async Task<IEnumerable<Hotel>> searchHotel(HotelSearchRequest hotelSearch)
        {
            //var hotels = await db.Hotels
            //    .Where(h => h.Address.Contains(hotelSearch.Address))
            //    .Where(h => h.RoomTypes.Any(rt =>
            //        rt.Capacity >= hotelSearch.PeopleCount &&
            //        rt.Rooms.Any(r =>
            //            !r.Bookingrooms.Any(br =>
            //                !(br.Booking.CheckOutDate <= hotelSearch.CheckIn || br.Booking.CheckInDate >= hotelSearch.CheckOut)
            //            )
            //        )
            //    ))
            //    .ToListAsync();
            var uh = from h in db.Hotels join u in db.Users on h.UserId equals u.UserId
                     where u.Active == true select h;
            var hotels = await uh
            .Where(h => h.Address.Contains(hotelSearch.Address))
            .Where(h => h.RoomTypes.Any(rt =>
                rt.Capacity >= hotelSearch.PeopleCount &&
                rt.Rooms.Any(r =>
                    !r.Bookingrooms.Any(br =>
                        !(br.Booking.CheckOutDate <= hotelSearch.CheckIn || br.Booking.CheckInDate >= hotelSearch.CheckOut)
                    )
                )
            ))
            .ToListAsync();

            return hotels;
        }


        public async Task UpdateAsync(int id, Hotel hotel)
        {
            var h = await db.Hotels.FindAsync(id);
            if (h != null)
            {
                h.HotelName = hotel.HotelName;
                h.Address = hotel.Address;
                h.PhoneNumber = hotel.PhoneNumber;
                h.Description = hotel.Description;
                h.Email = hotel.Email;
                h.XCoordinate = hotel.XCoordinate;
                h.YCoordinate = hotel.YCoordinate;
                h.UpdatedAt = DateTime.Now;
                h.Star = hotel.Star;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found Hotel with ID {id}");
            }
        }
    }
}
