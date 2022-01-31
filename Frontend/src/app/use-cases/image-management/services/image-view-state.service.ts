import { Injectable } from '@angular/core';
import { ReplaySubject, Subject } from 'rxjs';
import { RegisteredImage } from './http/dto/registered-image.dto';
import { ImageHttpService } from './http/image-http.service';

@Injectable({
  providedIn: 'root'
})
export class ImageViewStateService {
  $registerImages : Subject<RegisteredImage[]> = new ReplaySubject(1);

  constructor(private imageHttpService: ImageHttpService) { }

  refreshImages(){
    this.imageHttpService.getAllImage().subscribe(images => this.$registerImages.next(images));
  }

}
