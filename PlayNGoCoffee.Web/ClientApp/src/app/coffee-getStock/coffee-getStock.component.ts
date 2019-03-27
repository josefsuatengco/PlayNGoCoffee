import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-coffee-getStock',
  templateUrl: './coffee-getStock.component.html'
})
export class CoffeeGetStockComponent {
  public ingredientsOnStock: IngredientDataModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IngredientDataModel[]>(baseUrl + 'api/Coffee/GetStock').subscribe(result => {
      this.ingredientsOnStock = result;
    }, error => console.error(error));
  }
}

interface IngredientDataModel {
  id: number;
  ingredientName: string;
  stock: number;
  description: string;
  locationId: number;  
}
