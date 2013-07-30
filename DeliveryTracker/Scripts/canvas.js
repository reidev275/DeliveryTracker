(function ($) {

    var resize = function (obj) {
        if (obj[0] && obj[0].getContext) {
            var canvas = obj[0],
                context = canvas.getContext("2d");

            context.canvas.width = obj.parent().width();
            context.canvas.height = obj.parent().height();
        }
    }

    $.fn.Expand = function () {
        var self = this;
        resize(self);
        return this;
    };

    var getCoordinates = function (e, obj) {
        e.preventDefault();
        if (e.offsetX) return { X: e.offsetX, Y: e.offsetY };
        var touch = e.originalEvent.touches[0] || e.originalEvent.changedTouches[0],
            elm = $(obj).offset(),
            x = touch.pageX - elm.left,
            y = touch.pageY - elm.top;
        return { X: x, Y: y };
    };

    $.fn.PenTool = function () {
        if (this[0] && this[0].getContext) {
            var canvas = this[0],
                context = canvas.getContext("2d"),
                isMouseDown = false;

            $(document).delegate(this.selector, 'mousemove touchmove', function (e) {
                if (isMouseDown) {
                    var coords = getCoordinates(e, this);
                    context.lineTo(coords.X, coords.Y);
                    context.stroke();
                }
            }).delegate(this.selector, 'mousedown touchstart', function (e) {
                isMouseDown = true;
                var coords = getCoordinates(e, this);
                context.moveTo(coords.X, coords.Y);
            }).delegate(this.selector, 'mouseup touchend', function (e) {
                isMouseDown = false;
            });

            this.clearPen = function () {
                context.clearRect(0, 0, canvas.width, canvas.height);
                context.beginPath();
            };
        }

        return this;
    };

    $.fn.TopazTool = function () {

        if (this[0] && this[0].getContext) {
            var isMouseDown = false,
                points = [],
                penups = [];

            $(document).delegate(this.selector, 'mousemove touchmove', function (e) {
                if (isMouseDown) {
                    var coords = getCoordinates(e, this);
                    points.push(coords);
                }
            }).delegate(this.selector, 'mousedown touchstart', function (e) {
                isMouseDown = true;
                var coords = getCoordinates(e, this);
                points.push(coords);
            }).delegate(this.selector, 'mouseup touchend', function (e) {
                isMouseDown = false;
                penups.push(points.length);
            });

            this.clearTopaz = function () {
                points = [];
                penups = [];
            };

            this.Points = function () {
                return points;
            };

            this.Penups = function () {
                return penups;
            };
        }

        return this;
    };
}(jQuery));