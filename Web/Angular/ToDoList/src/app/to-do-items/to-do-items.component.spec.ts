import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToDoItemsComponent } from './to-do-items.component';

describe('ToDoItemsComponent', () => {
  let component: ToDoItemsComponent;
  let fixture: ComponentFixture<ToDoItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToDoItemsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToDoItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
