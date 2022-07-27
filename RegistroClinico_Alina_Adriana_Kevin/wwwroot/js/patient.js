var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Medic/Patient/GetAll"
        },
        "columns": [
            { "data": "fullName", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Medic/Patient/Upsert?id=${data}"
                                   class="btn btn-secondary ml-2"> 
							    <i class="bi bi-pencil-square"></i>Expediente</a>

							    <a onClick=Delete('/Medic/Patient/Delete/${data}') class="btn btn-danger">
							    <i class="bi bi-trash"></i>Eliminar</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}