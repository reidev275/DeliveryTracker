var DT = (function (dt, $, json) {
	var o = dt.deliveries = dt.deliveries || {};

	o.get = function (truck, callback) {
		$.ajax({
			type: 'GET',
			cache: false,
			url: 'Deliveries/?truck=' + truck
		}).done(function (data) {
			callback(data);
		});
	};

	return dt;
})(DT || {}, jQuery, JSON);