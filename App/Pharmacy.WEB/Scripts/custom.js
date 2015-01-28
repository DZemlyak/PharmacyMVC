$(document).ready(function () {
    $("#SelectedMedcineList").change(function () {
        loadData();
    });
    $("#Count").change(function () {
        loadData();
    });
    loadData();
});

function loadData() {
    var $medcine = $("#SelectedMedcineList")[0].value;
    $.ajax({
        type: "Get",
        url: "/OrderDetails/GetPrice",
        data: "medcineId=" + parseInt($medcine),
        success: function (data) {
            setValues(data);
        },
        error: function () {
            alert("error");
        }
    });
}

function setValues(data) {
    var $count = $("#Count")[0].value;
    if (parseInt($count) < 0) return;
    $("#UnitPriceHidden")[0].value = parseInt($count) * data.Price;
    $("#UnitPrice")[0].value = parseInt($count) * data.Price;
}
