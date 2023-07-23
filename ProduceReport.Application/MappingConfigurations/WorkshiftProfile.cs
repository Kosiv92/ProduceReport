using AutoMapper;
using ProduceReport.Contracts;
using ProduceReport.Core;

namespace ProduceReport.Application.MappingConfigurations
{
    public class WorkshiftProfile : Profile
    {
        public WorkshiftProfile()
        {
            CreateMap<Workshift, WorkshiftResponse>();

            CreateMap<Workshift, WorkshiftRequest>();

            CreateMap<WorkshiftRequest, Workshift>();

            CreateMap<WorkshiftResponse, Workshift>();
        }
    }
}
