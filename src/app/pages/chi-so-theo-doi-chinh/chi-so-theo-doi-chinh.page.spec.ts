import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ChiSoTheoDoiChinhPage } from './chi-so-theo-doi-chinh.page';

describe('ChiSoTheoDoiChinhPage', () => {
  let component: ChiSoTheoDoiChinhPage;
  let fixture: ComponentFixture<ChiSoTheoDoiChinhPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ChiSoTheoDoiChinhPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
