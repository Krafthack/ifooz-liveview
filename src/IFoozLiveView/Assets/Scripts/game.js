
var game = game || {};

// Updates the game timer
game.startClock = function (time) {

    var clockArray = time.split(':');

    var clock = new Date(0, 1, 1, 0, clockArray[1], clockArray[2], 0);

    function checkTime(i) {
        if (i < 10) { i = "0" + i };
        return i;
    }

    function printTime() {
        var m = clock.getMinutes();
        var s = clock.getSeconds();

        $('#clock').html(checkTime(m) + ":" + checkTime(s));

        clock.setSeconds(s + 1);
        game.clockCounter = setTimeout(function () { printTime() }, 1000);
    }

    printTime();
}

game.stopClock = function () {
    clearTimeout(game.clockCounter);
};


// Draw
game.retrieveAndDrawGameState = function(retrieveGameStateUrl) {


    $.getJSON(retrieveGameStateUrl, function (gameState) {
        game.drawGameState(gameState);
    });
}


game.drawGameState = function (gameState) {



    function drawPlayers(players, selector) {

        $(selector).html("");
        players.forEach(function (player) {
            $(selector).append(' <i class="fa fa-user"></i>' + player.Name);
        });

    }

    function drawScore(data, selector) {
        $(selector).html(data.Blue.Score + ' - ' + data.White.Score);
    }


    function drawGoals(gamestate, selector) {

        var element = $(selector);
        element.html("");

        function getMinute(goal) {

            var startTime = new Date(gamestate.StartTime);
            var goalTime = new Date(goal.Timestamp);
            var delta = new Date(goalTime - startTime);

            return delta.getMinutes();

        }

        gamestate.Goals.forEach(function (goal) {
            element.append(
                '<p>' +
                '<span class="goal-info">' +
                '<i class="fa fa-soccer-ball-o"></i>&nbsp;' + getMinute(goal) +
                "&apos;</span>" +
                '<span class="player-name team-' + goal.Team.toLowerCase() + '">' +
                '<i class="fa fa-user"' +
                '</span>' +
                '</p>'
            );
        });

       
    }
    
    drawPlayers(gameState.Blue.Players, '#blue-players');
    drawPlayers(gameState.White.Players, '#white-players');
    drawScore(gameState, "#score");
    drawGoals(gameState, ".goals-list");

    game.stopClock();
    game.startClock(gameState.Clock);


   

}
