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

//region 1.Exchange if greater
/* Write an if statement that takes two double variables a and b and exchanges their values if the first one is greater than the second.
 As a result print the values a and b, separated by a space. */
jsConsole.writeLine('~~Exchange if greater~~');
var a = [5, 3, 5.5],
    b = [2, 4, 4.5],
    result;
for (var i = 0; i < a.length; i++) {
    if (a[i] < b[i]) {
        result = a[i] + ' ' + b[i];
    }
    else {
        result = b[i] + ' ' + a[i];
    }
    jsConsole.writeLine(result);
}
//endregion

//region 2.Multiplication Sign
/* Write a script that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
 Use a sequence of if operators. */
jsConsole.writeLine('~~Multiplication Sign~~');
var a = [5, -2, -2, 0, -1],
    b = [5, -2, 4, -2.5, -0.5],
    c = [2, 1, 3, 4, -5.1],
    result;
for (var i = 0; i < a.length; i++) {
    if (a[i] == 0 || b[i] == 0 || c[i] == 0) {
        result = '0';
    }
    else {
        var countMinusSigns = 0,
            tempString,
            allVariables = [a, b, c];
        for (var j = 0; j < allVariables.length; j++) {
            tempString = allVariables[j][i].toString();
            if (tempString[0] == '-') {
                countMinusSigns = countMinusSigns + 1;
            }
        }
        if (countMinusSigns % 2 == 0) {
            result = '+';
        } else {
            result = '-';
        }
    }
    jsConsole.writeLine(result);
}
//endregion

//region 3.The biggest of Three
/* Write a script that finds the biggest of three numbers.
 Use nested if statements. */
jsConsole.writeLine('~~The Biggest of Three~~')
var a = [5, -2, -2, 0, -.1],
    b = [2, -2, 4, -2.5, -.5],
    c = [2, 1, 3, 5, -1.1];

for (var i = 0; i < a.length; i++) {
    var biggestNumber;
    if (a[i] == b[i]) {
        if (a[i] > c[i]) {
            biggestNumber = a[i];
        } else {
            biggestNumber = c[i];
        }
    } else if (a[i] == c[i]) {
        if (a[i] > b[i]) {
            biggestNumber = a[i];
        } else {
            biggestNumber = b[i];
        }
    } else if (b[i] == c[i]) {
        if (a[i] > b[i]) {
            biggestNumber = a[i];
        } else {
            biggestNumber = b[i];
        }
    } else {
        if (a[i] > b[i]) {
            if (a[i] > c[i]) {
                biggestNumber = a[i];
            } else {
                biggestNumber = c[i];
            }
        } else if (b[i] > c[i]) {
            biggestNumber = b[i];
        } else {
            biggestNumber = c[i];
        }
    }
    jsConsole.writeLine(biggestNumber);
}
//endregion

//region 4. Sort Three Numbers
/* Sort 3 real values in descending order.
 Use nested if statements.
 Note: Don�t use arrays and the built-in sorting functionality. */
jsConsole.writeLine('~~Sort Three Numbers~~');
var a = [5, -2, -2, 0, -1.1, 10, 1],
    b = [1, -2, 4, -2.5, -.5, 20, 1],
    c = [2, 1, 3, 5, -.1, 30, 1],
    result;
for (var i = 0; i < a.length; i++) {
    var biggestNumber;
    if (a[i] == b[i]) {
        if (a[i] > c[i]) {
            biggestNumber = a[i];
            result = biggestNumber + ' ' + a[i] + ' ' + b[i];
        } else {
            biggestNumber = c[i];
            result = biggestNumber + ' ' + a[i] + ' ' + b[i];
        }
    } else if (a[i] == c[i]) {
        if (a[i] > b[i]) {
            biggestNumber = a[i];
            result = biggestNumber + ' ' + c[i] + ' ' + b[i];
        } else {
            biggestNumber = b[i];
            result = biggestNumber + ' ' + a[i] + ' ' + c[i];
        }
    } else if (b[i] == c[i]) {
        if (a[i] > b[i]) {
            biggestNumber = a[i];
            result = biggestNumber + ' ' + c[i] + ' ' + b[i];
        } else {
            biggestNumber = b[i];
            result = biggestNumber + ' ' + c[i] + ' ' + a[i];
        }
    } else {
        if (a[i] > b[i]) {
            if (a[i] > c[i]) {
                biggestNumber = a[i];
                result = biggestNumber;
                if (c[i] > b[i]) {
                    result = result + ' ' + c[i] + ' ' + b[i];
                } else {
                    result = result + ' ' + b[i] + ' ' + c[i];
                }
            } else {
                biggestNumber = c[i];
                result = biggestNumber + ' ' + a[i] + ' ' + b[i];
            }
        } else if (b[i] > c[i]) {
            biggestNumber = b[i];
            result = biggestNumber;
            if (c[i] > a[i]) {
                result = result + ' ' + c[i] + ' ' + a[i];
            } else {
                result = result + ' ' + a[i] + ' ' + c[i];
            }
        } else {
            biggestNumber = c[i];
            result = biggestNumber + ' ' + b[i] + ' ' + a[i];
        }
    }
    jsConsole.writeLine(result);
}


//endregion

//region 5. Digit as word
/* Write a script that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
 Print �not a digit� in case of invalid input.
 Use a switch statement. */
jsConsole.writeLine('~~Digit as Word~~');
var digits = [2, 1, 0, 5, -.1, 'hi', 9, 10],
    result;
for (var i = 0; i < digits.length; i++) {
    if (digits[i] >= 0 && digits[i] <= 9) {
        if (digits[i].toString().length == 1) {
            switch (digits[i]) {
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
            }
        } else {
            result = 'not a digit';
        }
    } else {
        result = 'not a digit';
    }
    jsConsole.writeLine(result);
}
//endregion

//region 6. Quadratic equation
/* Write a script that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
 Calculates and prints its real roots.
 Note: Quadratic equations may have 0, 1 or 2 real roots. */
jsConsole.writeLine('~~Quadratic equation~~')
var a = [2, -1, -.5, 5],
    b = [5, 3, 4, 2],
    c = [-3, 0, -8, 8];
for (var i = 0; i < a.length; i++) {
    jsConsole.writeLine(a[i] + 'x2' + ' + ' + b[i] + 'x' + ' + ' + c[i] + ' = 0');
    jsConsole.writeLine(getRoots(a[i], b[i], c[i]));
}
function getRoots(a, b, c) {
    var D = b * b - 4 * a * c;
    if (D < 0) {
        return 'no real roots';
    }
    else if (!D) {
        return 'x1=x2=' + getRoot(-1, D, b, a);
    }
    else {
        return 'x1=' + getRoot(-1, D, b, a) + '; x2=' + getRoot(1, D, b, a);
    }
}
function getRoot(sign, D, b, a) {
    return (-b + Math.sqrt(D) * sign) / (2 * a);
}

//endregion

//region 7. The biggest of five numbers
/* Write a script that finds the greatest of given 5 variables.
 Use nested if statements. */
jsConsole.writeLine('~~Biggest of Five~~');
var a = [5, -2, -2, 0, -3],
    b = [2, -22, 4, -2.5, -.5],
    c = [2, 1, 3, 0, -1.1],
    d = [4, 0, 2, 5, -2],
    e = [1, 0, 0, 5, -.1],
    biggest;

for (var i = 0; i < a.length; i++) {
    if (a[i] > b[i]) {
        if (a[i] > c[i]) {
            if (a[i] > d[i]) {
                if (a[i] > e[i]) {
                    biggest = a[i];
                } else {
                    biggest = e[i];
                }
            } else {
                if (d[i] > e[i]) {
                    biggest = d[i];
                } else {
                    biggest = e[i];
                }
            }
        } else {
            if (c[i] > d[i]) {
                if (c[i] > e[i]) {
                    biggest = c[i];
                } else {
                    biggest = e[i];
                }
            } else {
                if (d[i] > e[i]) {
                    biggest = d[i];
                } else {
                    biggest = e[i];
                }
            }
        }
    } else {
        if (b[i] > c[i]) {
            if (b[i] > d[i]) {
                if (b[i] > e[i]) {
                    biggest = b[i];
                } else {
                    biggest = e[i];
                }
            } else {
                if (d[i] > e[i]) {
                    biggest = d[i];
                } else {
                    biggest = e[i];
                }
            }
        } else {
            if (c[i] > d[i]) {
                if (c[i] > e[i]) {
                    biggest = c[i];
                } else {
                    biggest = e[i];
                }
            } else {
                if (d[i] > e[i]) {
                    biggest = d[i];
                } else {
                    biggest = e[i];
                }
            }
        }
    }
    jsConsole.writeLine(biggest);
}
//endregion

//region 8. Number as words
/* Write a script that converts a number in the range [0…999] to words, corresponding to its English pronunciation. */
jsConsole.writeLine('~~Number as words~~');
var numbers = [0, 9, 10, 12, 19, 25, 98, 273, 400, 501, 617, 711, 999],
    number,
    result = '',
    tempNumber;
for (number in numbers) {
    number = numbers[number];
    if (Math.floor(number / 100) * 100) {
        hundreds(number);
    } else {
        specialTens(number);
    }

    jsConsole.writeLine(result);
    result = '';

    function ones(number) {
        switch (number) {
            case 0:
                result += 'zero';
                break;
            case 1:
                result += 'one';
                break;
            case 2:
                result += 'two';
                break;
            case 3:
                result += 'three';
                break;
            case 4:
                result += 'four';
                break;
            case 5:
                result += 'five';
                break;
            case 6:
                result += 'six';
                break;
            case 7:
                result += 'seven';
                break;
            case 8:
                result += 'eight';
                break;
            case 9:
                result += 'nine';
                break;
        }
    }

    function specialTens(number) {
        switch (number) {
            case 10:
                result += 'ten';
                break;
            case 11:
                result += 'eleven';
                break;
            case 12:
                result += 'twelve';
                break;
            case 13:
                result += 'thirteen';
                break;
            case 14:
                result += 'fourteen';
                break;
            case 15:
                result += 'fifteen';
                break;
            case 16:
                result += 'sixteen';
                break;
            case 17:
                result += 'seventeen';
                break;
            case 18:
                result += 'eighteen';
                break;
            case 19:
                result += 'nineteen';
                break;
            default:
                if (Math.floor(number / 10) * 10) {
                    tens(Math.floor(number / 10) * 10);
                    result += '-';
                    ones(number % 10);
                } else {
                    ones(number);
                }
        }
    }

    function tens(number) {
        switch (number) {
            case 20:
                result += 'twenty';
                break;
            case 30:
                result += 'thirty';
                break;
            case 40:
                result += 'forty';
                break;
            case 50:
                result += 'fifty';
                break;
            case 60:
                result += 'sixty';
                break;
            case 70:
                result += 'seventy';
                break;
            case 80:
                result += 'eighty';
                break;
            case 90:
                result += 'ninety';
                break;
        }
    }

    function hundreds(number) {
        tempNumber = Math.floor(number/100);
        ones(tempNumber);
        result += ' hundred ';
        tempNumber = number % 100;
        if (tempNumber % 10) {
            result += ' and ';
            specialTens(tempNumber);
        } else {
            tens(tempNumber);
        }
    }
}
//endregion