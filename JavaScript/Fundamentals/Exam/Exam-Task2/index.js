function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        T = parseInt(params[rows + 2]), i, move;
    var lines = params.slice(2, 2 + rows);
    var hasFigure = [];
    var field = initField(rows, cols, lines);
    for (i = 0; i < T; i++) {
        move = params[rows + 3 + i].split(' ');
        // move[0] what has to be moved
        var positionOfFigure = move[0],
            positionToBeMoved = move[1];
        isValidMove = true;
        var row = positionOfFigure[1],
            col = positionOfFigure[0];
        console.log(move);
        if (field[row][col] !== '-') {
            var figure = field[row][col];
            switch (figure) {
                case 'R':
                    isValidMove = canMoveRook(hasFigure, row, col, positionToBeMoved);
                    if (isValidMove) {
                        hasFigure[row + ' ' + col] = false;
                        row = positionToBeMoved[1];
                        col = positionToBeMoved[0];
                        hasFigure[row + ' ' + col] = true;
                        field[row][col] = 'R';
                    }
                    break;
                case 'Q':
                    if (canMoveRook(hasFigure, row, col, positionToBeMoved) && canMoveBishop(hasFigure, row, col, positionToBeMoved)) {
                        hasFigure[row + ' ' + col] = false;
                        row = positionToBeMoved[1];
                        col = positionToBeMoved[0];
                        hasFigure[row + ' ' + col] = true;
                        field[row][col] = 'Q';
                        isValidMove = true;
                    } else {
                        isValidMove = false;
                    }

                    break;
                case 'B':
                    isValidMove = canMoveBishop(hasFigure, row, col, positionToBeMoved);
                    if (isValidMove) {
                        hasFigure[row + ' ' + col] = false;
                        row = positionToBeMoved[1];
                        col = positionToBeMoved[0];
                        hasFigure[row + ' ' + col] = true;
                        field[row][col] = 'B';
                    }
                    break;
            }
        }

        if (isValidMove) {
            console.log('yes');
        } else {
            console.log('no');
        }
    }

    function canMoveRook(hasFigure, row, col, positionToBeMoved) {
        var rowToBeMoved = positionToBeMoved[1],
            colToBeMoved = positionToBeMoved[0].charCodeAt(0),
            currentRow = row,
            currentCol = col.charCodeAt(0),
            difference = colToBeMoved - currentCol;
        if (row === rowToBeMoved) { // when moving left/right - horizontally
            if (difference > 0) { // moving right ++++
                for (var i = 1; i < difference; i += 1) {
                    if (hasFigure[currentRow] + ' ' + [String.fromCharCode(currentCol + i)]) {
                        return false;
                    }
                }
                return true;
            } else {
                for (var j = currentCol; j >= colToBeMoved; j -= 1) {
                    if (hasFigure[currentRow] + ' ' + [String.fromCharCode(currentCol - j)]) {
                        return false;
                    }
                }
                return true;
            }
        } else if (col === colToBeMoved) { // when moving up/down - vertically
            var differenceCols = currentCol - colToBeMoved;
            if (differenceCols > 0) {
                for (var k = currentCol; k >= differenceCols; k -= 1) {
                    if (hasFigure[String.fromCharCode(currentRow - k)] + ' ' + [currentCol]) {
                        return false;
                    }
                }
                return true
            } else {
                for (var o = currentCol; o < differenceCols; o += 1) {
                    if (hasFigure[String.fromCharCode(currentRow + o)] + ' ' + [currentCol]) {
                        return false;
                    }
                }
            }

        } else {
            return false;
        }
    }

    function canMoveBishop(hasFigure, row, col, positionToBeMoved) {
        var rowToBeMoved = positionToBeMoved[1],
            colToBeMoved = positionToBeMoved[0].charCodeAt(0),
            currentRow = row,
            currentCol = col.charCodeAt(0),
            difference = colToBeMoved - currentCol;
        if (row === rowToBeMoved) { // when moving left/right - horizontally
            if (difference > 0) { // moving right ++++
                for (var i = 1; i < difference; i += 1) {
                    if (hasFigure[currentRow] + ' ' + [String.fromCharCode(currentCol + i)]) {
                        return false;
                    }
                }
                return true;
            } else {
                for (var j = currentCol; j >= colToBeMoved; j -= 1) {
                    if (hasFigure[currentRow] + ' ' + [String.fromCharCode(currentCol - j)]) {
                        return false;
                    }
                }
                return true;
            }
        } else if (col === colToBeMoved) { // when moving up/down - vertically
            var differenceCols = currentCol - colToBeMoved;
            if (differenceCols > 0) {
                for (var k = currentCol; k >= differenceCols; k -= 1) {
                    if (hasFigure[String.fromCharCode(currentRow - k)] + ' ' + [currentCol]) {
                        return false;
                    }
                }
                return true
            } else {
                for (var o = currentCol; o < differenceCols; o += 1) {
                    if (hasFigure[String.fromCharCode(currentRow + o)] + ' ' + [currentCol]) {
                        return false;
                    }
                }
            }

        } else {
            return false;
        }
    }

    function initField(rows, cols, lines) {
        var tempField = [];
        for (var i = 0; i < rows; i += 1) {
            tempField[rows - i] = [];
            var line = lines[i];
            for (var k = 0; k < cols; k += 1) {
                var col = String.fromCharCode(97 + k);
                tempField[rows - i][col] = line[k];
                if (line[k] !== '-') {
                    hasFigure[rows - i + ' ' + col] = true;
                }
            }
        }
        return tempField;
    }
}


var test1 = ['3', '4', '--R-',
        'B--B',
        'Q--Q',
        '12',
        'd1 b3',
        'a1 a3',
        'c3 b2',
        'a1 c1',
        'a1 b2',
        'a1 c3',
        'a2 b3',
        'd2 c1',
        'b1 b2',
        'c3 b1',
        'a2 a3',
        'd1 d3'],
    test2 = ['5', '5',
        'Q---Q',
        '-----',
        '-B---',
        '--R--',
        'Q---Q',
        '10',
        'a1 a1',
        'a1 d4',
        'e1 b4',
        'a5 d2',
        'e5 b2',
        'b3 d5',
        'b3 a2',
        'b3 d1',
        'b3 a4',
        'c2 c5'];
console.log(solve(test1));
console.log(solve(test2));