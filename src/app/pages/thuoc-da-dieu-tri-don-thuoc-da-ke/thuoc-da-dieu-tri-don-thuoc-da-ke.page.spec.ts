import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ThuocDaDieuTriDonThuocDaKePage } from './thuoc-da-dieu-tri-don-thuoc-da-ke.page';

describe('ThuocDaDieuTriDonThuocDaKePage', () => {
  let component: ThuocDaDieuTriDonThuocDaKePage;
  let fixture: ComponentFixture<ThuocDaDieuTriDonThuocDaKePage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ThuocDaDieuTriDonThuocDaKePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
