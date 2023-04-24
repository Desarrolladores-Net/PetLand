using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.ExternalServices
{
    public interface IDropboxManager
    {
        Task<string> UploadPetPhoto(Stream content, int id, string extension);
    }
}