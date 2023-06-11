function onload() {
    $(function () {
        $("#dialog").dialog({
            autoOpen: false
        });
    });
}
function openModal(id) {
    window.deleteContext = id;
    $("#dialog").dialog('open');
}
function closeModal() {
    window.deleteContext = null;
    $("#dialog").dialog('close');
}
function deleteItem() {
    const elementID = "deleteLink" + window.deleteContext;
    document.getElementById(elementID).click();
    closeModal();
}