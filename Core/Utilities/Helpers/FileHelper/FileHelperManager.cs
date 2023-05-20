using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    // Dosya kayıt işlemi için oluşturulmuştur ve alt tarafta dosya kayıt|silme|güncelleme için atamalar yapılmıştır.
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelpers.CreatGuid();
                string filePath = guid + extension;
                string fullFilePath = Path.Combine(root, filePath);

                using (FileStream fileStream = File.Create(fullFilePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();

                    return filePath;
                }
            }

            return null;
        }
    }
}
