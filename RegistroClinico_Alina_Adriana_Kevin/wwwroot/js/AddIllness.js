var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    const sep = "@"
    const pId = document.getElementById("PatientId").textContent;

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Medic/Illness/GetAll"
        },
        "columns": [
            { "data": "name", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Medic/Patient/AddIllnessPost?id=${data + sep + pId}"
                                   class="btn btn-secondary ml-2">Agregar</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}

function Delete(_url) {
    Swal.fire({
        title: '¿Estás seguro(a) de eliminar este padecimiento?',
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