import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { ImageViewStateService } from '../services/image-view-state.service';

@Component({
  selector: 'image-form',
  templateUrl: './image-form.component.html',
  styleUrls: ['./image-form.component.scss']
})
export class ImageFormComponent implements OnInit {
  fileControl: FormControl = new FormControl(null);
  isUploadingFile: Observable<boolean> | null = null;

  constructor(private imageViewStateService: ImageViewStateService) { }

  ngOnInit(): void {
    this.isUploadingFile = this.imageViewStateService.$isUploadingFile;
  }

  uploadFile(){
    if(this.fileControl.value) {
      const fileContent = this.fileControl.value._files[0];
      const fileName = fileContent.name;
      this.imageViewStateService.uploadImage({
        fileName,
        fileContent
      });
      this.fileControl.setValue(null);
    }
  }

}
