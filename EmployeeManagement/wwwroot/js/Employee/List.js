function stripHtml(html) {
    var temporalDivElement = document.createElement("div");
    temporalDivElement.innerHTML = html;
    return temporalDivElement.textContent || temporalDivElement.innerText || "";
}
function GetEmpsList() {
    var frmValues = $("#serchform").serialize();
    $.ajax({
        url: "/Employees/GetEmpsList",
        type: "GET",
        data: frmValues,
        success: function (data) {
            $("#userListDiv").html(data);
            buildTable();
        },
        error: function (data) {
            alert("ERROR");
        }
    });
}



document.addEventListener("DOMContentLoaded", function (event) {
    // Datatables with Buttons
    buildTable()

    $("#StartDate").change(function () {
        GetEmpsList();
    });

    $("#EndDate").change(function () {
        GetEmpsList();
    });

    $("#FirstName").change(function () {
        GetEmpsList();
    });

    $("#LastName").change(function () {
        GetEmpsList();
    });

    $(".datetext").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        timePicker: false,
        autoUpdateInput: false,
        opens: "left",
        locale: {
                     ///*server*/   format: "DD.MM.YYYY"
                        /*local */  format: "MM/DD/YYYY"
        }
    });

    $('.datetext').on('apply.daterangepicker', function (ev, picker) {
        $(this).val(picker.startDate.format("MM/DD/YYYY"));
        $(this).trigger("change");
    });

    $('.datetext').on('cancel.daterangepicker', function (ev, picker) {
        $(this).val('');
    });

    $(".select2").each(function () {
        $(this)
            .select2({
                placeholder: "Select value",
                dropdownParent: $(this).parent(),
                allowClear: true,
                width: 'resolve'
            });
    });
    $('.select2-container').attr("style", 'width:inherit');

});




function buildTable() {
    var datatablesButtons = $('#Usersdatatable').DataTable({
        pageLength: 50,
        lengthChange: false,
        responsive: true,
        order: [[0, "asc"]],
        select: true,
        colReorder: true,
        buttons: [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    format: {
                        body: function (data, row, column, node) {
                            // Strip $ from salary column to make it numeric
                            return String(data).includes(",") ? data.replace(",", ".") : stripHtml(data);
                        }
                    }
                }
            },
            {
                extend: 'pdfHtml5',
                title: "Orders List",
                orientation: 'landscape',
                pageSize: 'A3',
            },
            'copy',
            'csv',
            'print'
        ],
    });
    //$.fn.dataTable.moment('MM/DD/YYYY HH:mm:ss');
    datatablesButtons.buttons().container().appendTo("#Usersdatatable_wrapper .col-md-6:eq(0)");
    $(".buttons-html5").addClass("dontprint");
    $(".buttons-print").addClass("dontprint");
    $(".orm-control-sm").addClass("dontprint");
}
