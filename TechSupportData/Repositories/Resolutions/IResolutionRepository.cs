using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Resolutions
{
    public interface IResolutionRepository
    {
        Resolution AddResolution(Resolution resolution, IFormFile file);
    }
}