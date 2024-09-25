import {Component, OnInit} from '@angular/core';
import {ToDoItem} from '../ToDoItem';
import {NgFor, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {DataService} from "../data.service";
import {LogService} from "../log.service";
import {Router, RouterLink} from "@angular/router";

@Component({
  selector: 'app-to-do-items',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule, RouterLink],
  providers: [DataService, LogService],
  templateUrl: './to-do-items.component.html',
  styleUrl: './to-do-items.component.css'
})
export class ToDoItemsComponent implements OnInit {
  selectedItem: ToDoItem
  newItem: ToDoItem
  isLoaded: boolean = false;
  items: ToDoItem[];

  async getAll() {
    this.isLoaded = false;
    (await this.dataService.getAllItems()).subscribe({
      next: data => {
        this.isLoaded = true;
        return this.items = data;
      },
      error: error => console.error(error)
    });
  }

  async addItem() {
    if (this.newItem == null) {
      this.newItem = new ToDoItem();
      this.newItem.id = this.items.length + 1;
      this.newItem.isComplete = false;
      return;
    }
    (await this.dataService.addItem(this.newItem)).subscribe({
      next: async response => {
        console.log(response.status);
        await this.getAll();
      },
      error: error => console.error(error)
    });
    this.newItem = null;
  }

  async updateItem() {
    (await this.dataService.updateItem(this.selectedItem)).subscribe({
      next: async response => {
        console.log(response.status);
        await this.getAll();
      },
      error: error => console.error(error)
    });
    this.selectedItem = null;
  }

  async deleteItem() {
    (await this.dataService.deleteItem(this.selectedItem.id)).subscribe({
      next: async response => {
        console.log(response.status);
        await this.getAll();
      },
      error: error => console.error(error)
    });
    this.selectedItem = null;
  }

  constructor(private dataService: DataService, private router: Router) {
    this.getAll().then(r => "");
  }

  ngOnInit(): void {

  }


  onSelect(item: ToDoItem): void {
    this.selectedItem = {id: item.id, name: item.name, isComplete: item.isComplete};
  }


  async detailItem(id: number) {
    await this.router.navigate(['/to-do-item-detail', id]);
  }
}
