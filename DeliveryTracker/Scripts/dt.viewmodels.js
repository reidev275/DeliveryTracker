var DT = (function (dt, ko, $) {

	var o = dt.viewModels = dt.viewModels || {},
		route = ko.observable(''),
		userAuth = ko.observable(dt.authentications.getUserAuth()),
		truck = ko.observable(),
		Deliveries = ko.observableArray([]);

	var goToDeliveries = function (truck) {
		dt.deliveries.get(truck, function (data) {
			$.each(data, function(index, value) {
				Deliveries.push(new o.Delivery(value));
			});
			route('deliveries');
		}, function () {
			route('login');
		});
	};

	o.Page = function (template, data) {
		var self = this;

		self.template = template;
		self.data = data;
	};

	o.ViewModel = function (pages) {
		var self = this;
		self.pages = ko.observableArray(pages);
		self.selectedPage = ko.observable();
		self.userAuth = userAuth();

		userAuth.subscribe(function (value) {
			self.userAuth = value;
		});

		route.subscribe(function (value) {

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

		if (typeof userAuth() !== 'undefined') {
			dt.authentications.get(userAuth(), function (value) {
				goToDeliveries(value.Truck);
			}, function () {
				self.GoToLogin();
			});
		} else {
			self.GoToLogin();
		}
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
					truck(self.Truck());
					self.UserName('');
					self.Password('');
					self.Truck('');
					if (typeof data !== 'undefined') {
						userAuth(data);
						goToDeliveries(truck());                        
					}
				});
			}
		};
	};

	o.Register = function () {
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

	o.DeviceAuth = function () {
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

	o.ForgotPassword = function () {
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

	o.Deliveries = function () {
		var self = this,
			canvas;

		self.Deliveries = ko.computed(Deliveries).extend({ throttle: 400 });

		self.CurrentDelivery = ko.observable();

		self.goToDelivery = function () {
			if (this.Completed()) return;
			$(window).off('resize','**');
			self.CurrentDelivery(this);
			route('delivery');
		};

		self.goToDeliveries = function () {
			route('deliveries');
		};
		
		self.goToMap = function () {
			route('map');
		};

		self.goToSignature = function () {
			if (self.CurrentDelivery().canSubmit()) return;
			$(window).on('resize', function (e) {
				e.preventDefault();
			});
			route('signature');
			canvas = $("#signatureCanvas").Expand().PenTool().TopazTool();
		};

		self.saveSignature = function () {
			if (self.CurrentDelivery().canSaveSignature()) {
				if (canvas.Points().length > 0) {
					var signature = canvas.Signature();
					self.CurrentDelivery().Signature(signature);
					route('delivery');
				} else {
					alert('No signature to save');
				}
			}
		};

		self.cancelSignature = function () {
			canvas.clearPen();
			canvas.clearTopaz();
		};

		self.SignatureIsInvalid = ko.computed(function () {
			if (canvas && canvas.Points) {
				return canvas.Points().length === 0;
			}
			return false;
		});
	};

	o.Delivery = function (delivery) {
		var self = this;
		self.Id = delivery.Id;
		self.Addr1 = delivery.Addr1;
		self.City = delivery.City;
		self.Company = delivery.Company;
		self.Completed = ko.observable(false);
		self.Contact = delivery.Contact;
		self.Items = [];
		self.Number = delivery.Number;
		self.Phone = delivery.Phone;
		self.PoNumber = delivery.PoNumber;
		self.Signature = ko.observable(delivery.Signature);
		self.Printed = ko.observable(delivery.Printed);
		self.State = delivery.State;
		self.Zip = delivery.Zip;		

		$.each(delivery.Items, function (index, value) {
			self.Items.push(new o.Item(value));
		});

		self.canSaveSignature = ko.computed(function () {
			return self.Printed() && self.Printed() !== '';
		});

		self.submit = function () {
			if (self.canSubmit()) route('submit');
		};

		self.canSubmit = ko.computed(function () {
			return self.Signature() && self.Signature() !== '';
		});

		self.save = function () {
			var obj = {
				Id: self.Id,
				Signature: self.Signature(),
				Printed: self.Printed(),
				Items: []
			};

			$.each(self.Items, function (i, value) {
				obj.Items.push(value.getUnwrapped());
			});

			dt.deliveries.update(self.Id, obj, null, function () {
				self.Completed(false);
			});
			self.Completed(true);
			route('deliveries');
		};
	};

	o.Item = function (item) {
		var self = this;
		self.Id = item.Id;
		self.Number = item.Number;
		self.Description = item.Description;
		self.Allocated = item.Allocated;
		self.Delivered = ko.observable(item.Delivered).extend({ numeric: self.Allocated });

		self.getUnwrapped = function () {
			return {
				Id: self.Id,
				Delivered: self.Delivered()
			}
		}
	};

	return dt;
})(DT || {}, ko, jQuery);