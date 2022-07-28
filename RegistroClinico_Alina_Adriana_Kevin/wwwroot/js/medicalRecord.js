var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable(id) {
    let pId = document.getElementById("PatientId").textContent;

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": `/Medic/Patient/GetPatientIllnesses?id=${pId}`
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "description", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a onClick=Delete('/Medic/Illness/Delete/${data}') class="btn btn-danger">
							    Suspender</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}

function Delete(_url) {
    Swal.fire({
        title: '¿Estás seguro(a) de suspender este padecimiento?',
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