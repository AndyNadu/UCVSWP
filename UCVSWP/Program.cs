using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UCVSWP.Data;
using Microsoft.AspNetCore.Identity;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;
using UCVSWP.Repositories;
using UCVSWP.Services;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UCVSWPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UCVSWPContext") ?? throw new InvalidOperationException("Connection string 'UCVSWPContext' not found.")));

//REPOSITORY
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IClassroomRepository, ClassroomRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeAssignmentRepository, GradeAssignmentRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IUserClassroomRepository,UserClassroomRepository>();


//SERVICII
builder.Services.AddScoped<IAnnouncementService,AnnouncementService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IClassroomService, ClassroomService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IGradeAssignmentService, GradeAssignmentService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IUserClassroomService,UserClasroomService>();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UCVSWPContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UCVSWPContext>(); builder.Services.AddDbContext<UCVSWPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UCVSWPDb")));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;
    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;
    // User Settings
    options.User.RequireUniqueEmail = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "adminDetails",
    pattern: "Admin/Edit/{id?}",
    defaults: new { controller = "Admin", action = "Edit" });

app.MapRazorPages();

app.Run();
