import axios from 'axios';
import logger from './logger';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL ?? 'http://localhost:5134',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Automatically attach JWT token from localStorage
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// Log errors
api.interceptors.response.use(
  (response) => response,
  (error) => {
    logger.error('API error', error.response?.status, error.response?.data);
    return Promise.reject(error);
  }
);

export default api;
