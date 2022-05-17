import { Component } from "react";

class Aluno extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id: null,
            nome: "",
            email: "",
            senha: "",
            cpf: "",
            conta: {
                id: null,
                saldo: null
            },
            rg: "",
            instituicao: {
                id: null,
                nome:""
            },
            endereco: {
                rua: "",
                numero: null,
                complemento: "",
                bairro: "",
                cidade: "",
                estado:""
            }

        }
    }
}