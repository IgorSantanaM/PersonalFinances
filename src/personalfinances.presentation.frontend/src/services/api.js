import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:55650/api/',
});

export default api;