using AutoMapper;
using ToDoList.API.Models;

namespace ToDoList.API.Helpers
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<TodoItemCreateDTO, TodoItem>();

            CreateMap<TodoItemUpdateDTO, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
