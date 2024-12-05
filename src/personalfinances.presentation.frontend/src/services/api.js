import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5066/api/',
});

export default api;