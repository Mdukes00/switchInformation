$.extend(
    $.expr[':'], {
        match: function (a, i, m, r) {
            var r = new RegExp("^" + m[3] + "$");
            return r.test($(a).text());
        }
    },
    $.expr[':'], {
        matchi: function (a, i, m, r) {
            var r = new RegExp("^" + m[3] + "$", 'i');
            return r.test($(a).text());
        }
    }
);

$(document).ready(function () {
    // Match on uppercase Y
    $('#tab td.ls:match(Up)').css('background-color', '#fcc');
    // Match on uppercase N
    $('#tab td.ls:match(Down)').css('background-color', '#98f');
    // Match on lowercase y
    $('#tab td.ls:match(Testing)').css('background-color', '#111111');

});