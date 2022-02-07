using Microsoft.AspNetCore.SignalR;
using Photo.Domain.Actions.Query.ListImages;
using Photo.Domain.External.Notification;

namespace Photo.Infrastructure.SignalR
{
    public class ProcessedImageHub : Hub<IProcessedImage>
    {
        public async Task NotifyImageProcessedToClients(ListImagesQueryResponseItem data)
        {
            await Clients.All.ImageProcessed(data);
        }
    }
}