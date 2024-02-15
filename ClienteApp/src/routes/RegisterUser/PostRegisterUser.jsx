import dadosFetch from "../../axios/config";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom"
import "./register.css"
import NavbarHome from '../../components/Navbar'


export default function PostRegisterUser() {
    const navigate = useNavigate();

    // Gerenciando o estado dos inputs html
    const [username, setUsername] = useState();
    const [dataNascinemto, setDataNascimento] = useState();
    const [password, setPassword] = useState();
    const [passwordConfirmation, setPasswordConfirmation] = useState();

    // Função que envia os dados do formulário para a API
    const createPostRegisterUser = async (e) => {
        e.preventDefault();  // Evita recarregamento da mesma página

        const usuario = { username, dataNascinemto, 
            password, passwordConfirmation };

        try {
            //salvando os dados com post
            await dadosFetch.post("/usuarios/cadastro", usuario);
            //redireciona para a homepage
            navigate('/cadastro');
            alert("Cadastro concluído!");
        } catch (error) {
            console.error("Erro na requisição POST:", error);
            alert("Erro ao cadastrar usuário..");
        }
    }

    return (
        <div>
            <NavbarHome/>
            <div className="new-cadastro">
            <h2>Cadastre-se</h2>
            <br />
            <form onSubmit={(e) => createPostRegisterUser(e)}>
                <div className="form-controll">
                    <label htmlFor="username">Usuário</label>
                    <input type="text"
                        name="username"
                        id="username"
                        placeholder="Digite seu usuário"
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>

                <div className="form-controll">
                    <label htmlFor="dataNascimento">E-mail</label>
                    <input type="date"
                        name="dataNascimento"
                        id="dataNascimento"
                        placeholder="Digite sua data de nascimento"
                        onChange={(e) => setDataNascimento(e.target.value)}
                    />
                </div>

                <div className="form-controll">
                    <label htmlFor="password">Senha</label>
                    <input type="password"
                        name="password"
                        id="password"
                        placeholder="Digite sua senha"
                        onChange={(e) => setPassword(e.target.value)} />
                </div>

                <div className="form-controll">
                    <label htmlFor="passwordConfirmation">Confirmar Senha</label>
                    <input type="password"
                        name="passwordConfirmation"
                        id="passwordConfirmation"
                        placeholder="Confirme sua senha"
                        onChange={(e) => setPasswordConfirmation(e.target.value)} />
                </div>               

                <input type="submit" value="Concluir" className="cadastro" />
           </form>

        </div>

        </div>
        
    )
}

