//region JsConsole
(function () {
    function createJsConsole(selector) {
        var self = this;
        var consoleElement = document.querySelector(selector);

        if (consoleElement.className) {
            consoleElement.className = consoleElement.className + " js-console";
        }
        else {
            consoleElement.className = "js-console";
        }

        var textArea = document.createElement("p");
        consoleElement.appendChild(textArea);

        self.write = function jsConsoleWrite(text) {
            var textLine = document.createElement("span");
            textLine.innerHTML = text;
            textArea.appendChild(textLine);
            consoleElement.scrollTop = consoleElement.scrollHeight;
        }

        self.writeLine = function jsConsoleWriteLine(text) {
            self.write(text);
            textArea.appendChild(document.createElement("br"));
        }

        self.read = function readText(inputSelector) {
            var element = document.querySelector(inputSelector);
            if (element.innerHTML) {
                return element.innerHTML;
            }
            else {
                return element.value;
            }
        }

        self.readInteger = function readInteger(inputSelector) {
            var text = self.read(inputSelector);
            return parseInt(text);
        }

        self.readFloat = function readFloat(inputSelector) {
            var text = self.read(inputSelector);
            return parseFloat(text);
        }

        return self;
    }

    jsConsole = new createJsConsole("#js-console");
}).call(this);
//endregion

//region 1. English digit
/* Write a function that returns the last digit of given integer as an English word. */
jsConsole.writeLine('~~English Digit~~');

function recognizeDigit(number) {
    var digit = Math.round(number % 10),
        result;
    switch (digit) {
        case 0:
            result = 'zero';
            break;
        case 1:
            result = 'one';
            break;
        case 2:
            result = 'two';
            break;
        case 3:
            result = 'three';
            break;
        case 4:
            result = 'four';
            break;
        case 5:
            result = 'five';
            break;
        case 6:
            result = 'six';
            break;
        case 7:
            result = 'seven';
            break;
        case 8:
            result = 'eight';
            break;
        case 9:
            result = 'nine';
            break;
        default:
            result = 'something went wrong!';
    }
    return result;
}

var numbers = [512, 1024, 12309],
    i,
    len;

for (i = 0, len = numbers.length; i < len; i += 1) {
    jsConsole.writeLine(recognizeDigit(numbers[i]));
}

//endregion

//region 2. Reverse number
/* Write a function that reverses the digits of given decimal number. */
jsConsole.writeLine('~~Reverse number~~');

function reverseNumber(number) {
    var result = '',
        i;

    number += ''; // just if you give me a number not a string..
    for (i = number.length - 1; i >= 0; i -= 1) {
        result += number[i];
    }
    return result * 1; // just if u want it as a number..
}

numbers = [256, 123.45];

for (i = 0, len = 2; i < len; i += 1) {
    jsConsole.writeLine(reverseNumber(numbers[i]));
}

//endregion

//region 3. Occurrences of word
/* Write a function that finds all the occurrences of word in a text.
 The search can be case sensitive or case insensitive.
 Use function overloading. */
jsConsole.writeLine('~~Occurrences of word~~');

function findOccurancesOfWord(word, text) {

    var textAsWords = text.split(' '),
        count;
    for (i = 0, len = textAsWords.length, count = 0; i < len; i += 1) {
        if (word === textAsWords[i]) {
            count += 1;
        }
    }

    return count;
}

var text = 'neka kaja tri pati gosho sega: gosho gosho gosho';
jsConsole.writeLine('text: ' + text + ' | word: gosho | occurances: ' + findOccurancesOfWord('gosho', text));
//endregion


//region 4. Number of elements
/* Write a function to count the number of div elements on the web page */
jsConsole.writeLine('~~Number of elements~~');
jsConsole.writeLine(document.getElementsByTagName('div').length);
//endregion

//region 5. Appearance count
/* Write a function that counts how many times given number appears in given array.
 Write a test function to check if the function is working correctly. */
jsConsole.writeLine('~~Appearance count~~');

function countNumber(number, array) {
    array = array || []; // if its not an array make it

    var count;

    for (i = 0, len = array.length, count = 0; i < len; i += 1) {
        if (number === array[i]) {
            count += 1;
        }
    }
    return count;
}
function testCountNumber(number, array, expected) {
    return countNumber(number, array) === expected;
}

var arrays = {
    a: {
        array: [4, 4, 4, 2, 2, 2, 2, 4, 4, 4, 1, 2, 3, 4],
        number: 4,
        expected: 7
    },
    b: {
        array: [5],
        number: 2,
        expected: 0
    },
    c: {
        array: [1, 1, 1],
        number: 1,
        expected: 3
    }
};

for (var arr in arrays) {
    var curr = arrays[arr],
        result = 'array:' + curr.array + ' number: ' + curr.number +
            ' | expected: ' + curr.expected +
            ' /result: ' + testCountNumber(curr.number, curr.array, curr.expected);

    jsConsole.writeLine(result);
}

//endregion

//region 6. Larger than neighbours
/* Write a function that checks if the element at given position in given array of integers is
 bigger than its two neighbours (when such exist). */
jsConsole.writeLine('~~Larger than neighbours~~');

function largerThanNeighbours(position, array) {
    array = array || [];
    var result = true;

    for (i = position - 1, len = position + 1; i <= len; i += 2) {
        if (i < array.length && i >= 0) {
            if (array[position] <= array[i]) {
                result = false;
                break;
            }
        } else { // when array[i] === undefined
            result = false;
        }
    }

    if (array.length <= 2) {
        result = 'there are no two neighbours';
    }

    return result;
}

arrays = {
    a: {
        array: [2, 3, 4, 3],
        position: 2
    },
    b: {
        array: [2, 3, 2, 3],
        position: 2
    },
    c: {
        array: [1, 2],
        position: 0
    },
    d: {
        array: [1, 2],
        position: 1
    },
    e: {
        array: [1],
        position: 0
    }
};

for (var arr in arrays) {
    curr = arrays[arr];
    jsConsole.writeLine('array:' +
        curr.array +
        ' position:' +
        curr.position +
        ' | larger than neighbours -> ' +
        largerThanNeighbours(curr.position, curr.array));
}

//endregion

//region 7. First larger than neighbours
/* Write a function that returns the index of the first element in array that is larger than its neighbours or -1, if there’s no such element.
 Use the function from the previous exercise. */
jsConsole.writeLine('~~First larger than neighbours~~');

function indexOfFirstElementLargerThanNeighbours(array) {

    var result,// idk but when I use i and len something goes wrong..
        j,
        ken;
    for (j = 1, ken = 6, result = -1; j < ken; j += 1) {
        if(largerThanNeighbours(j,array) === true) {
            result = j;
            break;
        }
    }
    return result;
}


arrays = {
    a: {
        array: [1,2,3,2,4,2]
    },
    b: {
        array: [1,1,1]
    },
    c: {
        array: [1]
    }
};

for(var arr in arrays) {
    curr = arrays[arr];
    jsConsole.writeLine('array: '+curr.array+' | first larger: '+ indexOfFirstElementLargerThanNeighbours(curr.array));
}


//endregion