using Demo1.Bll;

namespace Demo1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<Istudent,StudentBll>();
            builder.Services.AddSession();
            var app = builder.Build();

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("before : hello , welcome \n\n");
            //    await next();
            //    await context.Response.WriteAsync("after : hello welcome");
            //}
            //);
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("next : hello , welcome\n\n");
            //});


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
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}