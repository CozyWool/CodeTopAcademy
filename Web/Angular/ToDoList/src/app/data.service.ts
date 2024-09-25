import {ToDoItem} from "./ToDoItem";
import {LogService} from "./log.service";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable, of} from "rxjs";

@Injectable()
export class DataService {
  private url: string;

  constructor(private http: HttpClient, private logService: LogService) {
    this.url = 'http://localhost:5011';
  }

  async getAllItems(): Promise<Observable<ToDoItem[]>> {
    let response = await fetch(
      `${this.url}/tasks`,
      {
        method: 'get',
      })
    let data = of(await response.json());
    this.logService.write('Получены все данные')
    return data;
  };

  async addItem(item: ToDoItem): Promise<Observable<Response>> {
    let response = await fetch(
      `${this.url}/tasks`,
      {
        method: 'post',
        headers:new Headers({
          'Content-type': 'application/json'
        }),
        body: `${JSON.stringify(item)}`,
      });

    this.logService.write('Добавлен новый элемент: ' + JSON.stringify(item));
    return of(response);
  }

  async updateItem(item: ToDoItem): Promise<Observable<Response >> {
    let response = await fetch(
      `${this.url}/tasks`,
      {
        method: 'put',
        headers:new Headers({
          'Content-type': 'application/json'
        }),
        body: `${JSON.stringify(item)}`,
      });

    this.logService.write('Обновлён новый элемент: ' + JSON.stringify(item));
    return of(response);
  }

  async deleteItem(id: number): Promise<Observable<Response>> {
    let response = await fetch(
      `${this.url}/tasks`,
      {
        method: 'delete',
        headers:new Headers({
          'Content-type': 'application/json'
        }),
        body: `${JSON.stringify(id)}`,
      });

    this.logService.write('Удалён элемент: ' + id);
    return of(response);
  }

  async getItemById(id: number) {
    let response = await fetch(
      `${this.url}/tasks/${id}`,
      {
        method: 'get',
      });
    let item = await response.json() as ToDoItem;
    this.logService.write('Получён элемент: ' + JSON.stringify(item));
    return of(item);
  }
}
