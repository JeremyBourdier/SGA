import axios from "axios";

const apiClient = axios.create({
    baseURL: "http://localhost:5108/api", // Asegurar que es el puerto correcto del backend
    headers: {
        "Content-Type": "application/json",
    },
    withCredentials: false,
});

// Interceptor de respuestas para manejar errores globalmente
apiClient.interceptors.response.use(
    response => response,
    error => {
        console.error("Error en la API:", error.response?.data || error.message);
        return Promise.reject(error);
    }
);

export default apiClient;
