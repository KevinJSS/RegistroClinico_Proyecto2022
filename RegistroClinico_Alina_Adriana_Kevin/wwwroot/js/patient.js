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
function Delete(_url) {
    Swal.fire({
        title: '¿Estás seguro(a) de eliminar este paciente?',
        text: "¡No podrás revertir los cambios!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '¡Sí, estoy de acuerdo!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: _url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}