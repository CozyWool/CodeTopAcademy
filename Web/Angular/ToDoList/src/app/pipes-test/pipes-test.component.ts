import { Component } from '@angular/core';
import {CurrencyPipe, DecimalPipe, LowerCasePipe, PercentPipe, SlicePipe, UpperCasePipe} from "@angular/common";


@Component({
  selector: 'app-pipes-test',
  standalone: true,
  imports: [
    UpperCasePipe,
    LowerCasePipe,
    PercentPipe,
    CurrencyPipe,
    DecimalPipe,
    SlicePipe
  ],
  templateUrl: './pipes-test.component.html',
  styleUrl: './pipes-test.component.css'
})
export class PipesTestComponent {
  str = "London is the capital of Great Britain"
  num = 3.57
}
