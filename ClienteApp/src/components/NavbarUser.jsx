import { Link } from 'react-router-dom'

import "./Navbar.css"

import React from 'react'

const Navbar = () => {
    return (
        <nav className='navbar'>
            <h2>
                <Link to={'/list_turmas'}>Step GamesEduc</Link>
            </h2>
            <ul>
                <li>
                    <Link to={'/'}></Link>
                </li>
                <li><a href="#">Turmas</a></li>
                <li><a href="#">Disciplinas</a></li>

                <li>
                    <Link to={'/login'} className='new-btn'>Conta</Link>
                </li>
            </ul>

        </nav>
    )
}

export default Navbar