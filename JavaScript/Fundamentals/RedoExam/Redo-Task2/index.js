function solve(args) {
    var text = args[0],
        offset = args[1],
        CONSTANTS = {
            ALPHABET: 'abcdefghijklmnopqrstuvwxyz'
        };
    var compression = '',
        countSymbols = 1,
        symbol = '';
    for (var i = 1; i < text.length; i += 1) { //  ['aaaaabbwwwrqwww']; // 5abb3w5rq3w
        if (text[i] === text[i - 1]) {
            countSymbols += 1;
            symbol = text[i];
        } else {
            if (countSymbols === 1) {
                compression += text[i - 1];
            } else if (countSymbols === 2) {
                compression += symbol + symbol;
            } else {
                compression += countSymbols + symbol;
            }
            countSymbols = 1;
        }
        if (i + 1 === text.length) {
            if (countSymbols === 1) {
                compression += text[i];
            } else if (countSymbols === 2) {
                compression += text[i] + text[i];
            } else {
                compression += countSymbols + text[i];
            }
        }
    } // COMPRESSION for zero test works properly
    var encryption = '';
    if (typeof(offset) == 'undefined') {
        offset = 0;
    }
    for (var c = 0; c < compression.length; c += 1) {
        debugger;
        if (parseInt(compression[c])) {
            encryption += compression[c];
        } else {
            var XOResult = 0,
                mySymbolCharCode = compression[c].charCodeAt(0),
                symbolAt = CONSTANTS.ALPHABET.indexOf(compression[c]),
                cypherSymbolAt;
            if (offset === 0) {
                cypherSymbolAt = symbolAt;
            } else {
                cypherSymbolAt = CONSTANTS.ALPHABET.length - offset + symbolAt;
            }
            if (cypherSymbolAt < 0) {
                cypherSymbolAt *= -1;
            }
            if (cypherSymbolAt > 26) {
                cypherSymbolAt %= 26;
            }
            var cypherSymbol = CONSTANTS.ALPHABET[cypherSymbolAt],
                cypherSymbolCharCode = cypherSymbol.charCodeAt(0);
            XOResult = mySymbolCharCode ^ cypherSymbolCharCode;
            encryption += XOResult;
        }
    } // ENCRYPTION WORKS
    var sum = 0,
        product = 1;
    for (var k = 0; k < encryption.length; k += 1) {
        var digit = parseInt(encryption[k]);
        if (digit === 0) {
            // redo
            continue;
        }
        if (digit % 2 === 0) {
            sum += digit;
        } else {
            product *= digit;
        }
    }
    console.log(sum + '\n' + product);
}

var test1 = ['aaaabbbccccaa', '3'],
    test2 = ['aaab'];

console.log(solve(test2));