import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IngredientStocksComponent } from './ingredient-stocks.component';

describe('IngredientStocksComponent', () => {
  let component: IngredientStocksComponent;
  let fixture: ComponentFixture<IngredientStocksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IngredientStocksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IngredientStocksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
