var DT = (function (dt, $, json) {
	var o = dt.deliveries = dt.deliveries || {};

	o.get = function (truck, callback, error) {
		$.ajax({
			type: 'GET',
			cache: false,
			url: 'Deliveries/?truck=' + truck
		}).done(function (data) {
			callback(data);
		}).error(function (jqXHR, textStatus, errorThrown) {			
			dt.handleError(jqXHR, textStatus, errorThrown);
			if (error) error();
		});
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