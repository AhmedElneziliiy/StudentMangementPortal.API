using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Models;
using ToDoList.API.Repository;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public TodoController(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetAllAsync()
        {
            var todoItems = await _repository.GetAllAsync();
            var todoItemDTOs = _mapper.Map<IEnumerable<TodoItemDTO>>(todoItems);

            return Ok(todoItemDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetByIdAsync(Guid id)
        {
            var todoItem = await _repository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            var todoItemDTO = _mapper.Map<TodoItemDTO>(todoItem);

            return Ok(todoItemDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> AddAsync(TodoItemCreateDTO todoItemCreateDTO)
        {
            var todoItem = _mapper.Map<TodoItem>(todoItemCreateDTO);
            await _repository.AddAsync(todoItem);

            var todoItemDTO = _mapper.Map<TodoItemDTO>(todoItem);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = todoItemDTO.Id }, todoItemDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, TodoItemUpdateDTO todoItemUpdateDTO)
        {
            if (id != todoItemUpdateDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = await _repository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _mapper.Map(todoItemUpdateDTO, todoItem);
            await _repository.UpdateAsync(todoItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var todoItem = await _repository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}