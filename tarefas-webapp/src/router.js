import { RenderizarHome } from "./pages/home.js";
import { RenderizarTarefas } from "./pages/tarefas.js";

const rotas = {
    "/": RenderizarHome, // add referência da função
    "/tarefas": RenderizarTarefas
}

export const PegarRota = async (app) => {
    try {
        
        const path = window.location.pathname;
        const carregar = rotas[path];        
        if (!carregar) {

            app.innerHTML = "<h1>404 - Página não encontrada</h1>";
            return;
        }
        await carregar(app);
    } catch (erro) {
        throw new Error(`Erro. ${erro.message}`);
    }    
}

export const PegarEventosRotas = (app) => {

    // Eventos do DOM/documento
    document.addEventListener(
        "click",
        async (e) => {

            const link = e.target.closest("[data-link]");
            if (!link) return;
            e.preventDefault();
            history.pushState({}, "", link.getAttribute("href")); //history.pushState({}, "", link.href);
            await PegarRota(app);
        }
    );

    // Eventos do navegador/janela
    window.addEventListener(
        "popstate",
        async () => {

            await PegarRota(app);
        }
    );
}