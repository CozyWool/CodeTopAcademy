import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToDoItemDetailsComponent } from './to-do-item-details.component';

describe('ToDoItemDetailsComponent', () => {
  let component: ToDoItemDetailsComponent;
  let fixture: ComponentFixture<ToDoItemDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToDoItemDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToDoItemDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
