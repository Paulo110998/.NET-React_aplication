import dadosFetch from "../../axios/config";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./NewPost.css"

const NewPostTurma = () => {
    const navigate = useNavigate();

    // Gerenciando o estado dos inputs html
    const [titulo, setTitulo] = useState();
    const [descricao, setDescricao] = useState();
    const [cargaHoraria, setCargaHoraria] = useState();
    
    // Função que envia os dados do formulário para a API
    const createPost = async (e) => {
        e.preventDefault();  // Evita recarregamento da mesma página

        const turma = {titulo, descricao, cargaHoraria};

        try {
            //salvando os dados com post
            await dadosFetch.post("/turmas", turma);
            //redireciona para a homepage
            navigate('/');
        } catch (error) {
            console.error("Erro na requisição POST:", error);
        }
    }

    return(
        <div className="new-post">
            <h2>Cadastrar Turma</h2>
            
            <form onSubmit={(e) => createPost(e)}>
                <div className="form-controll">
                    <label htmlFor="titulo">Título:</label>
                    <input type="text"
                    name="titulo"
                    id="titulo"
                    placeholder="Digite o título"
                    onChange={(e) => setTitulo(e.target.value)} 
                    />
                </div>

                <div className="form-controll">
                <label htmlFor="descricao">Descrição:</label>
                    <input type="text"
                    name="descricao"
                    id="descricao"
                    placeholder="Digite a descrição "
                    onChange={(e) => setDescricao(e.target.value)} 
                    />
                </div>

                <div className="form-controll">
                <label htmlFor="cargaHoraria">Carga horária:</label>
                    <input type="number"
                    name="cargaHoraria"
                    id="cargaHoraria"
                    placeholder="Digite a carga horária"
                    onChange={(e) => setCargaHoraria(e.target.value)} 
                    />                  
                </div>

                <input type="submit" value="Criar turma" className="btn" />

            </form>

        </div>
    )
}

export default NewPostTurma;