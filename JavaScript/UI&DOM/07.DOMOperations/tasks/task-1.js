/* globals $ */

/* 

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neight `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {
    return function (element, contents) {
        var givenElement,
            args = Array.prototype.slice.call(arguments);
        if (args.length !== 2) {
            throw new Error();
        }
        if (!Array.isArray(contents)) {
            throw new Error();
        }
        if (element instanceof HTMLElement) {
            givenElement = element;
        } else if (typeof element === 'string') {
            givenElement = document.getElementById(element);
            if (!(givenElement instanceof HTMLElement)) {
                throw new Error();
            }
        } else {
            throw new Error();
        }
        contents.forEach(function (content) {
            if (typeof content !== 'string' && typeof content !== 'number') {
                throw new Error();
            }
        });
        givenElement.innerHTML = '';

        var dFrag = document.createDocumentFragment(),
            len, i,
            div = document.createElement('div');
        for (i = 0, len = contents.length; i < len; i += 1) {
            var divsContent = contents[i],
                currentDiv = div.cloneNode(true);
            currentDiv.innerHTML = divsContent;
            dFrag.appendChild(currentDiv);
        }
        givenElement.appendChild(dFrag);
    };
};