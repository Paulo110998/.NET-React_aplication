import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'

// Importando elementos do react-router-dom
import { createBrowserRouter, RouterProvider, Route , useParams} from 'react-router-dom'

// Importando components
import Homepage from "./routes/Homepage/Homepage.jsx"
import Login from "./routes/Login/Login.jsx"
import Cadastro from "./routes/RegisterUser/PostRegisterUser.jsx"
import ListTurmas from './routes/Turmas/ListTurmas.jsx'
import PutTurmas from "./routes/Turmas/NewPutTurma.jsx"
import DeleteTurma from "./routes/Turmas/DeleteTurma.jsx"


// criando objeto de configuração de roteamento
const router = createBrowserRouter([
  {
    element: <App/>,

    // Rotas
    children:[
      {
      path:"/",
      element: <Homepage/>,
      },
      {
        path:"/cadastro",
        element: <Cadastro/>,
      },
      {
        path:"/login",
        element: <Login/>,
      },
      {
        path:'/list_turmas',
        element: <ListTurmas/>,
      },
      {
        path: "/update-turma/:id",
        element: <PutTurmas/>,
      },
      {
        path: "/delete-turma/:id",
        element: <DeleteTurma/>,
      }
      
  
  ]
  }
])


ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>,
)
