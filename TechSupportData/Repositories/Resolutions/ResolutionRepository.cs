using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Resolutions
{
    public class ResolutionRepository: IResolutionRepository
    {
        private readonly TechSupportDbContext _dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public ResolutionRepository(TechSupportDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public Resolution AddResolution(Resolution resolution, IFormFile file)
        {
            if (file != null)
            {
                resolution.AttachmentFileName = System.Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.Combine(_hostingEnvironment.WebRootPath, "resources/answers/attachments");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fullPath = Path.Combine(path, resolution.AttachmentFileName);

                FileStream outputFileStream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(outputFileStream);
            }
            
            EntityEntry<Resolution> entry = _dbContext.Resolutions.Add(resolution);
            _dbContext.SaveChanges();

            return entry.Entity;
        }
    }
}