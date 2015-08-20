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

//region 1.EvenOrOdd
/* Write an expression that checks if given integer is odd or even. */
var numbers = [3,2,-2,-1,0];
numbers.forEach(checkEvenOrOdd);
function checkEvenOrOdd(number) {
    var result = number;
    if(number % 2 == 0) {
        result += ' is even!';
    }
    else {
        result += ' is odd!';
    }
    jsConsole.writeLine(result);
}
//endregion

//region 2.DevisibleBy5And7
/* Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time. */
var numbers = [3,0,5,7,35,140];
numbers.forEach(devidedBy7And5);
function devidedBy7And5(number) {
    var result = number;
    if(number % 5 == 0 && number % 7 == 0) {
        result += ' is devisible by 5 and 7! -> TRUE';
    }
    else {
        result += ' is not devisible by 5 and 7! -> FALSE';
    }
    jsConsole.writeLine(result);
}
//endregion

//region 3.RectangleArea
/* Write an expression that calculates rectangle’s area by given width and height. */
var width = [3,2.5,5],
    height = [4,3,5],
    area;
for(var i = 0; i<width.length; i++) {
    area = width[i] * height[i];
    jsConsole.writeLine('width=' + width[i] + ' height=' + height[i] + ' | area=' + area)
}
//endregion

//region 4.ThirdDigit
/* Write an expression that checks for given integer if its third digit (right-to-left) is 7. */
var numbers = [5,701,1732,9703,877,777877,9999799];
numbers.forEach(checkThirdDigit);
function checkThirdDigit(number) {
    if((Math.floor(number / 100) % 10) === 7) {
            jsConsole.writeLine(number + ' its third digit is 7! -> TRUE');
    }
    else {
            jsConsole.writeLine(number + ' its third digit is not 7 -> FALSE');
    }
}
//endregion

//region 5.ThirdBit
/* Write a boolean expression for finding if the bit #3 (counting from 0) of a given integer.
 The bits are counted from right to left, starting from bit #0.
 The result of the expression should be either 1 or 0. */
var numbers = [5,8,0,15,5343,62241];
numbers.forEach(checkThirdBit);
function checkThirdBit(number) {
    var numberAsStringInBinary = number.toString(2),
        length = 16-numberAsStringInBinary.length;
    for(var i = 0; i<length; i++) {
        numberAsStringInBinary = '0' + numberAsStringInBinary;
    }
    if((number >> 3) & 1) {
            jsConsole.writeLine(number + ' | ' + numberAsStringInBinary + ' | ' + 'Bit #3 -> 1');
    }
    else {
            jsConsole.writeLine(number + ' | ' + numberAsStringInBinary + ' | ' + 'Bit #3 -> 0');
    }
}
//endregion

//region 6.Point in Circle
/* Write an expression that checks if given point P(x, y) is within a circle K({0,0}, 5). //{0,0} is the centre and 5 is the radius */
var x = [0,-5,-4,1.5,-4,100,0,0.2,0.9,2],
    y = [1,0,5,-3,-3.5,-30,0,-0.8,-4.93,2.655],
    circleX = 0,
    circleY = 0,
    radius = 5;
for(var i = 0; i< x.length; i++) {
    var distance = (x[i]-circleX)*(x[i]-circleX) + (y[i]-circleY)*(y[i]-circleY);
    if(distance <= radius*radius) {
        jsConsole.writeLine('Point ['+x[i]+','+y[i]+'] is inside the circle! -> TRUE')
    }
    else {
        jsConsole.writeLine('Point ['+x[i]+','+y[i]+'] is outside the circle! -> FALSE')
    }
}
//endregion

//region 7.Is Prime
/* Write an expression that checks if given positive integer number n (n ? 100) is prime. */
var numbers = [1,2,3,4,9,37,97,51,-3,0];
numbers.forEach(isPrime);
function isPrime(number){
    var primeOrNot = function boolIsPrime() {
        if (number < 2) return false;

        for (var divisor = 2; divisor <= Math.sqrt(number); divisor++) {
            if (!(number % divisor)) return false;
        }

        return true;
    };
    if(!primeOrNot()) {
        jsConsole.writeLine('Number '+number+' is not a prime number! -> FALSE');
    }
    else {
        jsConsole.writeLine('Number '+number+' is a prime number! -> TRUE');
    }
}
//endregion

//region 8.Trapezoid Area
/* Write an expression that calculates trapezoid's area by given sides a and b and height h. */
var sideA = [5,2,8.5,100,0.222],
    sideB = [7,1,4.3,200,0.333],
    height = [12,33,2.7,300,0.555];
for(var i = 0; i< sideA.length; i++) {
    var area = ((sideA[i] + sideB[i])/2)*height[i];
    jsConsole.writeLine('Trapezoid [A:'+sideA[i]+',B:'+sideB[i]+' H:'+height[i]+'] has area='+area);
}
//endregion

//region 9.Point in Circle and outside Rectangle
/* Write an expression that checks for given point P(x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2). */
var pointX = [1,2.5,0,2.5,2,4,2.5,2,1,-100],
    pointY = [2,2,1,1,0,0,1.5,1.5,2.5,-100],
    circleXY = 1,
    circleRadius = 3,
    rectangleTop = 1,
    rectangleLeft = -1,
    rectangleWidth = 6,
    rectangleHeight = 2;

for(var i = 0; i<pointX.length; i++) {
    if(insideCircle(pointX[i],pointY[i]) && outsideRectangle(pointX[i],pointY[i])) {
        jsConsole.writeLine('Point ['+pointX[i]+','+pointY[i]+'] is inside K & outside of R -> YES');
    }
    else {
        jsConsole.writeLine('Point ['+pointX[i]+','+pointY[i]+'] is not inside K & outside of R -> NO');
    }
}

function insideCircle(x,y) {
    return (x - circleXY) * (x - circleXY) + (y - circleXY) * (y - circleXY) < circleRadius * circleRadius;
}

function outsideRectangle(x,y) {
    return !(x >= rectangleLeft && x <= rectangleWidth+rectangleLeft && y <= rectangleTop && y >= rectangleHeight-rectangleTop);
}

//endregion