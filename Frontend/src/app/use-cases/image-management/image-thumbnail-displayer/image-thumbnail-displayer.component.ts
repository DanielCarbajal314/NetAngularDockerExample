import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RegisteredImage } from '../services/http/dto/registered-image.dto';

@Component({
  selector: 'app-image-thumbnail-displayer',
  templateUrl: './image-thumbnail-displayer.component.html',
  styleUrls: ['./image-thumbnail-displayer.component.scss']
})
export class ImageThumbnailDisplayerComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ImageThumbnailDisplayerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: RegisteredImage
  ) { }

  ngOnInit(): void {
  }

  onDoneClick(): void {
    this.dialogRef.close();
  }

}
