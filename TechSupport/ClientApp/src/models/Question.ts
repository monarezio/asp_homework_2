class Question {
    public productTypeId: number; //It's easier to just save the id, I am not doing any logical operations with the model so yh...
    public productId: number; //It's easier to just save the id, I am not doing any logical operations with the model so yh...
    public email : string;
    public body : string;
    public file: File | null;
    
    constructor(product_type_id: number = 0, product_id: number = 0, email: string = "", text: string = "", file: File | null = null) {
        this.productTypeId = product_type_id;
        this.productId = product_id;
        this.email = email;
        this.body = text;
        this.file = file;
    }
}

export default Question;