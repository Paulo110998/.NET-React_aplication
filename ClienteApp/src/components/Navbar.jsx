import { Link } from 'react-router-dom'

import "./Navbar.css"

import React from 'react'

const Navbar = () => {
    return (
        <nav className='navbar'>
            <h2>
                <Link to={'/'}>Educ</Link>
            </h2>
            <ul>
                <li>
                    <Link to={'/'}>Homepage</Link>
                </li>
                <li><a href="">Contato</a></li>
                <li><a href="">Canais</a></li>

                <li>
                    <Link to={'/login'} className='new-btn'>Login</Link>
                </li>
            </ul>

        </nav>
    )
}

export default Navbar