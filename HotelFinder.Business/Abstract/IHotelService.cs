using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllHotels();
        Task<List<Hotel>> GetHotelByName(string name);
        Task<Hotel> GetByIdHotel(int id);

        Task<Hotel> UpdateHotel(Hotel hotel);
        Task<Hotel> AddHotel(Hotel hotel);
        Task DeleteHotel(int id);
    }
}
