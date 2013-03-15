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
        }).error(dt.handleError);
    };

    o.setDeviceAuth = function (auth) {
        $.ajax({
            type: 'POST',
            data: { AuthCode: auth },
            datatype: 'json',
            cache: false,
            url: 'DeviceAuthentications'
        }).done(function (data) {
            $.cookie(deviceCookie, data, { expires: 365, path: '/' });
            $.ajaxSetup({
                headers: { "EmpireDevice": auth }
            });
        }).error(dt.handleError);
    };

    o.getDeviceAuth = function () {
        return $.cookie(deviceCookie);
    }

    return dt;
})(DT || {}, jQuery, JSON);