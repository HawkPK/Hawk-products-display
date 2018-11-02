export class Product {
    constructor(
        public number: number = 0,
        public name: string = '',
        public description: string = '',
        public category: string = '',
        public price: number = 0.0,
        public priceWithVat: number = 0.0
    ){}
}