import axios from "axios";
import { Component } from "react";
import { Form, FormGroup, Input, Label, Button } from "reactstrap";

export default class CadastroAluno extends Component {
    constructor(props) {
        super(props);
        this.state = {
            aluno: {
                nome: "",
                email: "",
                senha: "",
                cpf: "",
                rg: "",
                instituicaoId: 1,
                enderecoId: 1
            },
            endereco: {
                id: "",
                rua: "",
                numero: 1,
                complemento: "",
                bairro: "",
                cidade: "",
                estado: ""
            },
            baseUrl: "https://localhost:44370/api/Aluno"
        };
        this.handleAlunoChange = this.handleAlunoChange.bind(this);
        this.handleEnderecoChange = this.handleEnderecoChange.bind(this);
    }

    handleAlunoChange(e) {
        const { aluno } = { ...this.state };
        const currentAluno = aluno;
        const { name, value } = e.target;
        currentAluno[name] = value;
        this.setState({
            aluno: currentAluno
        });
    }

    handleEnderecoChange(e) {
        const { endereco } = { ...this.state };
        const currentEndereco = endereco;
        const { name, value } = e.target;
        currentEndereco[name] = value;
        this.setState({
            endereco: currentEndereco
        });
    }

    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    alunoPost = async () => {
        console.log(this.state.aluno);
        await axios.post(this.state.baseUrl, this.state.aluno)
            .then(response => {
                console.log(response.data);
            }).catch(error => {
                console.log(error);
            })

    }
    render() {
        return (
            <Form>
                <FormGroup>
                    <Label for="inputNome">Nome</Label>
                    <Input type="text" id="InputNome" name="nome" onChange={this.handleAlunoChange} value={this.state.aluno.nome}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputEmail">E-mail</Label>
                    <Input type="text" id="inputEmail" name="email" aria-describedby="emailHelp" onChange={this.handleAlunoChange} value={this.state.aluno.email}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputPassword">Senha</Label>
                    <Input type="password" id="inputPassword" name="senha" onChange={this.handleAlunoChange} value={this.state.aluno.senha}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputCpf">CPF</Label>
                    <Input type="text" id="inputCpf" name="cpf" onChange={this.handleAlunoChange} value={this.state.aluno.cpf}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputRg">RG</Label>
                    <Input type="text" id="inputRg" name="rg" onChange={this.handleAlunoChange} value={this.state.aluno.rg}></Input>
                </FormGroup>
                <FormGroup><legend>Endereço</legend></FormGroup>
                <FormGroup>
                    <Label for="inputRua">Rua</Label>
                    <Input type="text" id="inputRua" name="rua" onChange={this.handleEnderecoChange} value={this.state.endereco.rua}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputNumero">Número</Label>
                    <Input type="number" id="inputNumero" name="numero" onChange={this.handleEnderecoChange} value={this.state.endereco.numero}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputComplemento">Complemento</Label>
                    <Input type="text" id="inputComplemento" name="complemento" onChange={this.handleEnderecoChange} value={this.state.endereco.complemento}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputBairro">Bairro</Label>
                    <Input type="text" id="inputBairro" name="bairro" onChange={this.handleEnderecoChange} value={this.state.endereco.bairro}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputCidade">Cidade</Label>
                    <Input type="text" id="inputCidade" name="cidade" onChange={this.handleEnderecoChange} value={this.state.endereco.cidade}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputEstado">Estado</Label>
                    <Input type="text" id="inputEstado" name="estado" onChange={this.handleEnderecoChange} value={this.state.endereco.estado}></Input>
                </FormGroup>
                <FormGroup>
                    <FormGroup><legend>Insituição</legend></FormGroup>
                    <Input type="select" id="inlineFormCustomSelectPref" name="instituicaoId" onChange={this.handleAlunoChange} value={this.state.aluno.instituicaoId}>
                        <option>1</option>
                        <option>2</option>
                    </Input>
                </FormGroup>
                <Button onClick={this.alunoPost}>Enviar</Button>
            </Form>
        );
    }
}