function solve() {
    return function (selector) {
        var template =
        '<div class="events-calendar">' +
            '{{#with this}}' +
                '<h2 class="header">' +
                'Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>' +
                '</h2>' +
                '{{#this.days}}' +
                    '<div class="col-date">' +
                    '<div class="date">{{day}}</div>' +
                    '<div class="events">' +
                        '{{#this.events}}' +
                            '<div class="event {{importance}}" {{#if comment}}title="{{comment}}"{{/if}}>' +
                            '<div class="title">{{#if title}}{{title}}{{else}}Free slot{{/if}}</div>' +
                            '{{#if time}}' +
                                '<span class="time">at: {{time}}</span>' +
                            '{{/if}}' +
                            '</div>' +
                        '{{/this.events}}' +
                    '</div>' +
                    '</div>' +
                '{{/this.days}}' +
            '{{/with}}' +
        '</div>';
        document.getElementById(selector).innerHTML = template;
    };
}

module.exports = solve;