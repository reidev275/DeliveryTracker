var DT = (function (dt, $, json) {
    var o = dt.trucks = dt.trucks || {};

    o.get = function (callback) {
        $.ajax({
            type: 'GET',
            datatype: 'json',
            url: 'Trucks'
        }).done(function (data) {
            if (callback) callback(data);
        }).error(function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        });;
    };

    return dt;
})(DT || {}, jQuery, JSON);