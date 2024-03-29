using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services.Files;
using Microsoft.AspNetCore.Http;

namespace Infra.Files
{
    public class FileManager : IFileManager
    {

        private void CreatePath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public async Task<string> SavePetPicture(IFormFile file, string petId)
        {
            try
            {
                var path = Path.Combine($"wwwroot/pet-reported/{petId}");

                CreatePath(path);

                var nameFile = "picture_pet.jpg";
                path = Path.Combine(path,nameFile);

                using var stream = System.IO.File.Create(path);
                await file.CopyToAsync(stream);
                return path.Replace("wwwroot", "");
            }
            catch(Error ex)
            {
                throw new Error(ErrorReason.CreateFile, "Error al guardar el archivo");

            }


        }
    }
}