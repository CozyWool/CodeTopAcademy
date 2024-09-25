import {Component} from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {ToDoItemsComponent} from "./to-do-items/to-do-items.component";
import {UpperCasePipe} from "@angular/common";
import {PipesTestComponent} from "./pipes-test/pipes-test.component";
import {HomeComponent} from "./home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToDoItemsComponent, UpperCasePipe, PipesTestComponent, RouterLink, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'ToDoList';
}
