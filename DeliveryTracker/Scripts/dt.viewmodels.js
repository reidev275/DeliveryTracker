var DT = (function (dt, ko) {

	var o = dt.viewModels = dt.viewModels || {};

	o.Page = function (template, data) {
		var self = this;

		self.template = template;
		self.data = data;
	};

	o.ViewModel = function (pages) {
		var self = this;

		self.pages = ko.observableArray(pages);
		self.selectedPage = ko.observable();

		self.goToPage = function (page) {
		    for (var i = 0; i < self.pages().length; i++) {
		        if (self.pages()[i].template === page) {
		            self.selectedPage(self.pages()[i]);
		            return;
		        }
		    }
		    alert('Page: ' + page + ' not found.');
		};

		if (self.pages().length > 0) self.selectedPage(self.pages()[0]);
	};

	o.Login = function () {
	    var self = this;

	    self.UserName = ko.observable('');
	    self.Password = ko.observable('');
	    self.Truck = ko.observable('');
	};

	o.Register = function () {
	    var self = this;
	    self.UserName = ko.observable('');
	    self.Password = ko.observable('');
	    self.PasswordConfirm = ko.observable('');
	    self.HintQuestion = ko.observable('');
	    self.HintAnswer = ko.observable('');
	};

	return dt;
})(DT || {}, ko);