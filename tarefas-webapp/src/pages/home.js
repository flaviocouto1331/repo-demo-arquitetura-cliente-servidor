import { RenderizarService } from "../services/base-service.js";
import { PegarDataAtual } from "../utilities/util.js";

export const RenderizarHome = async (app) => {

   try {
        const url = '/pages/home.html';   
        const html = await RenderizarService(url);
        const dataAtual = PegarDataAtual();
        app.innerHTML = html.replace('[data]', dataAtual);
   } catch (erro) {
        throw new Error(`Erro. ${erro.message}`);
   }
}