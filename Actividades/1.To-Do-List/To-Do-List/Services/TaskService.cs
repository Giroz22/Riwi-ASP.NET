using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.dtos.request;
using ToDoApi.dtos.response;
using ToDoApi.Models;

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

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return _mapper.Map<TaskResponse>(task);
    }    

    public async Task<TaskResponse> Update(int id, TaskRequest request)
    {
        TaskEntity task = _mapper.Map<TaskEntity>(request);

        task.Id = id;        

        _context.Entry(task).State = EntityState.Modified;
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
}