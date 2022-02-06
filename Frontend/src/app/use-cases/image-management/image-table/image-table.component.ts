import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { BaseComponent } from 'src/app/shared/components/base-component';
import { RegisteredImage } from '../services/http/dto/registered-image.dto';
import { ImageViewStateService } from '../services/image-view-state.service';

@Component({
  selector: 'image-table',
  templateUrl: './image-table.component.html',
  styleUrls: ['./image-table.component.scss']
})
export class ImageTableComponent extends BaseComponent implements OnInit {
  images: Observable<RegisteredImage[]> | null = null;
  isLoading: Observable<boolean> | null = null;
  displayedColumns = ['name','proccessed', 'actions'];
  imagesSource: MatTableDataSource<RegisteredImage> = new MatTableDataSource<RegisteredImage>([]);

  constructor(private imageViewStateService: ImageViewStateService) { 
    super();
  }

  ngOnInit(): void {
    this.imageViewStateService.refreshImages();
    this.unsubscribeOnDestroy(this.imageViewStateService.$registerImages.subscribe(images=>{
      this.imagesSource = new MatTableDataSource(images);
    }))
    this.isLoading = this.imageViewStateService.$isLoadingImageList;
    this.imageViewStateService.$displayImageEvent.subscribe(console.log);
  }

  displayAllSizes(event:RegisteredImage){
    this.imageViewStateService.displayAllSizes(event);
  }

  displayImage(event:RegisteredImage){
    this.imageViewStateService.displayImage(event);
  }


}
