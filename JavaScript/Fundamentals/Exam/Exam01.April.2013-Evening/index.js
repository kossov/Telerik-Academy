//region 1.Task1


function taskOne() {
    function solve(params) {
        var N = parseInt(params[0]),
            numbers = params.slice(1).map(Number),
            result = numbers[0], tempSum;
        //debugger;
        for (var i = 0; i < N; i += 1) {
            tempSum = 0;
            for (var j = i; j < N; j += 1) {
                tempSum += numbers[j];
                if (tempSum > result) {
                    result = tempSum;
                }
            }
        }
        return result;
    }


    var test1 = ['8', 1, 6, -9, 4, 4, -2, 10, -1], // 16
        test2 = [6, 1, 3, -5, 8, 7, -6], // 15
        test3 = [9, -9, -8, -8, -7, -6, -5, -1, -7, -6]; // -1
    console.log(solve(test1));
    console.log(solve(test2));
    console.log(solve(test3));
}

//taskOne();

//endregion


//region 2.Task2


function taskTwo() {
    function solve(params) {
        var colsRows = params[0].split(' ').map(Number),
            startPosition = params[1].split(' ').map(Number);
        var cols = colsRows[1],
            rows = colsRows[0],
            row = startPosition[0],
            col = startPosition[1];
        var directions = {
                l: [0, -1],
                r: [0, 1],
                u: [-1, 0],
                d: [1, 0]
            },
            path = params.slice(2).map(function (param) {
                return param.split('');
            }),
            direction;
        var field = initField(rows, cols),
            visited = [];
        var sum = 0, count = 0;
        while (true) {
            if (row < 0 || col < 0 || row >= rows || col >= cols) {
                return 'out ' + sum;
            }
            if (visited[field[row][col]]) {
                return 'lost ' + count;
            }

            sum += field[row][col];
            count += 1;
            visited[field[row][col]] = true;
            direction = path[row][col];
            //debugger;
            row += directions[direction][0];
            col += directions[direction][1];
        }
        function initField(rows, cols) {
            var field = [],
                counter = 1;
            for (var i = 0; i < rows; i += 1) {
                field[i] = [];
                for (var j = 0; j < cols; j += 1) {
                    field[i][j] = counter;
                    counter += 1;
                }
            }
            return field;
        }
    }

    var test1 = [
            "3 4",
            "1 3",
            "lrrd",
            "dlll",
            "rddd"],
        test2 = [
            "5 8",
            "0 0",
            "rrrrrrrd",
            "rludulrd",
            "durlddud",
            "urrrldud",
            "ulllllll"],
        test3 = [
            "5 8",
            "0 0",
            "rrrrrrrd",
            "rludulrd",
            "lurlddud",
            "urrrldud",
            "ulllllll"];
    console.log(solve(test1));
    console.log(solve(test2));
    console.log(solve(test3));
}

//taskTwo();

//endregion


//region 3.Task3


function taskThree() {
    function solve(params) {

    }

    var test1 = [],
        test2 = [];
    console.log(solve(test1));
    console.log(solve(test2));

}

taskThree();

//endregion