import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDelailComponent } from './user-delail.component';

describe('UserDelailComponent', () => {
  let component: UserDelailComponent;
  let fixture: ComponentFixture<UserDelailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserDelailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserDelailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
