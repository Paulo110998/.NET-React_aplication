import dadosFetch from "../../axios/config";
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import "./NewPost.css";


const NewPutTurma = () => {
    const navigate = useNavigate();
    const { id } = useParams();

    const [titulo, setTitulo] = useState("");
    const [descricao, setDescricao] = useState("");
    const [cargaHoraria, setCargaHoraria] = useState(0);

    useEffect(() =>{
        // carrega os dados para a edição
        const fetchPutData = async () => {
            try {
                if(!id){
                    console.error("ID NÃO ENCONTRADO..")
                    return;
                }
                // Buscando o id da turma
                const response = await dadosFetch.get(`/turmas/${id}`);
                const turmaData = response.data;

                // Atualiza os estados com os dados da turma
                setTitulo(turmaData.titulo);
                setDescricao(turmaData.descricao);
                setCargaHoraria(turmaData.cargaHoraria);
            } catch (error) {
                console.error("Erro na requisição PUT:", error);
            }
        };
        fetchPutData(); 
        },[id]);

    const updateTurma = async (e) => {
        e.preventDefault();

        // Verificar se o id é undefined ou null
        if(!id){
            console.error("Id não definido para atualização..");
            return alert("Id não definido..");

        }
        const update = {titulo, descricao, cargaHoraria};

        try {
            await dadosFetch.put(`/turmas/${id}`, update);
            // Redireciona para a homepage
            navigate("/");
        } catch (error) {
            console.error("Erro na requisição PUT", error);
            alert("Erro!");
        }
    };

    return(
        <div className="edit-put">
            <h1>Editar Turma</h1>
            <form onSubmit={(e) => updateTurma(e)}>

                <div className="form-controll">
                    <label htmlFor="titulo">Título:</label>
                    <input type="text"
                    name="titulo"
                    id="titulo"
                    value={titulo}
                    onChange={(e) => setTitulo(e.target.value)}
                     />
                </div>

                <div className="form-controll">
                    <label htmlFor="descricao">Descrição:</label>
                    <input type="text"
                    name="descricao"
                    id="descricao"
                    value={descricao}
                    onChange={(e) => setDescricao(e.target.value)}
                     />
                </div>

                <div className="form-controll">
                    <label htmlFor="cargaHoraria">Carga horária:</label>
                    <input type="text"
                    name="cargaHoraria"
                    id="cargaHoraria"
                    value={cargaHoraria}
                    onChange={(e) => setCargaHoraria(e.target.value)}
                     />
                </div>

                <input type="submit" value="Atualizar" className="btn"/>



            </form>

        </div>
    )


}

export default NewPutTurma;