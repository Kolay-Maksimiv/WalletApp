import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTransctionModelComponent } from './create-transction-model.component';

describe('CreateTransctionModelComponent', () => {
  let component: CreateTransctionModelComponent;
  let fixture: ComponentFixture<CreateTransctionModelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateTransctionModelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateTransctionModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
