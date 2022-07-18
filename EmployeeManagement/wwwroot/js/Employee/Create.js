$(document).ready(function () {
    $('#Save').click(function (e) {
        e.preventDefault();
        var $this = $("#userForm");
        var frmValues = $this.serialize();
        $.ajax({
            type: "POST",
            url: "/Employees/Create",
            data: frmValues,
            success: function (data) {
                if (data.success) {
                    window.location.href = '/Employees/List';
                }
                else {
                    alert("Error");
                }
            }
        });
    });

});
