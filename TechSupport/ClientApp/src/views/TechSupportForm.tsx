import * as React from "react";
import Question from "../models/Question";
import HttpRequest from "../services/http/HttpRequest";

import Spinner from '../components/Spinner';
import Message from '../components/Message'
import ProductType from "../models/ProductType";
import Product from "../models/Product";

interface IState {
    question: Question
    is_loading: Boolean,
    is_finished: Boolean,
    product_types_options: Array<ProductType>,
    products_options: Array<Product>
}

interface IProps {
}

class TechSupportForm extends React.Component<IProps, IState> {

    private _httpRequest = new HttpRequest();

    constructor(props: Object) {
        super(props);
        this.state = {
            question: new Question(),
            is_loading: true,
            is_finished: false,
            product_types_options: [],
            products_options: []
        };
    }

    componentDidMount(): void {
        this._httpRequest.sendGet<Array<ProductType>>('/producttypes')
            .then(response => {
                this.setState({
                    is_loading: false,
                    product_types_options: response.data,
                });
            })
            .catch(() => {
                //TODO: throw error
            });
    }
    //TODO: Cleanup? 
    handelProductTypeChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        let product_type_id = parseInt(e.target.value);

        if (product_type_id !== 0) {
            this.setState({
                is_loading: true,
                question: {
                    ...this.state.question,
                    productTypeId: product_type_id,
                }
            });

            this._httpRequest.sendGet<ProductType>(`/producttypes/${product_type_id}`)
                .then(response => {
                    this.setState({
                        is_loading: false,
                        products_options: response.data.products as Array<Product> //If it crashes it jumps into catch
                    })
                })
                .catch((e) => {
                    console.log(e)
                })
        } else {
            (document.getElementById('file') as HTMLInputElement).value = '';
            this.setState({
                products_options: [],
                question: {
                    ...this.state.question,
                    productTypeId: product_type_id,
                    productId: 0,
                    email: "",
                    body: ""
                }
            });
        }
    };

    handleProductChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        let product_id = parseInt(e.target.value);
        this.setState({
            question: {
                ...this.state.question,
                productId: product_id,
            }
        });

        if (product_id === 0) {
            (document.getElementById('file') as HTMLInputElement).value = '';
            this.setState({
                question: {
                    ...this.state.question,
                    productId: product_id,
                    email: "",
                    body: ""
                    //TODO: Reset file
                }
            });
        }
    };

    handleEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({
            question: {
                ...this.state.question,
                email: e.target.value
            }
        });
    };

    handleTextChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
        this.setState({
            question: {
                ...this.state.question,
                body: e.target.value
            }
        })
    };

    handleFormSubmit = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        
        let formData: FormData = new FormData();

        for (let key in this.state.question) {
            formData.append(key, (this.state.question as any)[key])
        }
        
        let fileInput: HTMLInputElement = document.getElementById('file') as HTMLInputElement;
        
        if(fileInput.files != null && fileInput.files.length != 0)
            formData.append("file", fileInput.files[0]);
        
        this.setState({
            is_loading: true
        });
        this._httpRequest.sendPost('/question/add',  formData)
            .then(() => {
                this.setState({
                    is_finished: true
                })
            })
            .catch((ex) => {
                let errors: String = "Errors: \n";
                for(let key in ex.response.data.errors) {
                    errors += ex.response.data.errors[key] + "\n";
                }
                alert(errors) //TODO: Maybe use bootstrap modal?
            })
            .finally(() => {
                this.setState({
                    is_loading: false
                });
            })
    };

    render() {
        return <form>
            <Spinner is_loading={this.state.is_loading}/>
            <Message is_showing={this.state.is_finished}/>
            <div className="form-group row">
                <label htmlFor="product_type" className="col-sm-2 col-form-label">Product Type</label>
                <div className="col-sm-10">
                    <select onChange={this.handelProductTypeChange} className="custom-select" id="product_type">
                        <option key='0' value='0'/>
                        {this.state.product_types_options.map((i) => <option key={i.productTypeId}
                                                                             value={i.productTypeId}>{i.name}</option>)}
                    </select>
                </div>
            </div>
            <div className={"form-group row" + (this.state.question.productTypeId === 0 ? " d-none" : "")}>
                <label htmlFor="product" className="col-sm-2 col-form-label">Product</label>
                <div className="col-sm-10">
                    <select onChange={this.handleProductChange} className="custom-select" id="product">
                        <option key='0' value='0'/>
                        {this.state.products_options.map((i) => <option key={i.productId}
                                                                        value={i.productId}>{i.name}</option>)}
                    </select>
                </div>
            </div>
            <div
                className={this.state.question.productId === 0 || this.state.question.productTypeId === 0 ? "d-none" : ""}>
                <div className="form-group row">
                    <label htmlFor="email" className="col-sm-2 col-form-label">Email*</label>
                    <div className="col-sm-10">
                        <input type="email" required className="form-control" id="email"
                               onChange={this.handleEmailChange} value={this.state.question.email}/>
                    </div>
                </div>
                <div className="form-group row">
                    <label htmlFor="body" className="col-sm-2 col-form-label">Text*</label>
                    <div className="col-sm-10">
                        <textarea onChange={this.handleTextChange} id="body" required className="form-control"
                                  value={this.state.question.body}/>
                    </div>
                </div>
                <div className="form-group row">
                    <label htmlFor="file" className="col-sm-2 col-form-label">File</label>
                    <div className="col-sm-10 d-flex align-items-center">
                        <input type="file" id="file"/>
                    </div>
                </div>
                <button onClick={this.handleFormSubmit} className="btn btn-primary">Send</button>
            </div>
        </form>;
    }
}

export default TechSupportForm;