import { Component, Inject, OnInit } from '@angular/core';
import { Http, Headers, RequestOptions  } from '@angular/http';
import { Product } from '../../model/product';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  private products: Product[];
  private showNew: boolean;
  private baseUrl: String;
  private submitType: String;
  private productModel: Product;
  private selectedRow: number;
  private http: Http;
  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.http.get(this.baseUrl + 'api/Product/Products').subscribe(result => {
      console.log("Test Init " + result.text());
      this.products = result.json() as Product[];
  }, error => console.error(error));
  }

  onEdit(product: Product){
    /*this.http.post(this.baseUrl + 'api/Product/Update', product).subscribe(res => console.log(res), error => console.error(error));
    setTimeout(()=>{
      this.http.get(this.baseUrl + 'api/Product/Products').subscribe(result => {
        console.log("Test Edit " + result.text());
        this.products = result.json() as Product[];
      }, error => console.error(error));
    }, 100);*/
    this.showNew = true;
    this.submitType = "Update";
    this.selectedRow = product.number;
    //Init new product
    this.productModel = new Product();
    this.selectedRow = 0;
    this.productModel = product;//Object.assign({}, this.products[this.selectedRow]);
    this.submitType = 'Update';
    this.showNew = true;
  }

  onSave(){
    if (this.submitType === 'Save') {
      this.products.push(this.productModel);
    } else {
      this.products[this.selectedRow].name = this.productModel.name;
      this.products[this.selectedRow].description = this.productModel.description;
      this.products[this.selectedRow].category = this.productModel.category;
      this.products[this.selectedRow].price = this.productModel.price;
      this.http.post(this.baseUrl + 'api/Product/Update', this.productModel).subscribe(res => console.log(res), error => console.error(error));
    }
    this.showNew = false;
  }
}
