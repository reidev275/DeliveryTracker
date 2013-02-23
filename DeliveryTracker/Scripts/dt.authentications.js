var DT = (function (dt, $, json) {
    var o = dt.authentications = dt.authentications || {},
        deviceCookie = 'dtdeviceauth';

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

    o.setDeviceAuth = function (auth) {
        $.cookie(deviceCookie, auth, { expires: 365, path: '/' });
    };

    o.getDeviceAuth = function () {
        return $.cookie(deviceCookie);
    }

    return dt;
})(DT || {}, jQuery, JSON);