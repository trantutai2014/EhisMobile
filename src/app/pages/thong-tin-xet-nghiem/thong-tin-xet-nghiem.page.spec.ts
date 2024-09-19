import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ThongTinXetNghiemPage } from './thong-tin-xet-nghiem.page';

describe('ThongTinXetNghiemPage', () => {
  let component: ThongTinXetNghiemPage;
  let fixture: ComponentFixture<ThongTinXetNghiemPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ThongTinXetNghiemPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
