(function (ko, $) {
	var run = function (element, valueAccessor) {
		var value = valueAccessor();
		if (value === '') value == null;
		if (value) $(element).addClass('has-success').removeClass('has-error');
		else $(element).addClass('has-error').removeClass('has-success');
	};

	ko.bindingHandlers.validate = {
		init: run,
		update: run
	};
}(ko, jQuery));