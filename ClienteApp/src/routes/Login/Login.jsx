import dadosFetch from "../../axios/config"
import { useState } from "react"
import { Link, useNavigate } from "react-router-dom"
import "./login.css"
import NavbarHome from '../../components/Navbar'



function Login() {
    const navigate = useNavigate();

    // Gerenciando o estado dos inputs html
    const [username, setUsername] = useState();
    const [password, setPassword] = useState();

    // Função que envia os dados do formulário para a API
    const createPostLoginUser = async (e) => {
        e.preventDefault();  // Evita recarregamento da mesma página

        const usuario = { username, password };

        try {
            //salvando os dados com post
            await dadosFetch.post("/usuarios/login", usuario);
            //redireciona para a homepage
            navigate('/list_turmas');
            
        } catch (error) {
            console.error("Erro na requisição POST:", error);
            alert("Erro, tente novamente..");
        }
    }


    return (
        <div>
            <NavbarHome />
            <div className="new-login">
                <h2>Entre com sua conta:</h2>
                <br />
                <form onSubmit={(e) => createPostLoginUser(e)}>
                    <div className="form-controll">
                        <label htmlFor="username">Usuário*</label>
                        <input type="text"
                            name="username"
                            id="username"
                            placeholder="Digite seu usuário"
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </div>
                    <br />

                    <div className="form-controll">
                        <label htmlFor="password">Senha*</label>
                        <input type="password"
                            name="password"
                            id="password"
                            placeholder="Digite sua senha"
                            onChange={(e) => setPassword(e.target.value)} />
                    </div>
                    <br />


                    <input type="submit" value="Entrar" className="entrar" />

                    <Link to={'/cadastro'} > Cadastre-se</Link>




                </form>

            </div>
        </div>


    )
}

export default Login