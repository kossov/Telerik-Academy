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

//region 1. Numbers
/* Write a script that prints all the numbers from 1 to N. */
jsConsole.writeLine('~~Numbers from 1 to N~~');
var n = 100;

for(var i = 0; i<n; i++) {
    jsConsole.write(i+1 + ' ');
}
jsConsole.writeLine('\n');
//endregion

//region 2. Numbers Not Devisible
/* Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time */
jsConsole.writeLine('~~Numbers from 1 to N, not divisible by 3 and 7~~');
var n = 100;
for(var i = 1; i<=n; i++) {
    if(i%3!=0 && i%7!=0) {
        jsConsole.write(i + ' ')
    }
}
jsConsole.writeLine('\n');
//endregion

//region 3. Min/Max of sequence
/* Write a script that finds the max and min number from a sequence of numbers. */
jsConsole.writeLine('~~Min/Max number~~');
var numbers = [],
    minNumber = Number.MAX_VALUE,
    maxNumber = Number.MIN_VALUE;
for(var i = 1; i<=15; i++) { /* added random numbers */
    do {
        var number = Math.floor((Math.random() * i*11) + 1),
            isValidNumber = true;
        if(numbers.indexOf(number) > -1) {
            isValidNumber = false;
        }
    }while(isValidNumber != true);
    numbers.push(number);
}
jsConsole.writeLine('Generated random sequence of numbers:')
jsConsole.writeLine(numbers);

for(var i = 0; i<numbers.length; i++) { /* finding min/max from those numbers */
    if(minNumber > numbers[i]) {
        minNumber = numbers[i];
    }
    if(maxNumber < numbers[i]) {
        maxNumber = numbers[i];
    }
}
jsConsole.writeLine('Max number in the sequence is: '+maxNumber);
jsConsole.writeLine('Min number in the sequence is: '+minNumber);
//endregion

//region 4. Lexicographically smallest
/* Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects. */
jsConsole.writeLine('~~Lexicographically smallest and largest~~');
var objects = [window,navigator,document];
for(var i = 0; i < objects.length; i++) {
    jsConsole.writeLine(objects[i]);
    getProperties(objects[i]);
}

function getProperties(obj) {
    var minProperty = 0,
        maxProperty = 0;
    for(var property in obj){
        if(!minProperty){
            minProperty = property;
        }
        if(!maxProperty){
            maxProperty = property;
        }
        if(property < minProperty){
            minProperty = property;
        }
        if(property > maxProperty){
            maxProperty = property;
        }
    }
    jsConsole.writeLine('Min property: '+minProperty);
    jsConsole.writeLine('Max property: '+maxProperty);
}
//endregion