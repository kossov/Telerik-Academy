/* globals $ */

/* 

 Create a function that takes an id or DOM element and:
 If an id is provided, select the element
 Finds all elements with class button or content within the provided element
 Change the content of all .button elements with "hide"
 When a .button is clicked:
 Find the topmost .content element, that is before another .button and:
 If the .content is visible:
 Hide the .content
 Change the content of the .button to "show"
 If the .content is hidden:
 Show the .content
 Change the content of the .button to "hide"
 If there isn't a .content element after the clicked .button and before other .button, do nothing
 Throws if:
 The provided DOM element is non-existant
 The id is either not a string or does not select any DOM element

 */

function solve() {
    return function (selector) {
        var element;
        if (!(selector instanceof HTMLElement)) {
            element = document.getElementById(selector);
            if (element === null) {
                throw new Error();
            }
        } else {
            element = selector;
        }
        var buttons = document.getElementsByClassName('button'),
            contents = document.getElementsByClassName('content'),
            i, len;
        for (i = 0, len = buttons.length; i < len; i += 1) {
            var currentButton = buttons[i];
            currentButton.innerHTML = 'hide';
        }
        element.addEventListener('click', function (ev) {
            debugger;
            var clickedButton = ev.target,
                nextSibling = clickedButton.nextElementSibling,
                contentSibling,
                validContentSibling;
            while (nextSibling) {
                if (nextSibling.className === 'content') {
                    contentSibling = nextSibling;
                    nextSibling = nextSibling.nextSibling;
                    while (nextSibling) {
                        if (nextSibling.className === 'button') {
                            validContentSibling = true;
                            break;
                        }
                        nextSibling = nextSibling.nextElementSibling;
                    }
                    break;
                } else {
                    nextSibling = nextSibling.nextElementSibling;
                }
            }
            if (validContentSibling) {
                if (contentSibling.style.display === 'none') {
                    contentSibling.style.display = '';
                    clickedButton.innerHTML = 'hide';
                } else {
                    contentSibling.style.display = 'none';
                    clickedButton.innerHTML = 'show';
                }
            }
        }, false)
    };
}

module.exports = solve;