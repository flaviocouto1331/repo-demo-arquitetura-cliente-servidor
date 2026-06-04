// Utilitário para configuração de modais do Bootstrap, garantindo que o foco seja removido ao fechar o modal e que os recursos sejam liberados corretamente.
export const ConfigurarModal = (modalApp, modalElement, modalInstance) => {

    modalElement.addEventListener("hide.bs.modal", () => {
        const activeElement = modalElement.querySelector(":focus");
        if (activeElement) {
            activeElement.blur();
        }   
        modalElement.blur();    
    });
    modalElement.addEventListener("hidden.bs.modal", () => {
        modalInstance.dispose();
        modalApp.innerHTML = "";
    });
}

/*

// DEMO Modal Bootstrap 5 - Vanilla JS

// Master Page 

<div id="modal-app"></div>

// Content Modal Page

<div class="modal fade" id="modal-criar-tarefas" tabindex="-1">
    <div class="modal-dialog" style="max-width: 95% !important; --bs-modal-width: 95% !important">
        <div class="modal-content">
            <div class="modal-header">            
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">

                <div class="card">
                    <div class="card-header">Tarefas/<b>Criar</b></div>
                    <div class="card-body">
                            
                        <form id="frmCriarTarefas">
                            <div class="row">
                                <div class="col-6">
                                    <label for="nome">Nome:</label>
                                    <input type="text" id="nome" class="form-control" maxlength="200" required />
                                </div>
                                <div class="col-6">
                                    <label for="valor">Valor:</label>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text">R$</span>
                                        <input type="text" id="valor" class="form-control valor-mask" required />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12 d-flex justify-content-end">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close">Cancelar</button>&nbsp;
                                    <button type="button" id="btn-criar" class="btn btn-primary">Criar</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</div>

// Vanilla JS

let modalApp = null;
let modalElement = null;
let modalInstance = null;

// Abrir Modal

modalApp = document.querySelector("#modal-app");  
modalApp.innerHTML = html;
modalElement = modalApp.querySelector("#modal-criar-tarefas");
modalInstance = Modal.getInstance(modalElement);
if (!modalInstance) {
    modalInstance = new Modal(modalElement);
    ConfigurarModal(modalApp, modalElement, modalInstance);
}
modalInstance.show();

// Fechar Modal

modalInstance.hide();

*/