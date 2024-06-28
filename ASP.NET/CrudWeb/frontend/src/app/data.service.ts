import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

export class ProductModel {
    constructor(public id: number,
                public name: string,
                public price: number,
                public categoryId: number,
                public categoryName: string) {
    }
}

export class CategoryModel {
    constructor(public id: number, public name: string) {
    }
}

@Injectable({
    providedIn: 'root'
})
export class DataService {
    private url = 'http://localhost:5246/api/products';

    constructor(private http: HttpClient) {
    }

    getProducts(): Observable<Array<ProductModel>> {
        return this.http.get<Array<ProductModel>>(this.url);
    }

    getCategories(): Observable<Array<CategoryModel>> {
        return this.http.get<Array<CategoryModel>>(this.url + "/categories");
    }

    getProductById(id: number) {
        return this.http.get<ProductModel>(this.url + "/" + id)
    }

    createProduct(productModel: ProductModel) {
        return this.http.post<ProductModel>(this.url, productModel)
    }


    updateProduct(productModel: ProductModel) {
        return this.http.put<ProductModel>(this.url, productModel)
    }

    deleteProduct(id: number) {
        return this.http.delete<ProductModel>(this.url + "/" + id)
    }

}
