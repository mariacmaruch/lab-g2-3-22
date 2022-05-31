import axios from "axios";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Form, FormGroup, Input, Label, Button } from "reactstrap";

const baseLoginUrl = "https://localhost:44370/api/Aluno/login";

export default function Login() {

    var self = this;
    let navigate = useNavigate
    const [email, setEmail] = useState();
    const [senha, setSenha] = useState();
    const [aluno, setAluno] = useState();
    const [isSubmitted, setIsSubmitted] = useState(false);

    const onClick = (event) => {
        event.preventDefault();
        handleSubmit();
        console.log(isSubmitted)
    }

    const handleSubmit = async () => {
        axios.get(baseLoginUrl, { params: { email: email, senha: senha } })
            .then(response => {
               setIsSubmitted(...true);
               setAluno(...response.data);
            }).catch(error => {
                console.log(error);
            })
        if (isSubmitted) {
            navigate("/Aluno/profile", { aluno: aluno });
        }
    }
    const redirectProfile = () => {

    }


    return (
        <Form>
            <FormGroup>
                <Label for="inputEmail">E-mail</Label>
                <Input type="text" id="inputEmail" aria-describedby="emailHelp" onChange={(e) => setEmail(e.target.value)} value={email}></Input>
            </FormGroup>
            <FormGroup>
                <Label for="inputPassword">Senha</Label>
                <Input type="password" id="inputPassword" onChange={(e) => setSenha(e.target.value)} value={senha}></Input>
            </FormGroup>
            <Button onClick={onClick}>Enviar</Button>
        </Form >

    )
}
/*
export default class LoginAluno extends Component {
    constructor(props) {
        super(props);
        this.state = {
            aluno: {
                id: null,
                nome: "",
                email: "",
                senha: "",
                cpf: "",
                rg: "",
                instituicaoId: null,
            },
            login: {
                email: "",
                senha: ""
            },
            baseLoginUrl: "https://localhost:44370/api/Aluno/login",
        };

        this.handleLoginChange = this.handleLoginChange.bind(this);
        this.alunoGet = this.alunoGet.bind(this);
        this.handleLogin = this.handleLogin.bind(this);
    }

    handleLoginChange(e) {
        const { login } = { ...this.state };
        const currentLogin = login;
        const { name, value } = e.target;
        currentLogin[name] = value;
        this.setState({
            login: currentLogin
        });
    }

    handleLogin(){
        axios.get(this.state.baseLoginUrl, this.state.login)
            .then(response => {
                    this.setState({ aluno: response.data })          
                }).catch(error => {
                console.log(error);
        })
        console.log(this.state.aluno)
    }
    alunoGet = async () => {
        await axios.get(this.state.baseLoginUrl, this.state.login)
            .then(response => {
                    this.setState({ aluno: response.data })          
                }).catch(error => {
                console.log(error);
            })
    }
    componentDidMount() {
    }

    render() {
        return (
            <Form>
                <FormGroup>
                    <Label for="inputEmail">E-mail</Label>
                    <Input type="text" id="inputEmail" name="email" aria-describedby="emailHelp" onChange={this.handleLoginChange} value={this.state.login.email}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="inputPassword">Senha</Label>
                    <Input type="password" id="inputPassword" name="senha" onChange={this.handleLoginChange} value={this.state.login.senha}></Input>
                </FormGroup>
                <Button onClick={<Logar url={this.state.baseLoginUrl} dados={this.state.login/}>}>Enviar</Button>
            </Form >
        )
    };
}*/