import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ThuocPage } from './thuoc.page';

describe('ThuocPage', () => {
  let component: ThuocPage;
  let fixture: ComponentFixture<ThuocPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ThuocPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
