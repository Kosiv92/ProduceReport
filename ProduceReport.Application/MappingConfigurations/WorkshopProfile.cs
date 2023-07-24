using AutoMapper;
using ProduceReport.Contracts;
using ProduceReport.Core;

namespace ProduceReport.Application.MappingConfigurations
{
    public class WorkshopProfile : Profile
    {
        public WorkshopProfile()
        {
            CreateMap<Workshop, WorkshopResponse>();
            CreateMap<WorkshopRequest, Workshop>();
            CreateMap<WorkshopResponse, Workshop>();
        }
    }
}
