$(document).ready(function () {

    $("#SEPASigned").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        opens: "left",
        locale: {
            format: "DD.MM.YYYY"
        }
    });

    $(".select2").select2({
        placeholder: "---Select---",
    }).change(function () {
        $(this).valid();
    });

    $('.select2-container').attr("style", 'width:inherit');

    $(".select2-container").addClass("is-invalid");

    // Trigger validation on tagsinput change
    $(".shouldvalidate").on("change", function () {
        $(this).valid();
    });




    $('#AddBtn').click(function (e) {
        e.preventDefault();

        var $this = $("#validation-form");
        var frmValues = $this.serialize();
        $.ajax({
            url: "/Employees/Edit",
            type: "POST",
            async: false,
            data: frmValues,
            success: function (response) {
                if (response.success) {
                    window.location.href = '/Employees/List';
                }
                else {
                    alert("An error has been occurred !!!");
                    $('#AddBtn').attr("disabled", false);
                }
            },
            error: function () {
                alert("An error has been occurred !!!");
                hideProgress();
                $('#AddBtn').attr("disabled", false);
            }
        });
    });


});

function DisableDropDown(dropDownId) {
    $(dropDownId).attr("disabled", "disabled");
    $(dropDownId).empty();
}

function PopulateDropDown(dropDownId, list) {
    if (list != null && list.length > 0) {
        $(dropDownId).removeAttr("disabled");
        $.each(list, function () {
            $(dropDownId).append($("<option></option>").val(this['Value']).html(this['Text']));
        });
    }


}