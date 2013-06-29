var DT = (function (dt, ko) {

    var o = dt.viewModels = dt.viewModels || {},
        route = ko.observable(''),
        authCode = ko.observable('');

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

		self.GoToLogin = function () {
		    route('login');
		};

		route('login');	
	};

	o.Login = function () {
	    var self = this;

	    self.UserName = ko.observable('');
	    self.Password = ko.observable('');
	    self.Truck = ko.observable('');
	    self.Trucks = ko.observableArray();
	    dt.trucks.get(self.Trucks);

	    self.Register = function () {
	        route('register');
	    };

	    self.AuthDevice = function () {
	        route('deviceauth');
	    };

	    self.Forgot = function () {
	        route('enterUsername');
	    };

	    self.IsInvalid = ko.computed(function () {
	        return self.UserName() === '' ||
                self.Password() === '' ||
	            typeof self.Truck() === 'undefined';
	    });

	    self.Login = function () {
	        if (!self.IsInvalid()) {
	            var login = {
	                UserName: self.UserName(),
	                Truck: self.Truck(),
	                Password: self.Password()
	            };
	            dt.authentications.create(login, function (data) {
	                self.UserName('');
	                self.Password('');
	                self.Truck('');
	                if (typeof data !== 'undefined') {
	                    authCode(data);
	                    route('welcome');
	                }
	            });
	        }
	    }
	};

	o.Register = function() {
	    var self = this;
	    self.UserName = ko.observable('');
	    self.Password = ko.observable('');
	    self.PasswordConfirm = ko.observable('');
	    self.HintQuestion = ko.observable('');
	    self.HintAnswer = ko.observable('');

	    self.IsInvalid = ko.computed(function () {
	        return !(self.UserName() !== '' &&
                self.Password() !== '' &&
                self.PasswordConfirm() !== '' &&
                self.HintQuestion() !== '' &&
                self.HintAnswer() !== '' &&
                self.Password() === self.PasswordConfirm());
	    });

	    self.Register = function () {
	        if (!self.IsInvalid()) {
	            var user = {
	                Name: self.UserName(),
	                Password: self.Password(),
	                HintQuestion: self.HintQuestion(),
	                HintAnswer: self.HintAnswer()
	            };
	            dt.users.create(user, function () {
	                route('login');
	                self.UserName('');
	                self.Password('');
	                self.PasswordConfirm('');
	                self.HintQuestion('');
	                self.HintAnswer('');
	            });
	        }
	    };
	};

	o.DeviceAuth = function() {
	    var self = this;
	    self.deviceAuth = ko.observable('');
	    self.deviceName = ko.observable('');
	    self.IsInvalid = ko.computed(function () {
	        return self.deviceAuth() === '' ||
	            self.deviceName() === '';
	    });
	    self.setAuthCode = function () {
	        if (!self.IsInvalid()) {
	            var device = {
	                AuthCode: self.deviceAuth(),
                    Name: self.deviceName()
	            };
	            dt.authentications.setDeviceAuth(device);
	            self.deviceAuth('');
	            route('login');
	        }
	    };
	};

	o.ForgotPassword = function() {
	    var self = this;

	    self.UserName = ko.observable('');
	    self.HintQuestion = ko.observable('');
	    self.HintAnswer = ko.observable('');

	    self.Password = ko.observable('');
	    self.PasswordConfirm = ko.observable('');

	    self.UserIsInvalid = ko.computed(function () {
	        return self.UserName() === '';
	    });

	    self.SubmitUserName = function () {
	        if (!self.UserIsInvalid()) {
	            dt.users.getHint(self.UserName(), self.HintQuestion);
	            route('passwordHint');
	        }
	    };

	    self.IsInvalid = ko.computed(function () {
	        return !(self.HintAnswer() !== '' &&
                self.Password() !== '' &&
                self.PasswordConfirm() !== '' &&
                self.Password() === self.PasswordConfirm());
	    });

	    self.SavePassword = function () {
	        if (!self.IsInvalid()) {
	            var user = {
	                Name: self.UserName(),
	                Password: self.Password(),
	                HintAnswer: self.HintAnswer(),
                    HintQuestion: self.HintQuestion()
	            };
	            dt.users.update(user, function (success) {
	                self.Password('');
	                self.PasswordConfirm('');
	                self.HintAnswer('');
	                self.UserName('');
	                self.HintQuestion('');
	                if (success) alert('Password Changed');
	                route('login');
	            });                
            }
	    };

	};

	return dt;
})(DT || {}, ko);