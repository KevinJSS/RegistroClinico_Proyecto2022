var dataTable;

$(document).ready(function () {
    loadAdmins();
    loadMedics();
    loadPatients();
});

function loadAdmins() {
    dataTable = $('#tblData1').DataTable({
        "ajax": {
            "url": "/Admin/Admin/GetAll"
        },
        "columns": [
            { "data": "identification", "width": "30%" },
            { "data": "name", "width": "30%" },
            { "data": "email", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">

							    <a onClick=DeleteAdmin('/Admin/Admin/DeleteAdmin/${data}') class="btn btn-danger">
							    <i class="bi bi-trash"></i>Eliminar</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}
function DeleteAdmin(_url) {
    Swal.fire({
        title: '¿Estás seguro(a) de eliminar este administrador?',
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






function loadMedics() {
    dataTable = $('#tblData2').DataTable({
        "ajax": {
            "url": "/Admin/Medic/GetAll"
        },
        "columns": [
            { "data": "fullName", "width": "30%" },
            { "data": "licenseNumber", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
							    <a onClick=DeleteMedic('/Admin/Medic/Delete/${data}') class="btn btn-danger"> 
							    <i class="bi bi-trash"></i>Eliminar</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}

function DeleteMedic(_url) {
    Swal.fire({
        title: '¿Estás seguro(a) de eliminar este médico?',
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




function loadPatients() {
    dataTable = $('#tblData3').DataTable({
        "ajax": {
            "url": "/Medic/Patient/GetAll"
        },
        "columns": [
            { "data": "fullName", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">

							    <a onClick=DeletePatient('/Medic/Patient/Delete/${data}') class="btn btn-danger">
							    <i class="bi bi-trash"></i>Eliminar</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}
function DeletePatient(_url) {
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
