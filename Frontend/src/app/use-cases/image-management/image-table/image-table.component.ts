import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseComponent } from 'src/app/shared/components/base-component';
import { RegisteredImage } from '../services/http/dto/registered-image.dto';
import { ImageViewStateService } from '../services/image-view-state.service';

@Component({
  selector: 'app-image-table',
  templateUrl: './image-table.component.html',
  styleUrls: ['./image-table.component.scss']
})
export class ImageTableComponent extends BaseComponent implements OnInit {
  images: Observable<RegisteredImage[]> | null = null;

  constructor(private imageViewStateService: ImageViewStateService) { 
    super();
  }

  ngOnInit(): void {
    this.imageViewStateService.refreshImages();
    this.images = this.imageViewStateService.$registerImages;
  }

}
