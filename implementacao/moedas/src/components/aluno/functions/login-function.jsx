import axios from "axios";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Perfil from "../../../views/perfil";

function Logar(props)  {
    const[aluno,setAluno] = useState();

    axios.get(props.url, {params:{login: props.dados}})
            .then(response => {
                    if(props.dados.email === response.data.email){
                        setAluno(response.data);
                    } 
                }).catch(error => {
                console.log(error);
        })    
    return(
        <Perfil
        aluno={aluno}></Perfil>
    )
}

export default Logar;