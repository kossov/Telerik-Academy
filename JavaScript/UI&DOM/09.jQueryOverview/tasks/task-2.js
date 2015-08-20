/* globals $ */

/*
 Create a function that takes a selector and:
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided ID is not a **jQuery object** or a `string`

 */
function solve() {
    return function (selector) {
        var $element;
        if (typeof selector !== "string") {
            $element = $(selector);
            if (selector !== $element) {
                throw new Error();
            }
        } else {
            $element = $(selector);
        }
        if($element.length === 0) {
            throw new Error();
        }
        var $buttons = $element.children('.button'),
            i, len;
        for (i = 0, len = $buttons.length; i < len; i += 1) {
            var $currentButton = $($buttons[i]);
            $currentButton.html('hide');
        }
        $element.on('click', 'a', function (e) {
            var topmostContent,
                currentButtonClicked = $(e.target),
                nextSibling = currentButtonClicked.next(),
                validContent;
            while (nextSibling.length > 0) {
                if (nextSibling.hasClass('content')) {
                    topmostContent = nextSibling;
                    nextSibling = nextSibling.next();
                    while (nextSibling.length > 0) {
                        if (nextSibling.hasClass('button')) {
                            validContent = true;
                            break;
                        } else {
                            nextSibling = nextSibling.next();
                        }
                    }
                    break;
                } else {
                    nextSibling = nextSibling.next();
                }
            }

            if (validContent) {
                if (currentButtonClicked.html() === 'hide') {
                    currentButtonClicked.html('show');
                    topmostContent.css('display','none');
                } else {
                    currentButtonClicked.html('hide');
                    topmostContent.css('display','');
                }
            }
        })
    };
}

module.exports = solve;