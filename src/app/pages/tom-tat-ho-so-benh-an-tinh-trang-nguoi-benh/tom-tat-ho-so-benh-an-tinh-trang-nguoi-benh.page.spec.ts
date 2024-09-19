import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TomTatHoSoBenhAnTinhTrangNguoiBenhPage } from './tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.page';

describe('TomTatHoSoBenhAnTinhTrangNguoiBenhPage', () => {
  let component: TomTatHoSoBenhAnTinhTrangNguoiBenhPage;
  let fixture: ComponentFixture<TomTatHoSoBenhAnTinhTrangNguoiBenhPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(TomTatHoSoBenhAnTinhTrangNguoiBenhPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
