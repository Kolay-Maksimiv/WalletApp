import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailTransctionComponent } from './detail-transction.component';

describe('DetailTransctionComponent', () => {
  let component: DetailTransctionComponent;
  let fixture: ComponentFixture<DetailTransctionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailTransctionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailTransctionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
