import {Component, OnInit} from '@angular/core';
import {DataService} from "../data.service";
import {NgIf} from "@angular/common";
import {ToDoItem} from "../ToDoItem";
import {ActivatedRoute, RouterLink} from "@angular/router";
import {switchMap} from "rxjs";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {LogService} from "../log.service";

@Component({
  selector: 'app-to-do-item-details',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    FormsModule,
    RouterLink
  ],
  providers: [DataService, LogService],
  templateUrl: './to-do-item-details.component.html',
  styleUrl: './to-do-item-details.component.css'
})
export class ToDoItemDetailsComponent implements OnInit{
  isLoaded: boolean = false;
  item: ToDoItem;

  constructor( private activateRoute: ActivatedRoute, private dataService: DataService) {
  }

  async getItem(id: number) {

    this.isLoaded = false;

    (await this.dataService.getItemById(id)).subscribe({
      next: response => {
        this.item = response;
        this.isLoaded = true;
      },
      error: error => console.error(error)
    });

  }

  ngOnInit(): void {
    this.activateRoute.paramMap
      .pipe(switchMap(p => p.getAll('id')))
      .subscribe(async id => {
        await this.getItem(Number(id));
      });
  }
}
