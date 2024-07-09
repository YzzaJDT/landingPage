    using Microsoft.EntityFrameworkCore;
    using ReactASPCrud.Model;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<StudentDBContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
    });

    builder.Services.AddCors(options => 
    {
        options.AddDefaultPolicy(builder => 
        {
            builder.AllowAnyOrigin()
                   .WithOrigins("https://localhost:7192")
                   .SetIsOriginAllowed(origin => true)
                   .AllowCredentials()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });    

    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseCors();
 app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
