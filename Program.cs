using Microsoft.EntityFrameworkCore;
using task.Data;
using task.Enums;
using task.Models;
using task.Service;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext com InMemory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

// adiciona a Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();

// Adiciona serviços para controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seed Data (Adicionar alguns usuários e tarefas ao iniciar)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData(context);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Método para inserir dados iniciais
void SeedData(AppDbContext context)
{
    if (!context.Users.Any())
    {
        var user1 = new User { Name = "Fernanda" };
        var user2 = new User { Name = "Anderson" };

        user1.Tasks.Add(new TaskItem { Title = "Tarefa 1", Description = "teste tarefa fernanda", Deadline = DateTime.Now.AddDays(1), Created = DateTime.Now, UserId = 1, Status = EStatus.Pendente });
        user1.Tasks.Add(new TaskItem { Title = "Tarefa 2", Description = "teste tarefa fernanda 2", Deadline = DateTime.Now.AddDays(1), Created = DateTime.Now, UserId = 1, Status = EStatus.Pendente });
        user2.Tasks.Add(new TaskItem { Title = "Tarefa 3", Description = "teste tarefa Anderson", Deadline = DateTime.Now.AddDays(3), Created = DateTime.Now, UserId = 2, Status = EStatus.Concluido });

        context.Users.AddRange(user1, user2);
        context.SaveChanges();
    }
}