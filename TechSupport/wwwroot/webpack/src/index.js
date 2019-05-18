import * as signalR from "@aspnet/signalr";

require("popper.js");
require("jquery-validation");
require("jquery-validation-unobtrusive");

import '@fortawesome/fontawesome-free/js/fontawesome'
import '@fortawesome/fontawesome-free/js/solid'
import '@fortawesome/fontawesome-free/js/regular'
import '@fortawesome/fontawesome-free/js/brands'

const $ = require("jquery");
require("bootstrap/js/dist/alert");


let question_amount = document.getElementById('question-amount');

if (question_amount) {

    let connection = new signalR.HubConnectionBuilder().withUrl("/questionHub").build();

    connection.on("Increment", () => {
        question_amount.innerHTML = (parseInt(question_amount.innerHTML) + 1);
    });
    connection.on("Decrement", () => {
        question_amount.innerHTML = (parseInt(question_amount.innerHTML) - 1);
    });

    connection.start().then(() => {})
    .catch(err => {
        alert(`Failed initializing signalR:\n${err}`);
    });
}