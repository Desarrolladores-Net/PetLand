using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.Services.Files
{
    public interface IFileManager
    {
        Task SavePetPicture(IFormFile file, string petId);
    }
}