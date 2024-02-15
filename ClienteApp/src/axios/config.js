import axios from "axios";


const dadosFetch = axios.create({
    baseURL: "https://localhost:7069",
    headers: {
        'Content-Type': 'application/json',
    },
});

export default dadosFetch;