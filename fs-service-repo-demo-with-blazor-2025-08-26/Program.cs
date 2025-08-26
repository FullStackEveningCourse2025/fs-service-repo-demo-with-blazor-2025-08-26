using BlazorServiceRepositoryDemo.Repositories;
using BlazorServiceRepositoryDemo.Services;
using fs_service_repo_demo_with_blazor_2025_08_26.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

 builder.Services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();
// Register services
builder.Services.AddSingleton<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
