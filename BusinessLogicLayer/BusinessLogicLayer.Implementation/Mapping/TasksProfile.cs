using AutoMapper;
using BusinessLogicLayer.Contracts.Models;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Implementation.Mapping
{
    public class TasksProfile:Profile 
    {
        public TasksProfile()
        {
            CreateMap<Tasks, TasksDto>();
            CreateMap<TasksDto, Tasks>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
