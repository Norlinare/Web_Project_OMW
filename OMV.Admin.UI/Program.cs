var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddHttpClient<VideoHttpClient>(client =>
client.BaseAddress = new Uri("https://localhost:6001/api/"));
ConfigureAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

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