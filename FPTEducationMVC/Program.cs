using BusinessLogic;
using FPTEducationMVC.Controllers;
using Services;

namespace FPTEducationMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient<IAchievementService, AchievementService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<IBlogService, BlogService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<IFeedBacksService, FeedBacksService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<IFPTHistoryService, FPTHistoryService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<IMessageService, MessageService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<ITopicService, TopicService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<ITopicCategoryService, TopicCategoryService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
            builder.Services.AddHttpClient<INewsService, NewsService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7172/");
            });
			builder.Services.AddHttpClient<HomeController>();

			// Add services to the container.
			builder.Services.AddControllersWithViews();

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

            app.Run();
        }
    }
}
