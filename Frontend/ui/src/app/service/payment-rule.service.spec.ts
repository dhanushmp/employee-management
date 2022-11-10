import { TestBed } from '@angular/core/testing';

import { PaymentRuleService } from './payment-rule.service';

describe('PaymentRuleService', () => {
  let service: PaymentRuleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PaymentRuleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
