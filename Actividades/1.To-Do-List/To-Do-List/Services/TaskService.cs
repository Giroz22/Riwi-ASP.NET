using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.dtos.request;
using ToDoApi.dtos.response;
using ToDoApi.Models;

namespace ToDoApi.Services
{    
    class TaskService : ITaskService
    {

        private readonly BaseContext _context;

        private readonly IMapper _mapper;

        public TaskService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskResponse>> GetAll()
        {
            var tasks = await _context.Tasks.ToListAsync();

            return _mapper.Map<IEnumerable<TaskResponse>>(tasks);
        }

        public async Task<TaskResponse?> GetById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            return _mapper.Map<TaskResponse>(task);
        }

        public async Task<TaskResponse> Create(TaskRequest requets)
        {
            TaskEntity task = _mapper.Map<TaskEntity>(requets);

            AssignDefaultCreationData(task);

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskResponse>(task);
        }    

        public async Task<TaskResponse> Update(int id, TaskRequest request)
        {
            var task = await _context.Tasks.FindAsync(id);

            if(task == null) throw new Exception("Product not found");

            _mapper.Map(request, task);

            AssignDefaultUpdateData(task);      

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskResponse>(task);
        }

        public async Task Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if(task != null)
            {
                task.Deleted = true;
                await _context.SaveChangesAsync();
            }        
        }

        // Métodos para manipular los datos
        private void AssignDefaultCreationData(TaskEntity task)
        {
            task.Status = StatusTask.Pending;            
            task.Created_at = DateTime.Now;
            task.Updated_at = DateTime.Now;        
            task.Deleted = false;
        }

        private void AssignDefaultUpdateData(TaskEntity task)
        {
            task.Updated_at = DateTime.Now;
        }

        private void MarkAsCompleted(TaskEntity task)
        {
            task.Status = StatusTask.Completed;
            task.Completed_at = DateTime.Now;
        }

        private void UpdateStatus(TaskEntity task, StatusTask newStatus)
        {
            task.Status = newStatus;
            task.Updated_at = DateTime.Now;
        }
    }   
}