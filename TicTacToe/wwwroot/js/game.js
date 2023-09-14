$(function () {
    // by default, the FindGame button should be disabled until a connection to the Hub is made
    // but the username textbox is enabled until the game has started
    disableInput();
    $('#username').removeAttr('disabled');

    // CLIENT STATE
    // The ID of this player
    let playerId;

    // Create a SignalR connection instance
    var gameHub = new signalR.HubConnectionBuilder()
        .withUrl("/gameHub") // Use the correct URL for your SignalR hub
        .build();

    // Start the connection
    gameHub.start()
        .then(() => {
            // Connection is successfully established
            // Enable the FindGame button
            enableInput();
        })
        .catch(error => {
            console.error(error);
        });

    // CLIENT METHODS
    // Prevent players from joining again
    gameHub.on("playerJoined", (player) => {
        playerId = player['id'];
        $('#usernameGroup').removeClass("has-error");
        disableInput();
    });

    // The username is already taken
    gameHub.on("usernameTaken", () => {
        $('#status').html("The username is already taken.");
        $('#usernameGroup').addClass("has-error");
    });

    // The opponent left, so the game is over and allow the player to find a new game
    gameHub.on("opponentLeft", () => {
        $('#status').html("Opponent has left. Game over.");
        endGame();
    });

    // Notify the player that they are in a waiting pool for another opponent
    gameHub.on("waitingList", () => {
        $('#status').html("Waiting for an opponent.");
    });

    // Starts a new game by displaying the board and showing whose turn it is
    gameHub.on("startGame", (game) => {
        let jsonObject = JSON.parse(game);
        buildBoard(jsonObject['Board']);
        const opponent = getOpponent(jsonObject);
        displayOpponent(opponent);
        displayTurn(jsonObject.WhoseTurn, true);
    });

    // Handles the case where a user tried to place a piece not on their turn
    gameHub.on("notPlayersTurn", () => {
        $('#status').html("Please wait your turn.");
    });

    // Display a message if the move is not valid
    gameHub.on("notValidMove", () => {
        $('#status').html("Please choose another location.");
    });

    // A piece has been placed on the board
    gameHub.on("piecePlaced", (row, col, piece) => {
        $('td[id='+row + '-' + col+']').html(piece);
    });

    // TODO: can be combined with piecePlaced by having the server
    // send the whole game object, render the board and update in one method
    gameHub.on("updateTurn", (game) => {
        let jsonObject = JSON.parse(game);
        displayTurn(jsonObject.WhoseTurn);
    });

    // Handle the tie game - game over scenario
    gameHub.on("tieGame", () => {
        $('#status').html("Tie!");
        endGame();
    });

    // Handle the tie game - game over scenario
    gameHub.on("winner", (playerName) => {
        $('#status').html("Winner: " + playerName);
        endGame();
    });

    // CLIENT BEHAVIORS
    // Call the server to find a game if the button is clicked
    $('#findGame').click(() => {
        const chosenUsername = $('#username').val();
        gameHub.invoke("FindGame", chosenUsername);
    });

    // Pressing 'Enter' will automatically click the Find Game button
    $('#username').keypress(function (e) {
        if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {
            $('#findGame').click();
            return false;
        }

        return true;
    });

    // Enables username and Find Game inputs
    function enableInput() {
        $('#username').removeAttr('disabled');
        $('#findGame').removeAttr('disabled');
        $('#username').focus();
    }

    // Disables username and Find Game inputs
    function disableInput() {
        $('#username').attr('disabled', 'disabled');
        $('#findGame').attr('disabled', 'disabled');
    }

    // Game over business logic should disable board button handlers and
    // allow the player to join a new game
    function endGame() {
        // Remove click handlers from board positions
        $('td[id^=pos-]').off('click');
        enableInput();
    }

    // Display whose turn it is
    function displayTurn(playersTurn, isDisplayingOpponent) {
        let turnMessage = "";
        if (playerId == playersTurn.Id) {
            turnMessage = "Your turn";
        } else {
            turnMessage = playersTurn.Name + "\'s turn";
        }

        // Do not overwrite opponent's name if it is being displayed
        if (isDisplayingOpponent) {
            $('#status').html($('#status').html() + turnMessage);
        } else {
            $('#status').html(turnMessage);
        }
    }

    // Displays the opponent's name
    function displayOpponent(opponent) {
        $('#status').html("You are playing against: " + opponent.Name + "<br />");
    }
  
    // Build and display the board
    function buildBoard(board) {
        $("#board").html("");
        $('#tableHidden').removeAttr('hidden');
        let tr = document.createElement('tr');
        for (let i = 0; i < 9; i++) {
            if (i % 3 == 0 && i != 0) {
                $('#board').append(tr);
                tr = document.createElement('tr');
            }
            let td = document.createElement('td');
            td.id = (i % 3) + "-" + Math.floor(i / 3);
            tr.append(td);
        }
        $('#board').append(tr);
 
        // attach click handlers to each position
        $("td").click(function () {
            const id = this.id; // "pos-0-0"
            const parts = id.split("-"); // [pos, 0, 0]
            const row = parseInt(parts[0]);
            const col = parseInt(parts[1]);
            gameHub.invoke("PlacePiece", row, col);
        });
    }

    // Retrieves the opponent player from the game
    function getOpponent(game) {
        if (playerId == game.Player1.Id) {
            return game.Player2;
        } else {
            return game.Player1;
        }
    }
});
