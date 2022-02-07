using Photo.Domain.Actions.Query.ListImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.External.Notification
{
    public interface IProcessedImage
    {
        Task ImageProcessed(ListImagesQueryResponseItem currentTime);
    }
}
