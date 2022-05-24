import { Component } from "react";
import { Container,Table, Button } from "reactstrap";
import "./aluno.css";

export default class Aluno extends Component {
    constructor(props) {
        super(props);
        this.state = {
            aluno: {
                id: "",
                nome: "",
                email: "",
                senha: "",
                cpf: "",
                rg: "",
                instituicaoId: undefined,
                enderecoId:""
            },
            alunos: [ ],
            loading: true
        }

    }

    componentDidMount() {
        this.populateAlunoData();
    }

    static renderAlunoInfo(alunos) {
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
                         {alunos.map(aluno =>
                            <tr key={aluno.id}>
                                <th>{aluno.id}</th>
                                <th>{aluno.nome}</th>
                                <th>{aluno.cpf}</th>
                                <th>{aluno.email}</th>
                                <th>
                                    <Button className="btn-primary">Editar</Button>
                                    <Button className="btn-secondary">Apagar</Button>
                                </th>
                            </tr>
                        )}
                        </tbody>
                    </Table>
                </Container>
            )
    };
    render() {
        let contents = this.state.loading
            ? <p><em>Carregando...</em></p>
            : Aluno.renderAlunoInfo(this.state.alunos);
        return (
            <div>
                <h1 id="tabelLabel" >Aluno</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );

    }
    async populateAlunoData() {
        const response = await fetch("https://localhost:44370/api/Aluno");
        const data = await response.json();
        this.setState({ alunos: data, loading: false });
    }
}
