import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BenhanPage } from './benhan.page';

describe('BenhanPage', () => {
  let component: BenhanPage;
  let fixture: ComponentFixture<BenhanPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(BenhanPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
