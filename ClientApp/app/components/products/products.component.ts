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
  private products: Product[];
  private showNew: boolean;
  private submitType: String;
  private productModel: Product;
  private selectedRow: number;
  private _route: ActivatedRoute;

  constructor(route: ActivatedRoute, private _productService: ProductService) { 
    this._route = route;
  }

  ngOnInit() {
    this.productCategory = this.getProductCategory();
    this.syncData();
    this.products = this.getProductByCategory();
  }

  onEdit(product: Product){
    this.showNew = true;
    this.submitType = "Update";
    this.selectedRow = product.number;
    this.productModel = new Product();
    this.selectedRow = 0;
    this.productModel = product;
    this.submitType = 'Update';
    this.showNew = true;
  }

  onSave(){
    if (this.submitType === 'Save') {
      this._productService.CreateNewProduct(this.productModel);
    } else {
      this.products[this.selectedRow].name = this.productModel.name;
      this.products[this.selectedRow].description = this.productModel.description;
      this.products[this.selectedRow].category = this.productModel.category;
      this.products[this.selectedRow].price = this.productModel.price;
      this._productService.UpdateProduct(this.productModel);
    }
    this.syncData();
    if(this.productCategory != "products"){
      this.products = this.products.filter(p => p.category == this.productCategory);
    }
    this.showNew = false;
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
    this.showNew = false;
  }

  syncData() {
    setTimeout(() => {
      this._productService.GetProducts().subscribe( data => {
        this.products = data;
      });
      },100);
  }

  getProductCategory(): string {   
    if(this._route.snapshot.url.length > 1){
      return this.productCategory = this._route.snapshot.url[1].path;
    }
    return this._route.snapshot.url[0].path;
  }

  getProductByCategory(): Product[]{
    if(this.productCategory != "products"){
      return this.products = this.products.filter(p => p.category == this.productCategory);
    }
    return this.products;
  }
}
