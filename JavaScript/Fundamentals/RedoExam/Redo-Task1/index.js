function solve(params) {
    var N = parseInt(params[0]),
        K = parseInt(params[1]),
        numbersAsString = params[2];
    var numbers = numbersAsString.split(' ').map(Number);
    var result = [];


    for (var i = 0; i < N; i += 1) {
        if(i+K-1 === N) {
            break;
        }
        var min = 1000000000,
            max = -1000000000;
        for (var j = 0; j < K; j += 1) {
            if(numbers[i+j] > max) {
                max = numbers[j+i];
            }
            if(numbers[i+j] < min) {
                min = numbers[j+i];
            }
        }
        var sum = min + max;
        result.push(sum);
    }

    console.log(result.join(','));
    //print answer
}

var test1 = ['4', '2', '1 3 1 8'],
    test2 = ['5', '3', '7 7 8 9 10'];

console.log(solve(test1));
console.log(solve(test2));