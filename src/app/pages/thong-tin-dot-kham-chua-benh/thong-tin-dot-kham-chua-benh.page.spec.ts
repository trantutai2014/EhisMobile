import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ThongTinDotKhamChuaBenhPage } from './thong-tin-dot-kham-chua-benh.page';

describe('ThongTinDotKhamChuaBenhPage', () => {
  let component: ThongTinDotKhamChuaBenhPage;
  let fixture: ComponentFixture<ThongTinDotKhamChuaBenhPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ThongTinDotKhamChuaBenhPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
