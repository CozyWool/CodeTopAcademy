import { Routes } from '@angular/router';
import {HomeComponent} from "./home.component";
import {AboutComponent} from "./about.component";
import {NotFoundComponent} from "./not-found.component";
import {ToDoItemDetailsComponent} from "./to-do-item-details/to-do-item-details.component";
import {AppComponent} from "./app.component";
import {ToDoItemsComponent} from "./to-do-items/to-do-items.component";

export const routes: Routes = [
  {path: '', component: ToDoItemsComponent},
  {path: 'about', component: AboutComponent},
  {path: 'to-do-item-detail/:id', component: ToDoItemDetailsComponent},
  {path: '**', component: NotFoundComponent},
];
