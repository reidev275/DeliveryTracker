var DT = (function (dt, $, json) {
    var o = dt.authentications = dt.authentications || {};

    o.create = function (login, callback) {
        $.ajax({
            type: 'POST',
            data: login,
            datatype: 'json',
            cache: false,
            url: 'Authentications'
        }).done(function (data) {
            if (callback) callback(data);
        }).error(function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        });
    };

    return dt;
})(DT || {}, jQuery, JSON);