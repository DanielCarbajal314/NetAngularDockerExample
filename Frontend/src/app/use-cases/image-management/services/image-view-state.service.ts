import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject, Subject } from 'rxjs';
import { RegisteredImage } from './http/dto/registered-image.dto';
import { UploadImageRequest } from './http/dto/upload-image-request.dto';
import { ImageHttpService } from './http/image-http.service';
import { ImageSocketService } from './http/image-socket.service';

@Injectable({
  providedIn: 'root'
})
export class ImageViewStateService {
  private images:RegisteredImage[] = [];
  $registerImages : Subject<RegisteredImage[]> = new ReplaySubject(1);
  $isLoadingImageList : Subject<boolean> = new BehaviorSubject<boolean>(true);
  $displayAllSizesEvent : Subject<RegisteredImage> = new Subject();
  $displayImageEvent : Subject<RegisteredImage> = new Subject();
  $isUploadingFile : Subject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private imageHttpService: ImageHttpService, private imageSocketService: ImageSocketService) {
    this.listenToImageCreation();
  }

  refreshImages(){
    this.$isLoadingImageList.next(true);
    this.imageHttpService.getAllImage().subscribe(images => {
      this.images = images;
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

  uploadImage(request: UploadImageRequest){
    this.$isUploadingFile.next(true);
    this.imageHttpService.uploadImage(request).subscribe(uploadedFile => {
      this.$isUploadingFile.next(false);
      this.$registerImages.next([ uploadedFile, ...this.images]);
    })
  }

  private listenToImageCreation(){
    this.imageSocketService.$registeredImageComplete.subscribe(image => {
      const otherImages = this.images.filter(x => x.id !== image.id);
      this.images = [ image, ...otherImages ].sort((a,b) => a.id - b.id);
      this.$registerImages.next(this.images);
    })
  }
}
