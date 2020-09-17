using AutoMapper;
using DoAn.Data;
using DoAn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class MyMapper:Profile
    {
        public MyMapper()
        {
            CreateMap<HangHoa, CartItem>();
        }
    }
}
