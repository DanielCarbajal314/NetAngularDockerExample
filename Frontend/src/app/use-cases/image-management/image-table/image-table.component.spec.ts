import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageTableComponent } from './image-table.component';

describe('ImageTableComponent', () => {
  let component: ImageTableComponent;
  let fixture: ComponentFixture<ImageTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImageTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImageTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
