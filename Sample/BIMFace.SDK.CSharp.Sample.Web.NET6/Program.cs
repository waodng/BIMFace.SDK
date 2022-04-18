using BIMFace.SDK.CSharp.Constants;
using BIMFace.SDK.CSharp.Sample.Web.NET6;

{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    /* ASP.NET Core 中的 Razor 文件编译，参考：https://docs.microsoft.com/zh-cn/aspnet/core/mvc/views/view-compilation?view=aspnetcore-6.0&tabs=visual-studio */
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

    // 以下逻辑为配置BIMFACE开发者信息
    GlobalContext.BIMFaceConfig = builder.Configuration.GetSection("BIMFaceConfig").Get<BIMFaceConfig>();
    BIMFaceConstants.API_HOST = GlobalContext.BIMFaceConfig.BIMFACE_API_HOST;
    BIMFaceConstants.FILE_HOST = GlobalContext.BIMFaceConfig.BIMFACE_FILE_HOST;

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}