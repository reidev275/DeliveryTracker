var DT = (function (dt) {
    dt.handleError = function (jqXHR, textStatus, errorThrown) {
        alert(errorThrown);
    };
    return dt;
})(DT || {});