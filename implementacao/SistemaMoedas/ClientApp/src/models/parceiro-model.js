import { Component } from "react";

class Parceiro extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id: null,
            nome: "",
            email: "",
            senha: "",
            cnpj: ""
        }
    }
}