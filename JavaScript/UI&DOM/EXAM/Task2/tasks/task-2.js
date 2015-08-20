function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // you are welcome :)
        var date = new Date();

        console.log(date.getDayName());
        console.log(date.getMonthName());

        var $this = this;
        var $root = $('body');
        $this.addClass('datepicker');
        var $thisWrapper = $('<div/>').addClass('datepicker-wrapper').append($this);
        $thisWrapper.appendTo($('body').children().first());

        var $picker = $('<div />').addClass('picker');
        $picker.appendTo($thisWrapper);

        var $controls = $('<div/>').addClass('controls');
        var $button = $('<button/>').addClass('btn');
        $controls.append($button.clone().text('<'));
        var $currentMonth = $('<div/>').addClass('current-month').text(date.getMonthName() + ' ' + date.getFullYear());
        $controls.append($currentMonth);
        $controls.append($button.clone().text('>'));
        $picker.append($controls);

        var $calendar = $('<table/>').addClass('calendar');
        var $calendarHead = $('<thead/>');
        var calendarHeadText = '<thead>';
        for (var i = 0; i < WEEK_DAY_NAMES.length; i++) {
            var currentDay = WEEK_DAY_NAMES[i];
            calendarHeadText += '<th>' + currentDay + '</th>';
        }
        calendarHeadText += '</thead>';
        $calendarHead.html(calendarHeadText);
        $calendar.append($calendarHead);



        var $currentDateLink = $('<div/>').addClass('current-date-link').addClass('current-date');
        $currentDateLink.text(date.getDay() + ' ' + date.getMonthName() + ' ' + date.getFullYear());

        $picker.append($calendar);
        $picker.append($currentDateLink);

        $thisWrapper.on('click','input',function() {
            $picker.addClass('picker-visible');
        });

        $thisWrapper.click();

        $root.on('click',function(e) {
            var $target = $(e.target);
            if(!$target.hasClass('datepicker')) {
                $picker.removeClass('picker-visible');
                refreshDays();
            }
        });

        function getDaysInMonth(month, year) {
            var date = new Date(year, month, 1);
            var days = [];
            while (date.getMonth() === month) {
                days.push(new Date(date));
                date.setDate(date.getDate() + 1);
            }
            return days;
        }

        function refreshDays() {
            var days = getDaysInMonth(date.getMonth(), date.getFullYear());
            var everything = $calendar.html();
            for (var i = 0; i < days.length; i++) {
                var day = days[i].getDay();
                if(i%7 === 0) {
                    everything += '<tr>'
                }

                everything += '<td>' + day + '</td>';

                if(i%7 === 0) {
                    everything += '</tr>';
                }
            }
            $calendar.html(everything)
        }

        return $this;
    };
}

module.exports = solve;