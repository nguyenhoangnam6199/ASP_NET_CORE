using AutoMapper;
using Buoi17_18_19_EFCore_CRUD_AJAX.Entities;
using Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Models
{
    public class MyMapper: Profile
    {
        public MyMapper()
        {
            CreateMap<HangHoa, HangHoaTimKiem>()
                .ForMember(dest => dest.NgaySanXuat, opt => opt.MapFrom(src => src.NgaySx))
                .ForMember(hhv => hhv.Loai, opt => opt.MapFrom(src => src.MaLoaiNavigation.TenLoai));
            //.ReverseMap(): map 2 chiều
               

        }
    }
}
