import { Component, OnInit, Input, Testability } from '@angular/core';
import { ProductResource } from '../../model/productResource';
import 'rxjs/add/operator/map';
import { ActivatedRoute} from '@angular/router';
import { ProductService } from '../../service/product.service';
import { CategoryResource } from '../../model/categoryResource';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  @Input() productCategory: string;
  private productCategories: CategoryResource[];
  private products: ProductResource[];
  private showNew: boolean;
  private submitType: String;
  private productModel: ProductResource;
  private route: ActivatedRoute;
  private error: boolean;

  constructor(route: ActivatedRoute, private _productService: ProductService) { 
    this.route = route;
  }

  ngOnInit() {
    this.productCategory = this.getProductCategory();
    this.syncData();
  }

  onEdit(product: ProductResource){
    this.showNew = true;
    this.submitType = "Update";
    this.productModel = new ProductResource();
    this.productModel = product;
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
    this.productModel = new ProductResource();
    this.submitType = 'Save';
    this.showNew = true;
  }

  onDelete(product: ProductResource) {
    this._productService.Delete(product)
    this.syncData();
  }

  onCancel() {
    this.error = false;
    this.showNew = false;
  }

  syncData() {
    setTimeout(() => {
      this._productService.GetProducts().subscribe( data => {
        this.products = this.getProductByCategory(data);
      });
      },100);

    setTimeout(() => {
      this._productService.GetCategories().subscribe( data => {
        this.productCategories = data as CategoryResource[];
        // var test: string[];
        
        // productResourceCategories.forEach(function(element) {         
        //   console.log(element.categoryName);
        //   test.push(element.categoryName);
        // });
      });
      },100);
  }

  getProductByCategory(products : ProductResource[]): ProductResource[]{
    if(this.productCategory != "products"){
      return products.filter(p => p.category == this.productCategory);
    }
    return products;
  }

  getProductCategory(): string {   
    if(this.route.snapshot.url.length > 1){
      return this.productCategory = this.route.snapshot.url[1].path;
    }
    return this.route.snapshot.url[0].path;
  }

}
