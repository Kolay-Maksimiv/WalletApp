import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTransctionModelComponent } from './delete-transction-model.component';

describe('DeleteTransctionModelComponent', () => {
  let component: DeleteTransctionModelComponent;
  let fixture: ComponentFixture<DeleteTransctionModelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteTransctionModelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteTransctionModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
