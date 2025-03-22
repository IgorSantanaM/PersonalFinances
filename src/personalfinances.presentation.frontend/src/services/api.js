import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:30080/api/',
});

export default api;