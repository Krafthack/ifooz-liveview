
var gameindex = gameindex || {};

// Updates the game timer
gameindex.startClock = function () {

    var clockArray = $('#clock').html().split(':');

    var clock = new Date(0, 1, 1, 0, clockArray[0], clockArray[1], 0);

    function checkTime(i) {
        if (i < 10) { i = "0" + i };
        return i;
    }

    function printTime() {
        var m = clock.getMinutes();
        var s = clock.getSeconds();

        $('#clock').html(checkTime(m) + ":" + checkTime(s));

        clock.setSeconds(s + 1);
        setTimeout(function () { printTime() }, 1000);
    }


    printTime();
}

$(document).ready(function () {
    gameindex.startClock();
});