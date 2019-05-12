import Product from "./Product";

interface ProductType {
    productTypeId: number;
    name: string;
    products: Array<Product> | null;
}

export default ProductType;