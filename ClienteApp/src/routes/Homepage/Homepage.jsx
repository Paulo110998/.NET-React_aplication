import dadosFetch from "../../axios/config"
import { useState, useEffect } from "react"
import { Link } from "react-router-dom"
import "./Homepage.css"
import NavbarHome from '../../components/Navbar'



//import Loading from "./img/loading.gif"

export default function Homepage() {
    return (
        <div>
            <NavbarHome/>
            <div className="homepage">
            <h1>StepGame</h1>
            <br />
            <div className="informacao">
                <p>Aqui você encontra as mais variados games com foco na educação
                    para a educação. Temos gestão de relatório,
                     diário de classe entre outras ferramentas!</p>

            </div>

            </div>
             
            

        </div>
        
    )
}
