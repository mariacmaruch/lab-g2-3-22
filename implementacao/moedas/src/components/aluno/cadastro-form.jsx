import axios from "axios";
import { Component } from "react";
import { Link } from "react-router-dom";
import { Form, FormGroup, Input, Label, Button } from "reactstrap";

export default class CadastroAluno extends Component {
    constructor(props) {
        super(props);
        this.state = {
            cadastroAluno: {
                nome: "",
                email: "",
                senha: "",
                cpf: "",
                rg: "",
                instituicaoId: 1,
                rua: "",
                numero: 0,
                complemento: "",
                bairro: "",
                cidade: "",
                estado: "",
                alunoId: 0
            },
            instituicoes: [ ],
            loading: true,
            baseAlunoUrl: "https://localhost:44370/api/Aluno",
        };

        this.handleCadastroAlunoChange = this.handleCadastroAlunoChange.bind(this);
        this.alunoPost = this.alunoPost.bind(this);
    }

    handleCadastroAlunoChange(e) {
        const { cadastroAluno } = { ...this.state };
        const currentCadastroAluno = cadastroAluno;
        const { name, value } = e.target;
        currentCadastroAluno[name] = value;
        this.setState({
            cadastroAluno: currentCadastroAluno
        });
    }
    alunoPost = async () => {
        await axios.post(this.state.baseAlunoUrl, this.state.cadastroAluno)
            .then(response => {
            }).catch(error => {
                console.log(error);
            })
    }
    componentDidMount() {
        this.populateInstituicao();
    }


    render() {
        if (!this.state.loading) {
            return (
                <Form>
                    <FormGroup>
                        <Label for="inputNome">Nome</Label>
                        <Input type="text" id="InputNome" name="nome" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.nome}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputEmail">E-mail</Label>
                        <Input type="text" id="inputEmail" name="email" aria-describedby="emailHelp" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.email}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputPassword">Senha</Label>
                        <Input type="password" id="inputPassword" name="senha" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.senha}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputCpf">CPF</Label>
                        <Input type="text" id="inputCpf" name="cpf" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.cpf}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputRg">RG</Label>
                        <Input type="text" id="inputRg" name="rg" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.rg}></Input>
                    </FormGroup>
                    <FormGroup>
                        <FormGroup><legend>Insituição</legend></FormGroup>
                        <select className="form-select" name="instituicaoId" onChange={this.handleCadastroAlunoChange}>
                            {this.state.instituicoes.map(instituicao => 
                                <option key={instituicao.is} value={instituicao.id}>{instituicao.nome}</option>
                            )}
                        </select>
                    </FormGroup>
                    <FormGroup><legend>Endereço</legend></FormGroup>
                    <FormGroup>
                        <Label for="inputRua">Rua</Label>
                        <Input type="text" id="inputRua" name="rua" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.rua}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputNumero">Número</Label>
                        <Input type="number" id="inputNumero" name="numero" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.numero}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputComplemento">Complemento</Label>
                        <Input type="text" id="inputComplemento" name="complemento" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.complemento}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputBairro">Bairro</Label>
                        <Input type="text" id="inputBairro" name="bairro" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.bairro}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputCidade">Cidade</Label>
                        <Input type="text" id="inputCidade" name="cidade" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.cidade}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="inputEstado">Estado</Label>
                        <Input type="text" id="inputEstado" name="estado" onChange={this.handleCadastroAlunoChange} value={this.state.cadastroAluno.estado}></Input>
                    </FormGroup>
                    <Link to={"/"}><Button onClick={this.alunoPost}>Enviar</Button></Link>
                </Form >
            )
        }
    };
    populateInstituicao = async() => {
        const response = await axios.get("https://localhost:44370/api/Instituicao")
        const data = await response.data;
        this.setState({ instituicoes: data, loading: false });
        
    }
}