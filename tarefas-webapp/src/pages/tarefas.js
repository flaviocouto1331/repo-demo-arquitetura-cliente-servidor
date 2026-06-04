import { Modal } from "bootstrap";
import { ConfigurarModal } from "../utilities/modal.js";
import { CarregarMask } from "../utilities/mask.js";
import { ConverterData, FormatarMoeda } from "../utilities/util.js";
import { RenderizarService } from "../services/base-service.js";
import { 
    PegarTodosTarefasService,
    PegarTarefasService,
    CriarTarefasService,
    AtualizarTarefasService,
    DeletarTarefasService     
} from "../services/tarefas-service.js";

let modalApp = null;
let modalElement = null;
let modalInstance = null;

export const RenderizarTarefas = async (app) => {

    try {

        const url = '/pages/tarefas.html';

        // 1. Carrega conteúdo da página HTML
        const html = await RenderizarService(url);
        app.innerHTML = html;

        // 2. Busca os dados da API
        const response = await PegarTodosTarefasService();

        // 3. Renderiza os dados na Tabela
        const tbody = document.querySelector("#registros");
        tbody.innerHTML = response.todo.map(item => `
            <tr>
                <td>${item.guidId}</td>
                <td>${ConverterData(item.dataCadastro) ?? '-'}</td>
                <td>${item.statusCadastro ? "Ativo" : "Inativo"}</td>
                <td>${item.nome}</td>
                <td>${FormatarMoeda(item.valor)}</td>
                <td>
                    <div class="d-flex">   
                        <button type="button" data-guid="${item.guidId}" class="btn btn-outline-primary btn-sm btn-tabela-atualizar" title="Atualizar">&#x270F;</button>&nbsp; 
                        <button type="button" data-guid="${item.guidId}" class="btn btn-outline-danger btn-sm btn-tabela-deletar" title="Deletar">&#x1F5D1;</button>              
                    </div>
                </td>
            </tr>
        `).join("");

    } catch (erro) {
        if(erro.response?.status === 400) alert(erro.response?.data?.msg);
        else alert(`Erro - ${erro.message}`)
    }
}

export const PesquisarTarefas = async () => {

    try {

        const form = document.querySelector("#frmPesquisarTarefas");
        if (!ValidarFormulario(form)) return;
        const guidId = document.getElementById("guidId").value;        
        const response = await PegarTarefasService(guidId);
        const tbody = document.querySelector("#registros");
        tbody.innerHTML = `
            <tr>
                <td>${response.todo.guidId}</td>
                <td>${ConverterData(response.todo.dataCadastro) ?? '-'}</td>
                <td>${response.todo.statusCadastro ? "Ativo" : "Inativo"}</td>
                <td>${response.todo.nome}</td>
                <td>${FormatarMoeda(response.todo.valor)}</td>
                <td>
                    <div class="d-flex">                        
                        <button type="button" data-guid="${response.todo.guidId}" class="btn btn-primary btn-sm btn-tabela-atualizar" title="Atualizar">&#x270F;</button>&nbsp;
                        <button type="button" data-guid="${response.todo.guidId}" class="btn btn-danger btn-sm btn-tabela-deletar" title="Deletar">&#x1F5D1;</button>
                    </div>
                </td>
            </tr>
        `;
    } catch (erro) {
        if (erro.response?.status === 400) alert(erro.response?.data?.msg);
        else alert(`Erro - ${erro.message}`);
    }
}

const RenderizarCriarTarefas = async () => {
    try {

        const url = '/pages/tarefas-criar.html';       
        
        // 1. HTML
        const html = await RenderizarService(url);  

        // 2. Modal
        modalApp = document.querySelector("#modalApp");  
        modalApp.innerHTML = html;
        modalElement = modalApp.querySelector("#modalCriarTarefas");
        modalInstance = Modal.getInstance(modalElement);
        if (!modalInstance) {
            modalInstance = new Modal(modalElement);
            ConfigurarModal(modalApp, modalElement, modalInstance);
        }
        modalInstance.show();

        // 3. Mask
        CarregarMask();
    } catch (erro) {
        if (erro.response?.status === 400) alert(erro.response?.data?.msg);
        else alert(`Erro - ${erro.message}`);
    }
}

const CriarTarefas = async () => {

    try {

        const form = document.querySelector("#frmCriarTarefas");
        if (!ValidarFormulario(form)) return;
        const dados = {
                nome: form.querySelector("#nome").value,
                valor: form.querySelector("#valor").value.replace(/\./g, "").replace(",", ".")
            };
        const response = await CriarTarefasService(dados); // CriarTarefasService(JSON.stringify(dados)); - Axios já converte o objeto para JSON, então não é necessário usar JSON.stringify
        alert(response.msg);
        await RenderizarTarefas(document.querySelector("#app"));
        modalInstance.hide();           
    } catch (erro) {        
        if (erro.response?.status === 400) alert(erro.response?.data?.msg);
        else alert(`Erro - ${erro.message}`);
    }
}

const RenderizarAtualizarTarefas = async (guidId) => {

    try {

        const url = '/pages/tarefas-atualizar.html';
        const html = await RenderizarService(url); 
        
        modalApp = document.querySelector("#modalApp");
        modalApp.innerHTML = html;
        modalElement = modalApp.querySelector("#modalAtualizarTarefas"); 
        modalInstance = Modal.getInstance(modalElement);
        if(!modalInstance) {
            modalInstance = new Modal(modalElement);
            ConfigurarModal(modalApp, modalElement, modalInstance);            
        }
        modalInstance.show();

        const response = await PegarTarefasService(guidId)
        const form = document.querySelector("#frmAtualizarTarefas");        
        form.guidId.value = response.todo.guidId;
        form.dataCadastro.value = response.todo.dataCadastro;
        form.statusCadastro.checked = response.todo.statusCadastro;
        form.nome.value = response.todo.nome;
        form.valor.value = response.todo.valor.toLocaleString(
            "pt-BR",
            {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            }
        ); 

        CarregarMask();
    } catch (erro) {
        if(erro.response?.status === 400) alert(erro.response?.data?.msg);
        else alert(`Erro - ${erro.message}`);
    }
}

const AtualizarTarefas = async () => {

    try {

        const form = document.querySelector("#frmAtualizarTarefas");
        if (!ValidarFormulario(form)) return;        
        const dados = {
            guidId: form.guidId.value,
            dataCadastro: form.dataCadastro.value,
            statusCadastro: form.statusCadastro.checked,
            nome: form.nome.value?.trim(),
            valor: form.valor.value?.replace(/\./g, "").replace(",", ".")
        }
        const response = await AtualizarTarefasService(dados);
        alert(response.msg);
        await RenderizarTarefas(document.querySelector("#app"));
        modalInstance.hide();
    } catch (erro) {
        if(erro.response?.status === 400) alert(erro.response?.data?.msg);
        else alert(`Erro - ${erro.message}`);
    }
}

const DeletarTarefas = async (guidId) => {

    try {

        if (window.confirm("Podemos prosseguir?")){

            const response = await DeletarTarefasService(guidId);
            alert(response.msg);
            await RenderizarTarefas(document.querySelector("#app"));
        }
    } catch (erro) {
        if (erro.response?.status === 400) alert(erro.response?.data?.msg);
        else alert(`Erro - ${erro.message}`);
    }
}

const ValidarFormulario = (form) => {

    let condicao = true;
    form.querySelectorAll("input").forEach(input => {
        if (!input.checkValidity()) {
            input.reportValidity();
            condicao = false;
        } 
    });
    return condicao;
}

document.addEventListener("click", async (e) => {

    const btnRenderizarCriar = e.target.closest("#btnRenderizarCriar");
    if (btnRenderizarCriar) {
        await RenderizarCriarTarefas();
        return;
    }

    const btnCriar = e.target.closest("#btnCriar");
    if (btnCriar) {
        await CriarTarefas();
        return;
    }

    const btnPesquisar = e.target.closest("#btnPesquisar");
    if(btnPesquisar) {
        await PesquisarTarefas();
        return;
    }

    const btnTabelaDeletar = e.target.closest(".btn-tabela-deletar");
    if(btnTabelaDeletar) {
        const guidId = btnTabelaDeletar.dataset.guid;
        await DeletarTarefas(guidId);
        return;
    }

    const btnTabelaAtualizar = e.target.closest(".btn-tabela-atualizar");
    if(btnTabelaAtualizar) {
        const guidId = btnTabelaAtualizar.dataset.guid;
        await RenderizarAtualizarTarefas(guidId);
        return;
    }

    const btnAtualizar = e.target.closest("#btnAtualizar");
    if(btnAtualizar) {
        AtualizarTarefas();
        return;
    }
});