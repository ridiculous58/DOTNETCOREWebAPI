using HotelFinder.Core.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelDal:RepositoryBase<Hotel,int>,IHotelDal
    {

    }
}
