import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import {CategoryModel, DataService, ProductModel} from '../data.service';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    providers: [DataService]
})
export class ProductsComponent implements OnInit {
    @ViewChild("readOnlyTemplate", {static: false}) readOnlyTemplate: TemplateRef<any> | null = null;
    @ViewChild("editTemplate", {static: false}) editTemplate: TemplateRef<any> | null = null;

    products: Array<ProductModel>;
    editedProduct: ProductModel | null = null;
    categories: Array<CategoryModel>;
    isNewRecord: boolean = false;
    statusMessage: string = "";
    detailedProduct: ProductModel | null = null;

    constructor(private dataService: DataService) {
        this.products = new Array<ProductModel>();
        this.categories = new Array<CategoryModel>();
    }

    ngOnInit(): void {
        this.loadData();
    }

    private loadData() {
        this.dataService
            .getCategories()
            .subscribe((data: Array<CategoryModel>) => {
                this.categories = data;
            });

        return this.dataService
            .getProducts()
            .subscribe((data: Array<ProductModel>) => {
                this.products = data;
            });
    }

    addProduct() {
        this.editedProduct = new ProductModel(0, "", 0, 0, "");
        this.products.push(this.editedProduct);
        this.isNewRecord = true;
    }

    editProduct(product: ProductModel) {
        this.editedProduct = new ProductModel(product.id, product.name, product.price, product.categoryId, product.categoryName);
    }

    saveProduct() {
        if (this.isNewRecord) {
            this.dataService.createProduct(this.editedProduct as ProductModel).subscribe(_ => {
                this.statusMessage = "Данные успешно добавлены",
                    this.loadData()
            })
        } else {
            this.dataService.updateProduct(this.editedProduct as ProductModel).subscribe(_ => {
                this.statusMessage = "Данные успешно обновлены",
                    this.loadData();
            })
        }

        this.editedProduct = null;
    }

    cancel() {
        if (this.isNewRecord) {
            this.products.pop();
            this.isNewRecord = false;
        }
        this.editedProduct = null;
    }

    deleteProduct(product: ProductModel) {
        this.dataService.deleteProduct(product.id).subscribe(_ => {
            this.statusMessage = "Данные успешно удалены",
                this.loadData();
        });

    }

    loadTemplate(product: ProductModel) {
        if (this.editedProduct && this.editedProduct.id == product.id) {
            return this.editTemplate;
        }
        return this.readOnlyTemplate;
    }

    detailProduct(id: number) {
        this.dataService
            .getProductById(id)
            .subscribe(data => this.detailedProduct = data);
        console.log(this.detailedProduct);
    }
}
