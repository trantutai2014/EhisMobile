import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LichSuBenhPage } from './lich-su-benh.page';

describe('LichSuBenhPage', () => {
  let component: LichSuBenhPage;
  let fixture: ComponentFixture<LichSuBenhPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(LichSuBenhPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
