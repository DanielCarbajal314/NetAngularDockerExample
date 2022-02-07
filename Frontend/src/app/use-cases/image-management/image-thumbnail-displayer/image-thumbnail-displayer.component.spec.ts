import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageThumbnailDisplayerComponent } from './image-thumbnail-displayer.component';

describe('ImageThumbnailDisplayerComponent', () => {
  let component: ImageThumbnailDisplayerComponent;
  let fixture: ComponentFixture<ImageThumbnailDisplayerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImageThumbnailDisplayerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImageThumbnailDisplayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
