var DT = (function (dt, ko) {

    var o = dt.viewModels = dt.viewModels || {},
        route = ko.observable(''),
        authCode = ko.observable(''),
        deviceAuth = ko.observable(dt.authentications.getDeviceAuth());


	o.Page = function (template, data) {
		var self = this;

		self.template = template;
		self.data = data;
	};

	o.ViewModel = function (pages) {
		var self = this;
		self.pages = ko.observableArray(pages);
		self.selectedPage = ko.observable();
		self.authCode;

		deviceAuth.subscribe(function (value) {
		    if (typeof value == 'undefined') route('deviceauth');
		});

		authCode.subscribe(function (value) {
		    self.authCode = value;
		});

		route.subscribe(function (value) {
		    if (value === '') return;

		    for (var i = 0; i < self.pages().length; i++) {
		        if (self.pages()[i].template === value) {
		            self.selectedPage(self.pages()[i]);
		            return;
		        }
		    }
		    alert('Page: ' + value + ' not found.');
		});

		route('login');

		if (typeof deviceAuth() == 'undefined') route('deviceauth');		
	};

	o.Login = function () {
	    var self = this;

	    self.UserName = ko.observable('');
	    self.Password = ko.observable('');
	    self.Truck = ko.observable('');

	    self.Register = function () {
	        route('register');
	    }

	    self.Login = function () {
	        var login = {
	            UserId: self.UserName(),
	            Truck: self.Truck(),
                Password: self.Password()
	        };
	        dt.authentications.create(login, function (data) {
	            if (typeof data !== 'undefined') {
	                authCode(data);
	                route('welcome');
	            }
	        });
	    }
	};

	o.Register = function () {
	    var self = this;
	    self.UserName = ko.observable('');
	    self.Password = ko.observable('');
	    self.PasswordConfirm = ko.observable('');
	    self.HintQuestion = ko.observable('');
	    self.HintAnswer = ko.observable('');

	    self.Register = function () {
	        var user = {
	            Id: self.UserName(),
	            Password: self.Password(),
	            HintQuestion: self.HintQuestion(),
                HintAnswer: self.HintAnswer()
	        };
	        dt.users.create(user, function() {
	            route('login');
	        });
	    };
	};

	o.DeviceAuth = function () {
	    var self = this;
	    self.deviceAuth = ko.observable();
	    self.setAuthCode = function () {
	        dt.authentications.setDeviceAuth(self.deviceAuth());
	    };

	    if (typeof authCode() == 'undefined') route('deviceauth');
	};

	return dt;
})(DT || {}, ko);