import dadosFetch from "../../axios/config"
import { useState, useEffect } from "react"
import GifLoad from "../img/loading.gif"
import "./List.css"
import NavbarUser from '../../components/NavbarUser'
//import Sidebars from "../../components/Sidebar"




const ListTurmas = () => {
    const [turmas, setTurmas] = useState([])

    const getDadosTurmas = async () => {
        try {
            const response = await dadosFetch.get("/turmas");
            const data = response.data;
            setTurmas(data);
        } catch (error) {
            console.log(error);
        }
    }

    useEffect(() => {
        getDadosTurmas();
    }, [])

    return (
        <div>
            <NavbarUser/>
            
            <div className="homepage">
              <div>  
                <br />
                

                    <h1>Suas Turmas</h1>
                   
                    {turmas.length === 0 ? <img src={GifLoad} /> : (
                        turmas.map((turma) => (
                            <div className="turma" key={turma.id}>
                                <br />
                                <h2>{turma.titulo}</h2>
                                <p>Descrição: {turma.descricao}</p>
                                <p>Carga Horaria: {turma.cargaHoraria} horas</p>
                                <p>Disciplinas: {turma.readDisciplinasDto.map((disciplina) => disciplina.titulo).join(', ')}</p>

                            </div>
                        ))
                    )}
                </div>

            </div>

        </div>

    )
}



export default ListTurmas