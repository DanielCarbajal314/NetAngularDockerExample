import { TestBed } from '@angular/core/testing';

import { ImageSocketService } from './image-socket.service';

describe('ImageSocketService', () => {
  let service: ImageSocketService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageSocketService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
