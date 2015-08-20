function solve(params) {
    var NandK = params[0].split(' ').map(Number);
    var N = NandK[0],
        K = NandK[1];
    var s = params[1].split(' ').map(Number);
    var result = [];

    for (var k = 0; k < K; k += 1) {
        for (var i = 0; i < s.length; i += 1) {
            var tempNumber = 0,
                leftMost = 0,
                rightMost = 0;
           // result.push(calculateNumber(i,s));
            if(s[i] === 0) {
                if(i === 0) {
                    leftMost = s.length-1;
                    rightMost = 1;
                } else if (i === s.length-1) {
                    leftMost = s.length-2;
                    rightMost = 0;
                } else {
                    leftMost = i-1;
                    rightMost = i+1;
                }
                var difference = s[leftMost] - s[rightMost];
                if(difference < 0) {
                    difference *= -1;
                }
                s[i] = difference;
            }
        }
        for(var l= 0; l< s.length; l+=1) {
            var tempNumber = 0,
                leftMost = 0,
                rightMost = 0;
            // result.push(calculateNumber(i,s));
            if(s[l] === 1) {
                if(l === 0) {
                    leftMost = s.length-1;
                    rightMost = 1;
                } else if (l === s.length-1) {
                    leftMost = s.length-2;
                    rightMost = 0;
                } else {
                    leftMost = l-1;
                    rightMost = l+1;
                }
                var why = s[leftMost] + s[rightMost];
                s[l] = why;
            }
        }
        for(var w= 0; w< s.length; w+=1) {
            var tempNumber = 0,
                leftMost = 0,
                rightMost = 0;
            // result.push(calculateNumber(i,s));
            if(s[w]% 2 === 1) {
                if(w === 0) {
                    leftMost = s.length-1;
                    rightMost = 1;
                } else if (w=== s.length-1) {
                    leftMost = s.length-2;
                    rightMost = 0;
                } else {
                    leftMost = w-1;
                    rightMost = w+1;
                }
                s[w] = Math.min(s[leftMost],s[rightMost]);
            }
        }

        for(var q= 0; q< s.length; q+=1) {
            var tempNumber = 0,
                leftMost = 0,
                rightMost = 0;
            // result.push(calculateNumber(i,s));
            if(s[q]% 2 === 0) {
                if(q === 0) {
                    leftMost = s.length-1;
                    rightMost = 1;
                } else if (q === s.length-1) {
                    leftMost = s.length-2;
                    rightMost = 0;
                } else {
                    leftMost = q-1;
                    rightMost = q+1;
                }
                s[q] = Math.max(s[leftMost],s[rightMost]);
            }
        }
        debugger;
    }

    function calculateNumber(i,arr) {
        var neighbourIndexes = [];
        if(i === 0) {
            neighbourIndexes.push(1);
            neighbourIndexes.push(arr.length-1);
        } else if (i === s.length - 1) {
            neighbourIndexes.push(arr.length-2);
            neighbourIndexes.push(0);
        } else {
            neighbourIndexes.push(i-1);
            neighbourIndexes.push(i+1);
        }
        if(arr[i] === 0) {
            var difference = arr[neighbourIndexes[0]] - arr[neighbourIndexes[1]];
            if(difference > 0) {
                return difference;
            } else {
                return difference * -1;
            }
        } else if(arr[i] === 1){
            return arr[neighbourIndexes[0]] + arr[neighbourIndexes[1]];
        } else if(arr[i] % 2 === 0) {
            return arr[i];
        } else {
            return arr[i];
        }
    }

    var final = 0;
    for (var j = 0; j < s.length; j += 1) {
        final += result[j];
    }
    return final;
}

var test1 = ['5 1', '9 0 2 4 1'],
    test2 = ['10 3', '1 9 1 9 1 9 1 9 1 9'],
    test3 = ['10 10', '0 1 2 3 4 5 6 7 8 9'];

console.log(solve(test1));
console.log(solve(test2));
console.log(solve(test3));