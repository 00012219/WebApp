import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignDirectorComponent } from './assign-director.component';

describe('AssignDirectorComponent', () => {
  let component: AssignDirectorComponent;
  let fixture: ComponentFixture<AssignDirectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignDirectorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssignDirectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
