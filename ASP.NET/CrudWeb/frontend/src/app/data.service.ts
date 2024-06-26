import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ProductModel {
  id: number;
  name: string;
  price: number;
  categoryId: number;
  categoryName: string;
}

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private url = 'http://localhost:5246/api/products';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<ProductModel[]> {
    return this.http.get<ProductModel[]>(this.url, {
      headers: {
        'Access-Control-Allow-Origin': '*'
      }
    });
  }
}
