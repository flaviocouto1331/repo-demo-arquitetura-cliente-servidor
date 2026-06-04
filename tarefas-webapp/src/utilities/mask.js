import inputmask from "inputmask"

export const CarregarMask = () => {

    Inputmask("currency", {
        prefix: "",//prefix: "R$ ",
        groupSeparator: ".",
        radixPoint: ",",
        digits: 2,
        digitsOptional: false,
        autoGroup: true,
        rightAlign: false,
        removeMaskOnSubmit: true,
        numericInput: true
    }).mask(".valor-mask");
}