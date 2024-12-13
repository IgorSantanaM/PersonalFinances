import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:59389/api/',
});

export default api;