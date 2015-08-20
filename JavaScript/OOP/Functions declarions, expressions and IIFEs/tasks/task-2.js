/* Task description */
/*
 Write a function that finds all the prime numbers in a range
 1) it should return the prime numbers in an array
 2) it must throw an Error if any on the range params is not convertible to `Number`
 3) it must throw an Error if any of the range params is missing
 */
function solve() {

    return function findPrimes() {
        var result = [],
            start = parseInt(arguments[0]),
            end = parseInt(arguments[1]);
        if (arguments.length === 0) {
            throw new Error('There are no parameters given!');
        }
        if (arguments.length === 1) {
            throw new Error('There are no two parameters!');
        }
        if (Number.isNaN(start) || Number.isNaN(end)) {
            throw new Error('Please give proper range Number');
        }
        for (; start <= end; start += 1) {
            if (start === 0 || start === 1) {
                continue;
            }
            var sqrt = Math.sqrt(start),
                counter = 1,
                isPrime = true;
            while (counter <= sqrt) {
                if (start % counter === 0 && counter > 1) {
                    isPrime = false;
                    break;
                } else {
                    counter += 1;
                }
            }
            if (isPrime) {
                result.push(start);
            }
        }
        return result;
    }
}
module.exports = findPrimes;