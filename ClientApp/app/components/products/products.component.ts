import { Component, Inject, OnInit, Input } from '@angular/core';
import { Http, Headers, RequestOptions  } from '@angular/http';
import { Product } from '../../model/product';
import 'rxjs/add/operator/map';
import { ActivatedRoute, UrlHandlingStrategy } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  @Input() productCategory: string;
  private productCategories: string[] = ['sport','toys','electricbike-Allegro'];
  private products: Product[];
  private showNew: boolean;
  private baseUrl: String;
  private submitType: String;
  private productModel: Product;
  private selectedRow: number;
  private http: Http;
  private _route: ActivatedRoute;
  //public productCategory = "Sport";
  constructor(http: Http, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute) { 
    this.http = http;
    this.baseUrl = baseUrl;
    this._route = route;
  }

  ngOnInit() {
    //Get product category
    this.productCategory = this._route.snapshot.url[0].path;
    if(this._route.snapshot.url.length > 1){
      this.productCategory = this._route.snapshot.url[1].path;
    }
    this.http.get(this.baseUrl + 'api/Product/Products').subscribe(result => {
      console.log("Test Init " + result.text());
      this.products = result.json() as Product[];
      if(this.productCategory != "products"){
        this.products = this.products.filter(p => p.category == this.productCategory);
      }
  }, error => console.error(error));
  }

  onEdit(product: Product){
    this.showNew = true;
    this.submitType = "Update";
    this.selectedRow = product.number;
    this.productModel = new Product();
    this.selectedRow = 0;
    this.productModel = product;//Object.assign({}, this.products[this.selectedRow]);
    this.submitType = 'Update';
    this.showNew = true;
  }

  onSave(){
    if (this.submitType === 'Save') {
      this.products.push(this.productModel);
      this.http.post(this.baseUrl + 'api/Product/Create', this.productModel).subscribe(res => console.log(res), error => console.error(error));
    } else {
      this.products[this.selectedRow].name = this.productModel.name;
      this.products[this.selectedRow].description = this.productModel.description;
      this.products[this.selectedRow].category = this.productModel.category;
      this.products[this.selectedRow].price = this.productModel.price;
      this.http.post(this.baseUrl + 'api/Product/Update', this.productModel).subscribe(res => console.log(res), error => console.error(error));
    }
    this.showNew = false;
  }

  onNew() {
    this.productModel = new Product();
    this.submitType = 'Save';
    this.showNew = true;
  }

  onDelete(product: Product) {
    var index = this.products.indexOf(product);
    this.products.splice(index, 1);
    this.http.delete(this.baseUrl + 'api/Product/Delete',  new RequestOptions({body: product}))
    .subscribe(res => console.log(res), error => console.error(error));
  }

  onCancel() {
    this.showNew = false;
  }
}
