import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../model/product';
import 'rxjs/add/operator/map';
import { ActivatedRoute} from '@angular/router';
import { ProductService } from '../../service/product.service';

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
  private submitType: String;
  private productModel: Product;
  private _route: ActivatedRoute;
  private error: boolean;

  constructor(route: ActivatedRoute, private _productService: ProductService) { 
    this._route = route;
  }

  ngOnInit() {
    this.productCategory = this.getProductCategory();
    this.syncData();
  }

  onEdit(product: Product){
    this.showNew = true;
    this.submitType = "Update";
    this.productModel = new Product();
    this.submitType = 'Update';
    this.showNew = true;
  }

  onSave(){
    if (this.submitType === 'Save') {
      if(this._productService.IsArticleExist(this.productModel.articleNo)){
        this.error = true;
      } else {
        this._productService.CreateNewProduct(this.productModel);
        this.syncData();
        this.error = false;
        this.showNew = false;
      }
    } else {
          this._productService.UpdateProduct(this.productModel);
          this.syncData();
          this.error = false;
          this.showNew = false;
      }
  }

  onNew() {
    this.productModel = new Product();
    this.submitType = 'Save';
    this.showNew = true;
  }

  onDelete(product: Product) {
    this._productService.Delete(product)
    this.syncData();
  }

  onCancel() {
    this.error = false;
    this.showNew = false;
  }


  test(articleNo: string) {
    setTimeout(() => {
      this._productService.GetProducts().subscribe( data => {
        this.products = this.getProductByCategory(data);
      });
      },100);
  }

  syncData() {
    setTimeout(() => {
      this._productService.GetProducts().subscribe( data => {
        this.products = this.getProductByCategory(data);
      });
      },100);
  }


  getProductByCategory(products : Product[]): Product[]{
    if(this.productCategory != "products"){
      return products.filter(p => p.category == this.productCategory);
    }
    return products;
  }

  getProductCategory(): string {   
    if(this._route.snapshot.url.length > 1){
      return this.productCategory = this._route.snapshot.url[1].path;
    }
    return this._route.snapshot.url[0].path;
  }

}
