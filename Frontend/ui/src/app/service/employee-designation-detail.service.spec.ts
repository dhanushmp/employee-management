import { TestBed } from '@angular/core/testing';

import { EmployeeDesignationDetailService } from './employee-designation-detail.service';

describe('EmployeeDesignationDetailService', () => {
  let service: EmployeeDesignationDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeDesignationDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
