export function copyToClipboard(containerElement) {

    const inputElement =
        containerElement.querySelector("input:not([type='hidden'])") ||
        containerElement.querySelector("textarea");

    if (inputElement !== null) {
        inputElement.focus();
        navigator.clipboard.writeText(inputElement.value);
        return;
    }

    const anchorElement = containerElement.querySelector("a")
    if (anchorElement !== null) {
        anchorElement.focus();
        navigator.clipboard.writeText(anchorElement.textContent);
        return;
    }

    navigator.clipboard.writeText(containerElement.textContent.trim());
}