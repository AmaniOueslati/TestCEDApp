import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternsListComponent } from './Intern-list.component';

describe('InternsListComponent', () => {
  let component: InternsListComponent;
  let fixture: ComponentFixture<InternsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InternsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InternsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
