using Photo.Domain.External.File.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.External.File
{
    public interface IFileRepository
    {
        Task<ImageToSaveResponse> SaveFile(ImageToSaveRequest request);
        Task<byte[]> GetFileByName(string FileName);
    }
}
