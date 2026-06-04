import { api } from "../utilities/api.js";

// API

export const PegarTodosTarefasService = async () => {

    const response = await api.get("/todo");
    return response.data;
} 

export const PegarTarefasService = async (guidId) => {
    
    const response = await api.get(`/todo/${guidId}`);
    return response.data;
}

export const CriarTarefasService = async (dados) => {
   
    const response = await api.post(
        "/todo", 
        dados,
        { 
            headers: {
                "Content-Type": "application/json" // opcional pois Axios JS já detecta json
            }
        }
    );
    return response.data;
}

export const AtualizarTarefasService = async (dados) => {

    const response = await api.put(
        '/todo',
        dados,
        {
            headers: {
                //"Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        }
    );
    return response.data;
}

export const DeletarTarefasService = async (guidId) => {
    const response = await api.delete(`/todo/${guidId}`);
    return response.data;
}