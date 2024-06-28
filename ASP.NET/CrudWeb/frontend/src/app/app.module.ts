import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule, Routes} from '@angular/router';

import {AppComponent} from './root-app/app.component';
import {ProductsComponent} from './products/products.component';
import {NotFoundComponent} from './not-found/not-found.component';

import {DataService} from './data.service';
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async';
import {NgIf} from '@angular/common';

// определение маршрутов
const appRoutes: Routes = [
    {path: '', component: ProductsComponent},
    {path: '**', component: NotFoundComponent},
];

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        NgIf,
        RouterModule.forRoot(appRoutes),
    ],
    declarations: [
        AppComponent,
        ProductsComponent,
        NotFoundComponent,
    ],
    providers: [DataService, provideAnimationsAsync()], // регистрация сервисов
    bootstrap: [AppComponent],
})
export class AppModule {
}
