import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:61345/api/',
});

export default api;