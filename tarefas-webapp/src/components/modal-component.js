export const ModalComponent = (titulo) => {

    return `
        <div class="modal fade" id="modal-tarefas-criar" tabindex="-1">
            <div class="modal-dialog" style="max-width: 95% !important; --bs-modal-width: 95% !important">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">${titulo}</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body"></div>
                </div>
            </div>  
        </div>
    `
}