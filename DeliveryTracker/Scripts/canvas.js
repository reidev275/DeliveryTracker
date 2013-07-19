(function ($) {
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
                    context.lineTo(e.offsetX, e.offsetY);
                    context.stroke();
                }
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