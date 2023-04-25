using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.ExternalServices;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace Infra.ExternalServices
{
    public class DropboxManager : IDropboxManager
    {
        private DropboxClient _dbx;

        public DropboxManager(DropboxClient dbx)
        {
            _dbx = dbx;
        }

        private Task<FileMetadata> UploadFile(string path, Stream content)
        {
            return _dbx.Files.UploadAsync(path, WriteMode.Overwrite.Instance, body: content);
        }

        public async Task<string> UploadPetPhoto(Stream content, int id, string extension )
        {
            var fileName = Guid.NewGuid().ToString();
            var path = Path.Combine("pet",id.ToString(),fileName+extension);

            var response = await UploadFile(path, content);

            return response.Name;

        }
    }
}