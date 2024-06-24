import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <h1>Welcome to {{title}}!</h1>
    <p>
      <a [routerLink]="'/products'">Show products</a>
    </p>
    <router-outlet/>
  `,
  styles: [],
})
export class AppComponent {
  title = 'frontend';
}
