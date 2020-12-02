using AutoMapper;
using BusinessLogicLayer.Contracts.Models;
using WebApi.Models.Tasks;

namespace WebApi.Mapping
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<TasksCreateRequest, TasksDto>()
                .ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<TasksUpdateRequest, TasksDto>();
        }
    }
}
