export class Product {
    constructor(
        public articleNo: string = '',
        public name: string = '',
        public description: string = '',
        public category: string = '',
        public price: number = 0.0,
        public priceWithVat: number = 0.0
    ){}
}