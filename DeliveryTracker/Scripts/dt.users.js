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
        }).error(dt.handleError);
    };

    o.getHint = function (user, callback) {
        $.ajax({
            type: 'GET',
            url: 'Hints/' + user
        }).done(function (data) {
            if (callback) callback(data);
        }).error(dt.handleError);
    };

    o.update = function (user, callback) {
        $.ajax({
            type: 'PUT',
            data: user,
            url: 'Users/' + user.Name,
            datatype: 'json',
            cache: false
        }).done(function (data) {
            if (callback) callback(data);
        }).error(dt.handleError);
    };

    return dt;
})(DT || {}, jQuery, JSON);