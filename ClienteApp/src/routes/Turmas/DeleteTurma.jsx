import React, { useState, useEffect } from 'react';
import dadosFetch from '../../axios/config';
import { useNavigate, useParams } from 'react-router-dom';

const DeleteTurma = () => {
  const [response, setResponse] = useState('');
 
 const { id } = useParams();
 const navigate = useNavigate();

 useEffect(() => {
    const fetchDeleteData = async () => {
      try {
        if(!id){
          console.error("Id não encontrado..")
          return;
        }
        const result = await dadosFetch.get(`/turmas/${id}`);
        result.data;

      
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchDeleteData();
 }, [id]);

 const handleDelete = async (e) => {
  e.preventDefault();

  if(!id){
    console.error("Id não encontrado..");
    return alert("Id não encontrado");
  }

 

    try {
      await dadosFetch.delete(`/turmas/${id}`);
       navigate("/");

    } catch (error) {
      console.error('Erro na requisição DELETE:', error);
    }
 };

 return (
    <div>
      <h2>Delete Object</h2>
      <button onClick={handleDelete} className='btn'>Delete</button>
      {response && <p>Response: {response}</p>}
    </div>
 );
};

export default DeleteTurma;