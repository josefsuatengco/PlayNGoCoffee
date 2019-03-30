import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';
import { forEach } from '@angular/router/src/utils/collection';
import * as CanvasJS from 'src/app/scripts/canvasjs.min';

@Component({
  selector: 'app-ingredient-stocks',
  templateUrl: './ingredient-stocks.component.html',
  styleUrls: ['./ingredient-stocks.component.css']
})
export class IngredientStocksComponent implements OnInit {
  public ingredientStock: any;
  public recipes: any;
  public recipeIngredients: any;
  public locationId: any;

  constructor(private activatedRoute: ActivatedRoute, private dataService: DataService, private router: Router) {
    this.locationId = activatedRoute.snapshot.params['id'];

    this.dataService.getIngredientStocksByLocationId(this.locationId).subscribe(res => { 
      this.ingredientStock = res;
      this.loadChart();
    });

    this.dataService.getAllRecipesDataModel().subscribe(res => { this.recipes = res; });

    this.dataService.getAllRecipeIngredientsDataModel().subscribe(res => { this.recipeIngredients = res; });

  }

  public onClick(recipeId: number, name: string) {
    if (confirm("Make " + name + "?")) {
      let nonNegStock: boolean = true;
      let updatedStock: any;
      let ingredientsOnStock = this.ingredientStock.map(x => Object.assign({}, x));
      let ingredientOnStock: any;
      let stockToSave: any;
      let index: any;      
      
      if (ingredientsOnStock.length === 0) {
        alert("Not enough stock to make coffee.");
      }
      else {
        this.recipeIngredients.filter(a => a.recipeId === recipeId)
          .forEach(function (recipeIngredient) {
            ingredientOnStock = ingredientsOnStock.filter(b => b.ingredientId === recipeIngredient.ingredientId).map(x => Object.assign({}, x))[0];
            index = ingredientsOnStock.findIndex(x => x.ingredientId === recipeIngredient.ingredientId);

            if ((ingredientOnStock.unit - recipeIngredient.unit) < 0) {
              nonNegStock = false;
            }
            else {
              ingredientsOnStock[index].unit = ingredientOnStock.unit - recipeIngredient.unit;
            }
          });

        if (nonNegStock) {
          this.dataService.updateStock(this.locationId, ingredientsOnStock, recipeId);
        }
        else {
          alert("Not enough stock to make coffee.");
        }
      }
    }
  }

  public loadChart(){    
    let dataPoints = [];
    this.ingredientStock.forEach(function (stock) {
      dataPoints.push({y:stock.unit, label:stock.ingredient.ingredientName});
    });

    let chart = new CanvasJS.Chart("stockChart", {
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: "Remaining Stock"
      },
      data: [{
        type: "column",
        dataPoints: dataPoints
      }]
    });
      
    chart.render();
  }

  ngOnInit() {        
  }
}
