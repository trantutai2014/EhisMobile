import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ThongTinTiemChungPage } from './thong-tin-tiem-chung.page';

describe('ThongTinTiemChungPage', () => {
  let component: ThongTinTiemChungPage;
  let fixture: ComponentFixture<ThongTinTiemChungPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ThongTinTiemChungPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
