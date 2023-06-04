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
        cfg.CreateMap<FilmListDTO, FilmModel>();
        cfg.CreateMap<FilmDTO, FilmModel>().ReverseMap();
        cfg.CreateMap<FilmCreateDTO, FilmModel>().ForMember(dest => dest.Id, src => src.Ignore()).ReverseMap();
        cfg.CreateMap<FilmEditDTO, FilmModel>().ReverseMap();

        cfg.CreateMap<FilmEditDTO, SimilarFilmModel>();

        cfg.CreateMap<GenreDTO, GenreModel>().ReverseMap();
        cfg.CreateMap<GenreCreateDTO, GenreModel>().ReverseMap();
        cfg.CreateMap<GenreEditDTO, GenreModel>().ReverseMap();

        cfg.CreateMap<DirectorDTO, DirectorModel>().ReverseMap();
        cfg.CreateMap<DirectorCreateDTO, DirectorModel>().ReverseMap();
        cfg.CreateMap<DirectorEditDTO, DirectorModel>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}