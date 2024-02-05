import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrawflowComponent } from './drawflow.component';

describe('DrawflowComponent', () => {
  let component: DrawflowComponent;
  let fixture: ComponentFixture<DrawflowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DrawflowComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DrawflowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
