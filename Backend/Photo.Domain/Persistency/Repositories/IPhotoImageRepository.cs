using Photo.Domain.Persistency.Common;
using Photo.Domain.Entities;
using System.Threading.Tasks;

namespace Photo.Domain.Persistency.Repositories
{
    public interface IPhotoImageRepository : IRepository<PhotoImage>
    {
        Task<bool> SignatureExist(string signature);
    }
}
