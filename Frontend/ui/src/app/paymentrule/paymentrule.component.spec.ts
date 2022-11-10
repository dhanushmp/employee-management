import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentruleComponent } from './paymentrule.component';

describe('PaymentruleComponent', () => {
  let component: PaymentruleComponent;
  let fixture: ComponentFixture<PaymentruleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentruleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaymentruleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
