var DT = (function (dt, $, json) {
    var o = dt.users = dt.users || {};

    o.create = function (user, callback) {
        $.ajax({
            type: 'POST',
            data: json.stringify(user),
            cache: false,
            url: 'Users'
        }).done(function (data) {
            if (callback) callback(data);
        });
    };

    return dt;
})(DT || {}, jQuery, JSON);