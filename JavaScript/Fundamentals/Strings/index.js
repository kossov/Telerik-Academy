//region 1. Reverse a string
/* Write a JavaScript function that reverses a string and returns it. */
console.log('~~1.Reverse a string~~');
function reverseAString() {
    var sstring = 'sample',
        i,
        result;

    for (i = sstring.length - 1, result = ''; i >= 0; i -= 1) {
        result += sstring[i];
    }
    return result;
}

console.log(reverseAString());
//endregion

//region 2. Correct brackets
/* Write a JavaScript function to check if in a given expression the brackets are put correctly.
 Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)). */
console.log('~~2.Correct brackets~~');
function correctBrackets() {
    var examples = ['((a+b/5-d)', ')(a+b))', '(a+b)', '((a+5)+6)'],
        i,
        len;

    function areBracketsNice(example) {
        var openBracket = 0,
            i,
            len;
        for (i = 0, len = example.length; i < len; i += 1) {
            if (example[i] === '(') {
                openBracket += 1;
            } else if (example[i] === ')') {
                openBracket -= 1;
            }
        }
        return openBracket;
    }

    for (i = 0, len = examples.length; i < len; i += 1) {
        if (!areBracketsNice(examples[i])) {
            console.log('expression: ' + examples[i] + ' has some nice brackets!');
        } else {
            console.log('expression: ' + examples[i] + ' has some shittieh brackets!')
        }
    }
}

correctBrackets();


//endregion

//region 3. Sub-string in text
/* Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).
 Example:

 The target sub-string is in

 The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

 The result is: 9 */
console.log('~~3.Sub-string in text~~');

function substringInText(word) {
    var test = "We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
    test = test.split(' ');
    var wordToSearchFor = '' + word,
        counter = 0;
    for (var i = 0; i < test.length; i += 1) {
        var currentWord = test[i];

        while (currentWord.indexOf(wordToSearchFor) > -1) {
            counter += 1;
            currentWord = currentWord.replace(wordToSearchFor, '');
        }

    }
    return counter;
}

console.log(substringInText('in'));
//endregion

//region 4. Parse tags
/* You are given a text. Write a function that changes the text in all regions:

 <upcase>text</upcase> to uppercase.
 <lowcase>text</lowcase> to lowercase
 <mixcase>text</mixcase> to mix casing(random)
 Example: We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.

 The expected result:
 We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.

 Note: Regions can be nested. */
console.log('~~4.Parse tags~~');

function parseTags() {
    var test = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don\'t</mixcase> have <lowcase>anything</lowcase> else.';

    var inBrackets = false,
        inClosing = false,
        tag = '',
        result = '';

    for (var i = 0; i < test.length; i += 1) {
        tempSymbol = test[i];
        if (test[i] === '<') {
            inBrackets = true;
            continue;
        }
        if (test[i] === '/') {
            inClosing = true;
            inBrackets = false;
            tag = '';
            continue;
        }
        if (test[i] === '>') {
            inBrackets = false;
            inClosing = false;
            continue;
        }

        if (inBrackets) {
            tag += test[i];
            continue;
        }

        if (tag) {
            switch (tag) {
                case 'upcase':
                    result += test[i].toUpperCase();
                    continue;
                case 'lowcase':
                    result += test[i].toLowerCase();
                    continue;
                case 'mixcase':
                    result += !!(i % 2) ? test[i].toLowerCase() : test[i].toUpperCase();
                    continue;
                default:
                    console.log('cant understand tag!');
            }
        }
        if (!inClosing) {
            result += test[i];
        }
    }
    return result;
}

console.log(parseTags());
//endregion

//region 5. nbsp
/* Write a function that replaces non breaking white-spaces in a text with &nbsp; */
console.log('~~5.nbsp~~');

function nbsp() {
    var test = parseTags(),
        result = '';
    for (var i = 0; i < test.length; i += 1) {
        if (test[i] === ' ') {
            result += '&nbsp;';
        } else {
            result += test[i];
        }
    }
    return result;
}

console.log(nbsp());

//endregion

//region 6. Extract text from HTML
/* Write a function that extracts the content of a html page given as text.
 The function should return anything that is in a tag, without the tags. */
console.log('~~6.Extract text from HTML~~');

function extractTextFromHTML() {
    var test = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
    var inTag = false,
        result = '';
    for (var i = 0; i < test.length; i += 1) {
        if (test[i] === '<') {
            inTag = true;
            continue;
        }
        if (test[i] === '>') {
            inTag = false;
            continue;
        }
        if (!inTag) {
            result += test[i];
        }
    }
    return result;
}

console.log(extractTextFromHTML());
//endregion

//region 7. Parse URL
/* Write a script that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
 Return the elements in a JSON object. */
console.log('~~7.ParseURL~~');

function parseURL() {
    var test = 'http://telerikacademy.com/Courses/Courses/Details/239',
        result = {
            protocol: '',
            server: '',
            resource: ''
        },
        i,
        len,
        inProtocol = true,
        inServer = true;

    for (i = 0, len = test.length; i < len; i += 1) {
        if (test[i] === ':') {
            inProtocol = false;
            i += 2;
            continue;
        }
        if (test[i] === '/') {
            inServer = false;
        }

        if (inProtocol) {
            result.protocol += test[i];
        } else if (inServer) {
            result.server += test[i];
        } else {
            result.resource += test[i];
        }
    }
    return result;
}
console.log(parseURL());
//endregion

//region 8. Replace tags
/* Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. */
console.log('~~8.Replace tags~~');

function replaceTags() {
    var test = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>',
        result = test.replace(/<\/a>/g, '[/URL]').replace(/<a href="/g, '[URL=').replace(/">/g, ']');
    return result;
}

console.log(replaceTags());

//endregion

//region 9. Extract Emails
/* Write a function for extracting all email addresses from given text.
 All sub-strings that match the format @… should be recognized as emails.
 Return the emails as array of strings. */
console.log('~~9.Extract Emails~~');

function extractEmails() {
    var test = 'Hi, you can find us @our emails: weareshano@abv.g or danceonpole@abv.bg feel free to contact us for more info! gotinsam@yahoo.co.uk nesamgotin@ya.',
        emails = {};
    test = test.split(' ');

    for (var i = 0; i < test.length; i += 1) {
        if (test[i].indexOf('@') > -1 && test[i].indexOf('.') > -1) {
            var countBeforeMonkey = 0,
                countAfterTheMonkey = 0,
                countAfterDot = 0,
                beforeMonkey = true,
                afterDot = false,
                isValidEmail = false;
            for (var k = 0; k < test[i].length; k += 1) {
                if (test[i][k] === '@') {
                    beforeMonkey = false;
                    continue;
                }
                if (test[i][k] === '.') {
                    afterDot = true;
                    continue;
                }

                if (beforeMonkey) {
                    countBeforeMonkey += 1;
                } else if (afterDot) {
                    countAfterDot += 1;
                } else {
                    countAfterTheMonkey += 1;
                }
            }

            if (countBeforeMonkey >= 3 && countAfterTheMonkey >= 3 && countAfterDot >= 2) {
                isValidEmail = true;
            }
            emails[test[i]] = isValidEmail;
        }
    }
    return emails;
}
console.log(extractEmails());
//endregion

//region 10. Find palindromes
/* Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe". */
console.log('~~10.Find palindromes~~');

function findPalindromes() {
    var test = 'ABBA lamal exe notevenclose iamalsopalindromemordnilaposlamai metootem'
    test = test.split(' '),
        palindromes = {};

    for (var i = 0; i < test.length; i += 1) {
        var isPalindrome = true,
            previousSymbol = test[i][0];
        for (var k = test[i].length / 2; k >= 0; k -= 1) {
            if (!(test[i][(test[i].length - 1) - k] === test[i][k])) {
                isPalindrome = false;
                break;
            }
        }
        palindromes[test[i]] = isPalindrome;
    }
    return palindromes;
}
console.log(findPalindromes());
//endregion

//region 11. String format
/* Write a function that formats a string using placeholders.
 The function should work with up to 30 placeholders and all types. */
console.log('~~11.String format~~');

function stringFormat() {
    var args = [].slice.call(arguments),
        str = args[0],
        params = args.slice(1),
        result = '',
        inParam = false;

    for (var i = 0; i < str.length; i += 1) {
        //if(str[i].indexOf('{') > -1 && str[i].indexOf('}') > -1) {
        //    result += params[str[i][1]];
        //} else {
        //    result += str[i];
        //}
        if (str[i] === '{') {
            inParam = true;
            continue;
        }
        if (str[i] === '}') {
            inParam = false;
            continue;
        }
        if (inParam) {
            result += params[str[i]];
        } else {
            result += str[i];
        }
    }
    return result;
}

console.log(stringFormat('{0} {1} {2} {3} {4}!', '1', '4m', '4', '133t', 'h4ck3r!'));
//endregion

//region 12.
/* Write a function that creates a HTML <ul> using a template for every HTML <li>.
 The source of the list should be an array of elements.
 Replace all placeholders marked with –{…}– with the value of the corresponding property of the object. */
console.log('~~12.Generate list~~');

function generateList() {
    var people = [
        {name: 'Peter', age: 14},
        {name: 'Gosho', age: 15},
        {name: 'Ivan', age: 18},
        {name: 'Dragan', age: 35}
        ],
        tmpl = document.getElementById('list-item').innerHTML.trim(),
        result = '<ul>\n';
    for(var i = 0; i<people.length; i+=1) {
        var tempLi = '<li>';
        tempLi += tmpl.replace('-{name}-',people[i].name).replace('-{age}-',people[i].age);
        result += tempLi + '</li>\n';
    }
    result += '</ul>';
    return result;
}

console.log(generateList());
//endregion