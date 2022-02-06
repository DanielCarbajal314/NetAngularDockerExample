import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject, Subject } from 'rxjs';
import { RegisteredImage } from './http/dto/registered-image.dto';
import { ImageHttpService } from './http/image-http.service';

@Injectable({
  providedIn: 'root'
})
export class ImageViewStateService {
  $registerImages : Subject<RegisteredImage[]> = new ReplaySubject(1);
  $isLoadingImageList : Subject<boolean> = new BehaviorSubject<boolean>(true);
  $displayAllSizesEvent : Subject<RegisteredImage> = new Subject();
  $displayImageEvent : Subject<RegisteredImage> = new Subject();

  constructor(private imageHttpService: ImageHttpService) { }

  refreshImages(){
    this.$isLoadingImageList.next(true);
    this.imageHttpService.getAllImage().subscribe(images => {
      this.$registerImages.next(images);
      this.$isLoadingImageList.next(false);
    });
  }

  displayAllSizes(event:RegisteredImage){
    this.$displayAllSizesEvent.next(event);
  }

  displayImage(event:RegisteredImage){
    this.$displayImageEvent.next(event);
  }

}
