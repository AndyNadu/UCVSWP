namespace UCVSWP.Repositories.Interfaces
{
    public interface IFileService
    {
        Tuple<int, string> SaveFile(IFormFile imageFile);
        public bool DeleteFile(string imageFileName);
    }
}
