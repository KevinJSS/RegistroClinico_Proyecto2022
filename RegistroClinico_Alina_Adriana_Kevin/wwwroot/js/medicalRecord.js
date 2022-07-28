var dataTable;

$(document).ready(function () {
    loadIllnessesTable();
    loadTreatmentsTable();
    loadMedicamentsTable();
});

function loadIllnessesTable() {
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
                                <a onClick=Delete1('/Medic/Illness/Delete/${data}') class="btn btn-danger">
							    Suspender</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}

function Delete1(_url) {
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

function loadTreatmentsTable() {
    let pId = document.getElementById("PatientId").textContent;

    dataTable = $('#tblData1').DataTable({
        "ajax": {
            "url": `/Medic/Patient/GetPatientTreatments?id=${pId}`
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "description", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a onClick=Delete2('/Medic/Illness/Delete/${data}') class="btn btn-danger">
							    Suspender</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}

function Delete2(_url) {
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

function loadMedicamentsTable() {
    let pId = document.getElementById("PatientId").textContent;

    dataTable = $('#tblData2').DataTable({
        "ajax": {
            "url": `/Medic/Patient/GetPatientMedicaments?id=${pId}`
        },
        "columns": [
            { "data": "name", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a onClick=Delete3('/Medic/Illness/Delete/${data}') class="btn btn-danger">
							    Suspender</a>
                            </div>`
                },
                "width": "30%"
            }
        ]
    });
}

function Delete3(_url) {
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