import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ThongTinXetNghiemPage } from './ket-qua-xet-nghiem.page';

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
