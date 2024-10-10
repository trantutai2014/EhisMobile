import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DotkhamPage } from './ds-dot-kham.page';

describe('DotkhamPage', () => {
  let component: DotkhamPage;
  let fixture: ComponentFixture<DotkhamPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(DotkhamPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
