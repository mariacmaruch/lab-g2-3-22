import { Component } from "react";
import { Container,Table, Button } from "reactstrap";
import "./aluno.css";

export default class Perfil extends Component {
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
                instituicaoId:null,
            },
            endereco:[],
            loading: true
        }

    }

    componentDidMount() {
        this.setState({
            aluno: this.props.aluno
        })
    }

    static renderAlunoInfo(aluno) {
            return (            
                <Container>
                    <Table>
                        <thead>
                            <tr>
                                <th xs={1}>Id do Aluno</th>
                                <th xs={4}>Nome</th>
                                <th xs={2}>CPF</th>
                                <th xs={3}>E-mail</th>
                                <th xs={2}>Ações</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th>{aluno.id}</th>
                                <th>{aluno.nome}</th>
                                <th>{aluno.cpf}</th>
                                <th>{aluno.email}</th>
                                <th>
                                    <Button className="btn-primary">Editar</Button>
                                    <Button className="btn-secondary">Apagar</Button>
                                </th>
                            </tr>
                        </tbody>
                    </Table>
                </Container>
            )
    };
    render() {
        let contents = this.state.loading
            ? <p><em>Carregando...</em></p>
            : Aluno.renderAlunoInfo(this.state.aluno);
        return (
            <div>
                <h1 id="tabelLabel" >Aluno</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );

    }
    async populateEndereco() {
        const response = await fetch("https://localhost:44370/api/Aluno");
        const data = await response.json();
        this.setState({ alunos: data, loading: false });
    }
}
