import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { ProductResource } from '../model/productResource';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { CategoryResource } from '../model/categoryResource';

@Injectable()
export class ProductService {

  private _baseUrl: string;
  private _productsResource: ProductResource[];
  private _categoryResource: CategoryResource[];

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this._baseUrl = baseUrl;
  }

  CreateNewProduct(productModel: ProductResource): any {
    this.http.post(this._baseUrl + 'api/Product/Create', productModel).subscribe(res => console.log(res), error => console.error(error));
  }

  GetProducts(): Observable<any> {
    return this.http.get(this._baseUrl + 'api/Product/Products').map(result => {
        this._productsResource = result.json() as ProductResource[];
        return this._productsResource});   
  }

  GetCategories(): Observable<any> {
    return this.http.get(this._baseUrl + 'api/Product/Categories').map(result => {
        this._categoryResource = result.json() as CategoryResource[];
        return this._categoryResource});   
  }

  IsArticleExist(articleNo: string){
    if(this._productsResource.filter(x => x.articleNo === articleNo).length != 0){
      return true;
    };
  return false;
}

getProductByCategory(products : ProductResource[]): ProductResource[]{
  return products;
}

  UpdateProduct(productModel: ProductResource): any {
    this.http.post(this._baseUrl + 'api/Product/Update', productModel).subscribe(res => console.log(res + "updateXXXXXXX"), error => console.error(error));
  }

  Delete(product: ProductResource): any {
    this.http.delete(this._baseUrl + 'api/Product/Delete',  new RequestOptions({body: product}))
    .subscribe(res => console.log(res), error => console.error(error));
  }
}
