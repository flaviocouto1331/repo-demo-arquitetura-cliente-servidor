export const PegarDataAtual = () => {
     return new Date().toLocaleDateString('pt-br');
}

export const PegarDataAtualComHora = () => {
     return new Date().toLocaleString('pt-br');
}

export const ConverterData = (data) => {
    try {
        return new Date(data).toLocaleDateString('pt-BR');
    } catch (erro) {
        throw new Error(`Erro ao converter data. ${erro.message}`);
    }
}

export const FormatarMoeda = (valor) =>
   new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
   }).format(valor);