import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:30000/api/',
});

export default api;