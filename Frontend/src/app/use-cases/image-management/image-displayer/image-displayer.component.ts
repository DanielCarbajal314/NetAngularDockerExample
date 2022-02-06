import { Component, OnInit } from '@angular/core';
import { map, Observable, ReplaySubject, Subject } from 'rxjs';
import { ImageViewStateService } from '../services/image-view-state.service';

@Component({
  selector: 'image-displayer',
  templateUrl: './image-displayer.component.html',
  styleUrls: ['./image-displayer.component.scss']
})
export class ImageDisplayerComponent implements OnInit {
  url: Subject<string> = new ReplaySubject<string>(); 
  name: Subject<string> = new ReplaySubject<string>(); 

  constructor(private imageViewStateService: ImageViewStateService) { }

  ngOnInit(): void {
    const diplayEvent = this.imageViewStateService.$displayImageEvent;
    diplayEvent.pipe(map(x => x.originalImageURL)).subscribe(this.url);
    diplayEvent.pipe(map(x => x.name)).subscribe(this.name);
  }

}
