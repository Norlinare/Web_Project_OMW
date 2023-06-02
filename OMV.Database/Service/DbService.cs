namespace OMV.Video.Database.Service
{
    public class DbService<T>
    {
        public T? Data { get; set; }
        public bool Sucess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
