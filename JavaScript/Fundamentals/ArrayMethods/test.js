
    var field = [];

    var counter = 1;

    for (var i = 0; i < 2; i++) {
        field[i] = [];
        for (var j = 0; j < 3; j++) {
            field[i][j] = counter++;
        }
    }

    console.log(field);
