import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BaseComponent } from 'src/app/shared/components/base-component';
import { ImageThumbnailDisplayerComponent } from './image-thumbnail-displayer/image-thumbnail-displayer.component';
import { ImageViewStateService } from './services/image-view-state.service';

@Component({
  selector: 'app-image-management',
  templateUrl: './image-management.component.html',
  styleUrls: ['./image-management.component.scss']
})
export class ImageManagementComponent extends BaseComponent implements OnInit {

  constructor(
    private imageViewStateService: ImageViewStateService,
    public dialog: MatDialog) { 
    super();
  }

  ngOnInit(): void {
    this.unsubscribeOnDestroy(this.imageViewStateService.$displayAllSizesEvent.subscribe(image => {
      const dialogRef = this.dialog.open(ImageThumbnailDisplayerComponent, {
        width: '100%',
        height: '90%',
        data: image
      });
    }));
  }

}
