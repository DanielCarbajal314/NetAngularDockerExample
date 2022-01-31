import { TestBed } from '@angular/core/testing';

import { ImageViewStateService } from './image-view-state.service';

describe('ImageViewStateService', () => {
  let service: ImageViewStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageViewStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
