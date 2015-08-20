//region 1.

function first() {
    function solve(params) {
        var N = parseInt(params[0]);
        var args = params.slice(1);
        var arr = args.map(Number);
        var answer = 1,
            tempNumber = arr[0];

        for (var i = 1; i < N; i += 1) {
            if (tempNumber > arr[i]) {
                tempNumber = arr[i];
                answer += 1;
                continue;
            } else {
                tempNumber = arr[i];
            }
        }

        return answer;
    }

    var test1 = [7, '1', 2, -3, 4, 4, 0, 1],
        test2 = [6, 1, 3, -5, 8, 7, -6],
        test3 = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6];

    console.log(solve(test1));
    console.log(solve(test2));

    console.log(solve(test3));
}


//endregion

//region 2.

function two() {

    function solve(params) {
        var sizeOfMatrixAndJumps = params[0].split(' ').map(Number),
            startPositionRowCol = params[1].split(' ').map(Number),
            jumps = params.slice(2).map(function (param) {
                return param.split(' ').map(Number);
            });
        var row = startPositionRowCol[0],
            col = startPositionRowCol[1];
        var rows = sizeOfMatrixAndJumps[0],
            cols = sizeOfMatrixAndJumps[1],
            numberOfJumps = sizeOfMatrixAndJumps[2],
            count = 0,
            sum = 0,
            visited = [];
        var field = initField(rows, cols);

        for (var i = 0; i < numberOfJumps;) {
            //debugger;
            if (row < 0 || col < 0 || row >= rows || col >= cols) {
                return 'escaped ' + sum;
            }
            if (visited[field[row][col]]) {
                return 'caught ' + count;
            }

            sum += field[row][col];
            visited[field[row][col]] = true;
            count += 1;
            row += jumps[i][0];
            col += jumps[i][1];
            if (i + 1 >= numberOfJumps) {
                i = 0;
            } else {
                i += 1;
            }
        }

        function initField(rows, cols) {
            var tempField = [], counter = 1;
            for (var i = 0; i < rows; i += 1) {
                tempField[i] = [];
                for (var j = 0; j < cols; j += 1) {
                    tempField[i][j] = counter;
                    counter += 1;
                }
            }

            return tempField;
        }
    }

    var test1 = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1'];

    console.log(solve(test1));
}
//endregion

//region 3.

function solve(params) {
    var commands = params;

    for (var i = 0; i < commands.length; i += 1) {
        var line = commands[i].split(' ');
        switch (line[k]) {
            case '(def':
                break;
            case '(+':
                break;
            case '(-':
        }
    }


}

var test1 = ['(def func 10)', '(def newFunc (+  func 2))', '(def sumFunc (+ func func newFunc 0 0 0))', '(* sumFunc 2)'],
    test2 = ['(def func (+ 5 2))',
        '(def func2 (/  func 5 2 1 0))',
        'def func3 (/ func 2))',
        '(+ func3 func)'];

console.log(solve(test1));
console.log(solve(test2));

//endregion