import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:50890/api/',
});

export default api;