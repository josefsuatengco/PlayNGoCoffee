import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { CoreModule } from './core/core.module';
import { IngredientStocksComponent } from './pages/ingredient-stocks/ingredient-stocks.component';
import { NavMenuComponent } from './pages/nav-menu/nav-menu.component';
import { OrderHistoryComponent } from './pages/order-history/order-history.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    IngredientStocksComponent,
    NavMenuComponent,
    OrderHistoryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CoreModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'order-history', component: OrderHistoryComponent, pathMatch: 'full' },
      { path: 'location/:id', component: IngredientStocksComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
