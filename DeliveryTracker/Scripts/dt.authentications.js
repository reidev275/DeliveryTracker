var DT = (function (dt, $) {
    var o = dt.authentications = dt.authentications || {},
        deviceCookie = 'dtdeviceauth',
        authCookie = 'dtuserauth';


    o.create = function (login, callback) {
        $.ajax({
            type: 'POST',
            data: login,
            datatype: 'json',
            cache: false,
            url: 'Authentications'
        }).done(function (data) {
            $.cookie(authCookie, data, { expires: 1, path: '/' });
            headers.UserAuth = data;
            $.ajaxSetup({
                headers: headers
            });
            if (callback) callback(data);
        }).error(dt.handleError);
    };

    o.setDeviceAuth = function (auth) {
        $.ajax({
            type: 'POST',
            data: auth,
            datatype: 'json',
            cache: false,
            url: 'DeviceAuthentications'
        }).done(function (data) {
            $.cookie(deviceCookie, data, { expires: 365, path: '/' });
            headers.DeviceAuth = data;
            $.ajaxSetup({
                headers: headers
            });
        }).error(dt.handleError);
    };

    o.getDeviceAuth = function () {
        return $.cookie(deviceCookie);
    };

    o.getUserAuth = function () {
        return $.cookie(authCookie);
    };

    o.getAuthHeaders = function () {
        return {
            "DeviceAuth": o.getDeviceAuth(),
            "UserAuth": o.getUserAuth()
        };
    };

    var headers = {
        "DeviceAuth": o.getDeviceAuth(),
        "UserAuth": o.getUserAuth()
    };

    return dt;
})(DT || {}, jQuery);