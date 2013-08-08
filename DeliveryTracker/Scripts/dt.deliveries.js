var DT = (function (dt, $, json) {
	var o = dt.deliveries = dt.deliveries || {};

	o.get = function (truck, callback) {
		$.ajax({
			type: 'GET',
			cache: false,
			url: 'Deliveries/?truck=' + truck
		}).done(function (data) {
			callback(data);
		}).error(dt.handleError);
	};

	o.update = function (id, delivery, callback) {
		$.ajax({
			type: 'PUT',
			data: delivery,
			url: 'Deliveries/' + id,
			datatype: 'json',
			cache: false
		}).done(function (data) {
			if (callback) callback(data);
		}).error(dt.handleError);
	};

	return dt;
})(DT || {}, jQuery, JSON);