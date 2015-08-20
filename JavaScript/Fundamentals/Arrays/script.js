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

//region 1. Increase array members
/* Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5.
 Print the obtained array on the console. */
jsConsole.writeLine('~~Increase array members~~');
if (!Array.prototype.fill) {
    var i,
        len;
    Array.prototype.fill = function (callback) {
        for (i = 0, len = this.length; i < len; i += 1) {
            this[i] = arguments[0];
        }
        return this;
    }
}

var numbers = [];
numbers.length = 20;
numbers.fill(0);
numbers = numbers.map(function (_, ind) {
    return ind * 5;
});

jsConsole.writeLine(numbers);

//endregion

//region 2. Lexicographically comparison
/* Write a script that compares two char arrays lexicographically (letter by letter). */
jsConsole.writeLine('~~Lexicographically comparison~~');

var firstCharArray = ['i', 'l', 'l', 'u', 'm'],
    secondCharArray = ['i', 'n', 'a', 't', 'i'];

firstCharArray.forEach(function (ch) {
    if (secondCharArray.indexOf(ch) >= 0) {
        jsConsole.writeLine('the char "' + ch + '" is in both of the arrays.')
    }
});

//endregion

//region 3. Maximal sequence
/* Write a script that finds the maximal sequence of equal elements in an array. */
jsConsole.writeLine('~~Maximal sequence~~');
jsConsole.writeLine('**If there are not many equal elements please refresh the page ^-^**');

var randomElementsArray = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    i,
    len,
    countEqualElements,
    rememberEqualElement,
    maxEqualElements = 1,
    resultMaxEqualElements;

randomElementsArray = randomElementsArray.map(function (number) {
    return Math.round(Math.random() * 10) * number;
});

for (i = 1, len = randomElementsArray.length, countEqualElements = 1; i < len; i += 1) {
    if (randomElementsArray[i] === randomElementsArray[i - 1]) {
        countEqualElements += 1;
        if (countEqualElements >= maxEqualElements) {
            maxEqualElements = countEqualElements;
            rememberEqualElement = randomElementsArray[i];
        }
    } else {
        countEqualElements = 1;
    }
}
if (!rememberEqualElement) {
    resultMaxEqualElements = 'there is no sequence of equal elements!';
} else {
    resultMaxEqualElements = 'the maximal sequence is:' + maxEqualElements + ' of the element [' + rememberEqualElement + ']';
}
jsConsole.writeLine(randomElementsArray);
jsConsole.writeLine(resultMaxEqualElements);
//endregion

//region 4. Maximal increasing sequence
/* Write a script that finds the maximal increasing sequence in an array. */
jsConsole.writeLine('~~Maximal increasing sequence~~');

var maximalIncreasingSequenceArray = [3, 2, 3, 4, 5, 6, 7, 2, 2, 4, 1, 2, 3, 4, 5, 6, 7, 8],
    countMaximalIncreasingSequenceArray = [],
    resultMaximalIncreasingSequenceArray = [],
    countIncreasingSeq,
    maxIncreasingSeq = 0;

for (i = 1, len = maximalIncreasingSequenceArray.length, countIncreasingSeq = 1; i < len; i += 1) {
    if (maximalIncreasingSequenceArray[i] - 1 === maximalIncreasingSequenceArray[i - 1]) {
        countMaximalIncreasingSequenceArray.push(maximalIncreasingSequenceArray[i - 1]);
        countIncreasingSeq += 1;
        if (maxIncreasingSeq <= countIncreasingSeq) {
            maxIncreasingSeq = countIncreasingSeq;
            resultMaximalIncreasingSequenceArray = countMaximalIncreasingSequenceArray;
            if (maximalIncreasingSequenceArray[i] + 1 !== maximalIncreasingSequenceArray[i + 1]) {
                resultMaximalIncreasingSequenceArray.push(maximalIncreasingSequenceArray[i]);
            }
        }
    } else {
        countMaximalIncreasingSequenceArray = [];
        countIncreasingSeq = 1;
    }
}
jsConsole.writeLine(maximalIncreasingSequenceArray);
jsConsole.writeLine(resultMaximalIncreasingSequenceArray);
//endregion

//region 5. Selection sort
/* Sorting an array means to arrange its elements in increasing order.
 Write a script to sort an array.
 Use the selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
 Hint: Use a second array */
jsConsole.writeLine('~~Selection sort~~');

function selectionSort(arr) {
    for (var left = 0; left < arr.length; left++) {
        for (var right = left + 1; right < arr.length; right++) {
            if (arr[left] > arr[right]) {
                var tmp = arr[right];
                arr[right] = arr[left];
                arr[left] = tmp;
            }
        }
    }
}

var selectionSortArr =  [8, 12, 3, 4, 5, 2, 11, 13, 7, 4, 15, 14, 12, 8, 1];
selectionSort(selectionSortArr);
jsConsole.writeLine(selectionSortArr);
//endregion

//region 6. Most frequent number
/* Write a script that finds the most frequent number in an array. */
jsConsole.writeLine('~~Most frequent number~~');

var mostFrequentNumArr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3],
    n,
    countMostFreqNum = 0,
    maxMostFreqNum = 0,
    mostFreqNum;

for (n = 0; n < mostFrequentNumArr.length; n += 1) {
    for (i = 0, len = mostFrequentNumArr.length; i < len; i += 1) {
        if (mostFrequentNumArr[n] === mostFrequentNumArr[i]) {
            if (countMostFreqNum >= maxMostFreqNum) {
                countMostFreqNum += 1;
                maxMostFreqNum = countMostFreqNum;
                mostFreqNum = mostFrequentNumArr[i];
            } else {
                countMostFreqNum += 1;
            }
        }
    }
    countMostFreqNum = 0;
}
jsConsole.writeLine(mostFrequentNumArr);
jsConsole.writeLine(mostFreqNum + '(' + maxMostFreqNum + ')times');
//endregion

//region 7. Binary search
/* Write a script that finds the index of given element in a sorted array of integers by using the binary search algorithm.

 * malko prepisah. forgiv mi */
jsConsole.writeLine('~~Binary search~~');

var numbers = [3, 9, 10, 11, 14, 18, 23, 24, 28, 29, 37, 38, 41, 44, 47],
    numbersToFind = [2, 3, 10, 27, 29, 47, 55];

// the array must be sorted, otherwise the binary search won't work
numbers.map(Number).sort();

for (var ind = 0; ind < numbersToFind.length; ind++) {
    jsConsole.writeLine(numbersToFind[ind] + '\t[' +
        binarySearch(numbers, numbersToFind[ind], 0, numbers.length - 1) + ']');
}

function binarySearch(arr, num, min, max) {
    var mid = min + Math.floor((max - min) / 2);

    if (max < min || num > arr[max]) {
        return -1;
    }

    if (arr[mid] > num) {
        return binarySearch(arr, num, min, mid - 1);
    } else if (arr[mid] < num) {
        return binarySearch(arr, num, mid + 1, max);
    } else {
        return mid;
    }
}

//endregion