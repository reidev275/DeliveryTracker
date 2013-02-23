var DT = (function (dt, $, json) {
    var o = dt.users = dt.users || {};

    o.create = function (user, callback) {
        $.ajax({
            type: 'POST',
            data: user,
            datatype: 'json',
            cache: false,
            url: 'Users'
        }).done(function (data) {
            if (callback) callback(data);
        }).error(function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        });;
    };

    return dt;
})(DT || {}, jQuery, JSON);