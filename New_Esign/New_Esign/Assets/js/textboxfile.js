$(document).ready(function () {
    $("#EMPLOYEE_NO").change(function () {
        var reg = $("#EMPLOYEE_NO").val();
        var json = { empNo: reg };
        $.ajax({
            type: "POST",
            url: '@Url.Action("/getNameEmp2")',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                //$.each(data, function (key, value) {
                //var name = value.StudentName;
                //alert(key.StudentName);
                $("#OWNER").val(data);
                //$dfd.
                //});
                //alert(data);
            },
            error: function (error) {
                alert(error);
            }
        });
    });
});