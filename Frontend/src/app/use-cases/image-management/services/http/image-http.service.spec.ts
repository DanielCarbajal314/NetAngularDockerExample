import { TestBed } from '@angular/core/testing';

import { ImageHttpService } from './image-http.service';

describe('ImageHttpService', () => {
  let service: ImageHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
