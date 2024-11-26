
function SubirArchivo() {

    $("#FileArchivo").click();
}

function ValidaUploadFile() {

    var fileInput = document.getElementById('FileArchivo');

    console.log(fileInput.files);
}