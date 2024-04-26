using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TTLProject2
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Models.LopHocViewModel, Entities.LopHoc>().ReverseMap();
        }
    }
}
