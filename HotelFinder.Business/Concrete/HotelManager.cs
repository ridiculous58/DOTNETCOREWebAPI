using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelDal hotelDal;
        public HotelManager(IHotelDal hotelDal)
        {
            this.hotelDal = hotelDal;
        }
        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            return await hotelDal.Add(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            if(id>0)
            {
                await hotelDal.Delete(id);
            }
            else
            {
                throw new Exception("ID Alani Sifirdan Kucuk Ve Eşit Olamaz");
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await hotelDal.GetAll();
        }

        public async Task<Hotel> GetByIdHotel(int id)
        {
            return await hotelDal.Get(x => x.Id == id);
        }

        public async Task<List<Hotel>> GetHotelByName(string name)
        {
            return await hotelDal.GetAll(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await hotelDal.Update(hotel);
        }
    }
}
