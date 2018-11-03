import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ProductsComponent } from './components/products/products.component';
import { ToysComponent } from './components/products/toys/toys.component';
import { SportComponent } from './components/products/sport/sport.component';
import { ElectricbikeAllegroComponent } from './components/products/sports/electricbike-allegro/electricbike-allegro.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ProductsComponent,
        ToysComponent,
        SportComponent,
        ElectricbikeAllegroComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent,
            children:[
              {
                path: 'products/car',
                component: ProductsComponent
              },
              {
                path: 'counter',
                component: CounterComponent
              }]},
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'products/car', component: ProductsComponent},
            { path: 'toys', component: ToysComponent},
            { path: 'sport', component: SportComponent},
            { path: 'sports/electricbike-Allegro', component: ElectricbikeAllegroComponent},
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
