using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Photo.Domain.Actions.Commands.ProcessImage;
using Photo.Domain.Actions.Query.ListImages;
using Photo.Domain.External.Notification;
using Photo.Domain.External.Queu;
using Photo.Infrastructure.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photo.BusinessLogic.Workers
{
    public class ImageProcesorService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRegisteredImageBus _registeredImageBus;
        private readonly IHubContext<ProcessedImageHub, IProcessedImage> _processedImageHub;

        public ImageProcesorService(IServiceProvider serviceProvider, IRegisteredImageBus registeredImageBus, IHubContext<ProcessedImageHub, IProcessedImage> processedImageHub)
        {
            this._serviceProvider = serviceProvider;
            this._registeredImageBus = registeredImageBus;
            this._processedImageHub = processedImageHub;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("STARTED");
            await this._registeredImageBus.Dequeue("service1", async registerEvent =>
            {
                using(var scope = this._serviceProvider.CreateScope()) 
                {
                    Console.WriteLine("Hadling thumbnail creation event");
                    try
                    {
                        IMediator mediator = scope.ServiceProvider.GetService<IMediator>();    
                        var result = await mediator.Send(new ProcessImageCommand
                        {
                            Id = registerEvent.Id,
                            FileName = registerEvent.ImageName
                        });
                        await this._processedImageHub.Clients.All.ImageProcessed(new ListImagesQueryResponseItem
                        {
                            Id = registerEvent.Id,
                            Name = result.Name,
                            LargeThumbnailURL = result.LargeThumbnailURL,
                            SmallThumbnailURL = result.SmallThumbnailURL,
                            MediumThumbnailURL = result.MediumThumbnailURL,
                            OriginalImageURL = result.OriginalImageURL,
                            Proccessed  = result.Proccessed
                        });
                        Console.WriteLine($"Small : {result.SmallThumbnailURL}");
                        Console.WriteLine($"Medium : {result.MediumThumbnailURL}");
                        Console.WriteLine($"Large : {result.LargeThumbnailURL}");
                        Console.WriteLine("Thumbnail creation event ended sucessfully");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                        Console.Error.WriteLine(ex.StackTrace);
                    }
                }
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("END");
            return Task.CompletedTask;
        }
    }
}
