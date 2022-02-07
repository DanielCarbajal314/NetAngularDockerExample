import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RegisteredImage } from './dto/registered-image.dto';

@Injectable({
  providedIn: 'root'
})
export class ImageSocketService {
  private hubConnection?: HubConnection;
  public readonly $registeredImageComplete : Subject<RegisteredImage> = new Subject<RegisteredImage>();

  constructor() {
    this.createConnection();
    this.startConnection();
  }

  private createConnection(){
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(environment.hubEndpoint)
      .build();
  }

  private startConnection(){
    this.hubConnection!
      .start()
      .then(() => {
        console.log('Connection started');
        this.listenToImageProcessed();
      })
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  private listenToImageProcessed(){
    this.hubConnection!.on('ImageProcessed', (data) => {
      this.$registeredImageComplete.next(data);
    });    
  }

}
