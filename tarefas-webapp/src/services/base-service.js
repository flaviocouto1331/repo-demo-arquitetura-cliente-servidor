// HTML

export const RenderizarService = async (url) => {

    const response = await fetch(url);
    const html = await response.text();
    return html;
}