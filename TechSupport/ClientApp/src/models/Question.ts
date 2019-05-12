class Question {
    public product_type_id: number; //It's easier to just save the id, I am not doing any logical operations with the model so yh...
    public product_id: number; //It's easier to just save the id, I am not doing any logical operations with the model so yh...
    public email : string;
    public text : string;
    public file: File | null;
    
    constructor(product_type_id: number = 0, product_id: number = 0, email: string = "", text: string = "", file: File | null = null) {
        this.product_type_id = product_type_id;
        this.product_id = product_id;
        this.email = email;
        this.text = text;
        this.file = file;
    }
}

export default Question;