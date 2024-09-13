import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DichvuPage } from './dichvu.page';

describe('DichvuPage', () => {
  let component: DichvuPage;
  let fixture: ComponentFixture<DichvuPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(DichvuPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
