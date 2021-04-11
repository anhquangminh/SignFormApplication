function getBaseUrl() {
    var url = window.location.href;
    if (url.indexOf('?') > 0) url = url.substring(0, url.indexOf('?'));
    var ad = document.getElementById('path');
    if (ad != null) {
        var area = ad.attributes["data-area"].nodeValue;
        var path = ad.attributes["data-path"].nodeValue;
        url = url.replace('/Index', '');
        path = path.replace('/Index', '');
        url = url.replace(path, '');
        //var pathSplit = path.split('/');
        //for (i = pathSplit.length - 1; i >= 0 ; i--) {
        //    if (pathSplit[i] != '') {
        //        var repStr = '/' + pathSplit[i];
        //        url = url.replace(repStr, '');
        //    }
        //}
        url = url.replace(area, '');
    }
    return url;
}

function SelectLanguageChange() {
    var languageId = $('#LanguageSelector').val();
    console.log(languageId);
    var str = getBaseUrl();
    var arr = str.split(/[/]/);
    
    $.ajax({
        url: 'http://'+arr[2]+'/Language/ChangeLanguage?languageId=' + languageId,
        type: 'GET',
        data: "",
        contentType: "application/json;charset=utf-8",
        cache: false,
        success: function (data) {
            location.reload();
        },
        error: function () {
            location.reload();
            //var a = getBaseUrl() + '/Language/ChangeLanguage?languageId=' + languageId;
            //alert(a);
        }
    })
   
}
$(".label-title-group").click(function(){
    var forFormId = $(this).data("form");
    var form = $("#" + forFormId);
    if (form.hasClass("hidden_form")) {
        form.removeClass("hidden_form");
    } else {
        form.addClass("hidden_form");
    }
})
$(".formSelector").on("change", function () {
    SelectedChange(this);
})
function Filter(ele) {
    SelectedChange(ele);
    $(ele.form).find("input[type=submit]").click();
}
function SelectedChange(ele) {
    var inputField = ele.getAttribute('data-field');
    var value = ele.value;
    document.getElementById(inputField).value = value;
}