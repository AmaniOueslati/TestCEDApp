import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternDetailComponent } from './Intern-detail.component';

describe('InternDetailComponent', () => {
  let component: InternDetailComponent;
  let fixture: ComponentFixture<InternDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InternDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InternDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
