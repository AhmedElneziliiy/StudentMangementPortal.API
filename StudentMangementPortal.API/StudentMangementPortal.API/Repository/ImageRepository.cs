namespace StudentMangementPortal.API.Repository
{
    public class ImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath=Path.Combine(Directory.GetCurrentDirectory(),@"Resources\Images",fileName);
            using Stream fileStream=new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            
            return GetRelativePath(fileName);
        }
        private string GetRelativePath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
