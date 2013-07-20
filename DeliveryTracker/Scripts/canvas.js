(function ($) {
    var getCoordinates = function(e, obj) {
        e.preventDefault();
        var touch = e.originalEvent.touches[0] || e.originalEvent.changedTouches[0],
            elm = $(obj).offset(),
            x = touch.pageX - elm.left,
            y = touch.pageY - elm.top;
        return { X: x, Y: y };
    };

    $.fn.Expand = function () {
        if (this[0] && this[0].getContext) {
            var canvas = this[0],
                context = canvas.getContext("2d");

            context.canvas.width = this.parent().width();
            context.canvas.height = this.parent().height();
        }
        return this;
    };

    $.fn.PenTool = function () {
        if (this[0] && this[0].getContext) {
            var canvas = this[0],
                context = canvas.getContext("2d"),
                isMouseDown = false;

            this.mousedown(function (e) {
                isMouseDown = true;
                context.moveTo(e.offsetX, e.offsetY);
            }).mouseup(function () {
                isMouseDown = false;
            }).mousemove(function (e) {
                if (isMouseDown) {
                    drawTo(e.offsetX, e.offsetY);
                }
            });

            $(document).delegate(this, 'touchmove', function (e) {
                if (isMouseDown) {
                    var coords = getCoordinates(e, this);
                    drawTo(coords.X, coords.Y);
                }
            }).delegate(this, 'touchstart', function (e) {
                isMouseDown = true;
                var coords = getCoordinates(e, this);
                context.moveTo(coords.X, coords.Y);
            }).delegate(this, 'touchend', function (e) {
                isMouseDown = false;
            });

            var drawTo = function (x, y) {
                context.lineTo(x, y);
                context.stroke();
            };


            this.clearPen = function () {
                context.clearRect(0, 0, canvas.width, canvas.height);
                context.beginPath();
            };
        }

        return this;
    };

    $.fn.TopazTool = function () {

        if (this[0] && this[0].getContext) {
            var canvas = this[0],
                context = canvas.getContext("2d"),
                isMouseDown = false,
                points = [],
                penups = [];

            this.mousedown(function (e) {
                isMouseDown = true;
                points.push({ X: e.offsetX, Y: e.offsetY });
            }).mouseup(function () {
                isMouseDown = false;
                penups.push(points.length);
            }).mousemove(function (e) {
                if (isMouseDown) {
                    points.push({ X: e.offsetX, Y: e.offsetY });
                }
            });

            $(document).delegate(this, 'touchmove', function (e) {
                if (isMouseDown) {
                    var coords = getCoordinates(e, this);
                    points.push({ X: coords.X, Y: coords.Y });
                }
            }).delegate(this, 'touchstart', function (e) {
                isMouseDown = true;
                var coords = getCoordinates(e, this);
                points.push({ X: coords.X, Y: coords.Y });
            }).delegate(this, 'touchend', function (e) {
                isMouseDown = false;
                penups.push(points.length);
            });

            this.clearTopaz = function () {
                points = [],
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