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
builder.Services.AddScoped<IDbService, DbService>();

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

        cfg.CreateMap<Director, DirectorDTO>()
        .ForMember(dest => dest.Films, src => src.Ignore());

        cfg.CreateMap<DirectorCreateDTO, Director>()
        .ForMember(dest => dest.Films, src => src.Ignore());

        cfg.CreateMap<DirectorEditDTO, Director>()
        .ForMember(dest => dest.Films, src => src.Ignore());

        cfg.CreateMap<DirectorEditDTO, Director>()
        .ForMember(dest => dest.Films, src => src.Ignore());

        cfg.CreateMap<Film, FilmDTO>();


        cfg.CreateMap<FilmCreateDTO, Film>();
        cfg.CreateMap<FilmEditDTO, Film>();

        cfg.CreateMap<FilmEditDTO, Film>();
        cfg.CreateMap<Film, FilmListDTO>().ReverseMap();


        cfg.CreateMap<Genre, GenreDTO>();
        cfg.CreateMap<GenreCreateDTO, Genre>()
            .ForMember(dest => dest.Films, src => src.Ignore());
        cfg.CreateMap<GenreEditDTO, Genre>()
            .ForMember(dest => dest.Films, src => src.Ignore());
        cfg.CreateMap<GenreEditDTO, Genre>()
            .ForMember(dest => dest.Films, src => src.Ignore());



        cfg.CreateMap<FilmGenreDTO, FilmGenre>();
        cfg.CreateMap<SimilarFilmDTO, SimilarFilm>().ReverseMap();


    })
    {

    };
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