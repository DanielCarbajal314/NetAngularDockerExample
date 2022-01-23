using Photo.Domain.Persistency;

namespace Photo.BusinessLogic.Handlers
{
    public abstract class BaseHandler
    {
        protected IUnitOfWork _unitOfWork;

        public BaseHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}
