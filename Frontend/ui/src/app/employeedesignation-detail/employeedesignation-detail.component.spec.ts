import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeedesignationDetailComponent } from './employeedesignation-detail.component';

describe('EmployeedesignationDetailComponent', () => {
  let component: EmployeedesignationDetailComponent;
  let fixture: ComponentFixture<EmployeedesignationDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeedesignationDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeedesignationDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
