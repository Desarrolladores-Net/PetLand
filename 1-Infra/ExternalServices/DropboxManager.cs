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

        public async Task<string> UploadPetPhoto(Stream content, int id, string extension )
        {
            var path = Path.Combine("pet",id.ToString(),"avatar"+extension);

            var response = await _dbx.Files.UploadAsync(path, WriteMode.Overwrite.Instance, body: content);

            return response.Name;

        }
    }
}