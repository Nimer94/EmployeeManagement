document.addEventListener("DOMContentLoaded", function (event) {
    $('#SaveContactbtn').on("click", function (e) {
        e.preventDefault();
        $(this).attr("disabled", true);
        var frmValues = $("#EditContact").serialize();
        $.ajax({
            url: "/Employees/SaveContact",
            data: frmValues,
            type: "POST",
            success: function (data) {
                if (data.success) {
                    $('#ContactModal').modal("hide");
                    window.location.reload();
                }
                else {

                }
            },
            error: function (data) {
                $(this).attr("disabled", false);
                alert("ERROR");
            }
        });
    });

    $('.editcontact').on("click", function (e) {
        var id1 = $(this).val();
        $(this).attr("disabled", true);
        $.ajax({
            url: "/Employees/GetEmployeeContact/" + id1,
            type: "POST",
            success: function (data) {
                $('.editcontact').attr("disabled", false);
                $("#MobileNumber").val(data.MobileNumber).removeClass("is-invalid");
                $("#Comment").val(data.Email);
                $("#Email").val(data.Email);
                $("#ContactID").val(data.ContactID);
                $("#PhoneNumber").val(data.PhoneNumber);
                $("#EmployeeID").val(data.EmployeeID);
                $("#Title").val(data.Title).removeClass("is-invalid");
                $("#ContactType").val(data.ContactType).removeClass("is-invalid");
                $("#EmployeeContactID").val(data.EmployeeContactID).removeClass("is-invalid");
                $('#ContactModal').modal("show");
            },
            error: function (data) {
                $('.editcontact').attr("disabled", false);
                alert("ERROR");
            }
        });
    });

    $('.deletecontact').click(function () {
        if (confirm('Are you sure?')) {
            $(this).attr("disabled", true);
            $.ajax({
                type: "POST",
                url: '/Employees/DeleteContact/' + $(this).val(),
                success: function (response) {
                    $('.deletecontact').attr("disabled", false);
                    if (response.success) {
                        window.location.reload();
                    }
                    else {
                        alert("Error");
                    }
                },
                error: function () {
                    $('.deletecontact').attr("disabled", false);
                    alert('Failed');
                }
            })
        }
    });

    $('#ContactModal').on('hidden.bs.modal', function () {
        $(this).find("input,textarea,select").val('').end();
    });

});