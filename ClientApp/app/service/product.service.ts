import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { Product } from '../model/product';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProductService {

  private _baseUrl: string;

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this._baseUrl = baseUrl;
  }

  CreateNewProduct(productModel: Product): any {
    this.http.post(this._baseUrl + 'api/Product/Create', productModel).subscribe(res => console.log(res), error => console.error(error));
  }

  GetProducts(): Observable<any> {
    return this.http.get(this._baseUrl + 'api/Product/Products').map(result => {
        return result.json() as Product[];});   
  }

  UpdateProduct(productModel: Product): any {
    this.http.post(this._baseUrl + 'api/Product/Update', productModel).subscribe(res => console.log(res + "updateXXXXXXX"), error => console.error(error));
  }

  Delete(product: Product): any {
    this.http.delete(this._baseUrl + 'api/Product/Delete',  new RequestOptions({body: product}))
    .subscribe(res => console.log(res), error => console.error(error));
  }
}
