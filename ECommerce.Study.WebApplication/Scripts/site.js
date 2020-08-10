
function deleteProduct(stockCode) {
    if (stockCode == "")
        return;

    $.ajax({
        url: window.location.origin + "/Product/Delete?stockCode=" + stockCode,
        type: "GET",
        complete: deleteResponse
    });
}

function deleteResponse(xhr, textStatus) {
    var message = "";
    if (xhr.status == 200) {
        message = "Silme başarılı.";
    } else if (xhr.status == 404) {
        message = "Ürün bulunamadı.";
    } else {
        message = "Ürün silme işlemi sırasında bir hata oluştu";
    }

    alert(message);
    window.location.assign(window.location.origin + "/Product/Index");
}