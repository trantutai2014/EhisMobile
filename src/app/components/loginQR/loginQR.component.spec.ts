import { ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { LoginQR } from './loginQR.component';

describe('HomePage', () => {
  let component: LoginQR;
  let fixture: ComponentFixture<LoginQR>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginQR],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(LoginQR);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
