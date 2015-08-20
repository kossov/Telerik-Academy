/* Task Description */
/* 
 Write a function that sums an array of numbers:
 numbers must be always of type Number
 returns `null` if the array is empty
 throws Error if the parameter is not passed (undefined)
 throws if any of the elements is not convertible to Number

 */

function sum(arr) {
    if(arguments.length === 0) {
        throw new Error('Please pass an array with numbers!');
    }
    var array = arr || [],
        sum = 0;
    if (array.length === 0) {
        return null;
    }
    array.forEach(function (number) {
        var num = Number(number);
        if (isNaN(num)) {
            throw new Error('all numbers must be of type Number!');
            // covers both errors - for undefined and for '12a'(not convertable to Number)
        } else {
            sum += num;
        }
    })
    return sum;
}


module.exports = sum;