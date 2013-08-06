(function (ko) {
	ko.extenders.numeric = function (observable, max) {
		var result = ko.computed({
			read: observable,
			write: function (newValue) {
				var current = observable(),
					newValueAsNum = isNaN(newValue) ? 0 : parseFloat(+newValue);
				if (newValueAsNum > max) newValueAsNum = max;
				if (newValueAsNum < 0) newValueAsNum = 0;
				
				observable(newValueAsNum);
			}
		});
		result(observable());

		return result;
	};
}(ko));