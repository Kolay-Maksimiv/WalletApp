import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailTransctionModelComponent } from './detail-transction-model.component';

describe('DetailTransctionModelComponent', () => {
  let component: DetailTransctionModelComponent;
  let fixture: ComponentFixture<DetailTransctionModelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailTransctionModelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailTransctionModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
