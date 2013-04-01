var DT = (function (dt, json) {
    dt.handleError = function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseText) {
            var response = json.parse(jqXHR.responseText);
            if (typeof response.ExceptionMessage === "string") {
                alert(response.ExceptionMessage);
                return;
            }
        }
        alert(errorThrown);
    };
    return dt;
})(DT || {}, JSON);