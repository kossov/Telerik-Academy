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

var arrayWithEmptyElement = ['orange', 'apple', , 'grape', ''];
var emptyArray = [];
var integer = 8;
var floating = 8.59;
var hexaInteger = 0x10;
var octalInteger = 010;
var exponent = 12.4e3;
/* 12.4 x 10^3 */
var negativeExponent = 12.4e-3;
/* 12.4 x 10^-3 */
var trueBool = true;
var falseBool = false;
var student = {FirstName: 'Marti', LastName: 'Goshev'};
var emptyObject = {};

var string = "`'How you doin'?', Joey said'.";
var anotherString = 'google' + '.com';
var yetAnotherString = '\'How you doin\'?\', Joey said\'.';
var yetYetAnotherString = "First line. \n Second line.";

var nullableVar = null;
var undefinedVar = undefined;

var objects = [arrayWithEmptyElement,
    emptyArray,
    integer,
    floating,
    hexaInteger,
    octalInteger,
    exponent,
    negativeExponent,
    trueBool,
    falseBool,
    student,
    emptyObject,
    string,
    anotherString,
    yetAnotherString,
    yetYetAnotherString,
    nullableVar,
    undefinedVar];

for(var obj in objects) {
    jsConsole.writeLine(objects[obj] + ' is ' + typeof objects[obj]);
}