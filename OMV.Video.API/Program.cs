

using OMV.Common.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices();
ConfigureAutoMapper();

builder.Services.AddDbContext<OMVContext>(
options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("OMVConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        //DirectorDTOs
        cfg.CreateMap<Director, DirectorDTO>()
        .ReverseMap();


        cfg.CreateMap<DirectorCreateDTO, Director>()
        .ForMember(dest => dest.Films, src => src.Ignore());

        cfg.CreateMap<DirectorEditDTO, Director>()
        .ForMember(dest => dest.Films, src => src.Ignore());

        //FilmDTOs
        cfg.CreateMap<Film, FilmDTO>()
        .ReverseMap();

        cfg.CreateMap<FilmCreateDTO, Film>()
        .ForMember();

        cfg.CreateMap<FilmCreateDTO, Film>()



        cfg.CreateMap<FilmGenre, FilmGenreDTO>()
        .ReverseMap();

        cfg.CreateMap<Genre, GenreDTO>()
        .ReverseMap();

        cfg.CreateMap<SimilarFilm, SimilarFilmDTO>()
        .ReverseMap();
    });

    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

void ConfigureServices()
{
    builder.Services.AddCors(policy =>
    {
        policy.AddPolicy("CorsAllAccessPolicy", opt =>
            opt.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod());
    });
}