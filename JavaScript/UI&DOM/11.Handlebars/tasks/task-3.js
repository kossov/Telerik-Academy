function solve() {
    return function () {
        $.fn.listview = function (data) {
            var $this = $(this);
            var templateId = $this.data('template'),
                template = $('#' + templateId).html(),
                templateCompiler = handlebars.compile(template);

            for (var i = 0; i < data.length; i++) {
                var obj = data[i];
                this.append(templateCompiler(obj));
            }

            return $this;
        };
    };
}

module.exports = solve;