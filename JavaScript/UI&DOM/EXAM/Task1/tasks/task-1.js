function solve() {
    return function (selector, isCaseSensitive) {
        var root = document.querySelector(selector);

        // MAYBE WORKS
        root.className += 'items-control';
        var isCaseSensitive = isCaseSensitive || false;
        var fragment = document.createDocumentFragment();

        var elementsContainer = document.createElement('div');
        elementsContainer.className += 'add-controls';

        var elementInput = document.createElement('input');
        var elementLabel = document.createElement('label');
        elementLabel.innerHTML = 'Enter text';
        elementLabel.style.fontWeight = 'normal';
        elementLabel.style.display = 'inline-block';
        elementLabel.style.margin = '0';


        var elementButton = document.createElement('button');
        elementButton.className += 'button';
        elementButton.innerHTML = 'Add';

        var elementButtonUl = document.createElement('ul');
        elementButtonUl.className += 'items-list';
        elementButtonUl.style.listStyleType = 'none';

        var elementButtonLi = document.createElement('li');
        elementButtonLi.className += 'list-item';

        var removeButton = document.createElement('button');
        removeButton.className += 'button';
        removeButton.innerHTML = 'X';

        elementButton.addEventListener('click', function () {
            var currentLi = elementButtonLi.cloneNode(true);
            var currentRemoveButton = removeButton.cloneNode(true);
            currentLi.appendChild(currentRemoveButton);
            currentLi.innerHTML += '<b>' + elementInput.value + '</b>';
            elementButtonUl.appendChild(currentLi);
        }, false);

        elementButtonUl.addEventListener('click', function (e) {
            var target = e.target;
            if (target.innerHTML === 'X') {
                elementButtonUl.removeChild(target.parentNode);
            }
        }, false);

        var resultElements = document.createElement('div');
        resultElements.className += 'result-controls';
        resultElements.appendChild(elementButtonUl);

        var searchElements = document.createElement('div');
        searchElements.className += 'search-controls';
        var searchElementsLabel = document.createElement('label');
        searchElementsLabel.innerHTML = 'Search:';
        searchElementsLabel.style.fontWeight = 'normal';
        searchElementsLabel.style.display = 'inline-block';
        searchElementsLabel.style.margin = '0';

        var searchElementsInput = document.createElement('input');
        searchElements.appendChild(searchElementsLabel);
        searchElements.appendChild(searchElementsInput);

        searchElementsInput.addEventListener('input', function (e) {
            var text = this.value;
            var allLi = elementButtonUl.childNodes,
                i, len;
            for (i = 0, len = allLi.length; i < len; i += 1) {
                var currentLiText = allLi[i].childNodes[1].innerHTML,
                    currentLi = allLi[i];
                if (!isCaseSensitive) {
                    currentLiText = makeAllLettersLower(currentLiText);
                    text = makeAllLettersLower(text);
                }

                if (currentLiText.indexOf(text) < 0) {
                    currentLi.style.display = 'none';
                } else {
                    currentLi.style.display = '';
                }
            }
        }, false);

        elementsContainer.appendChild(elementLabel);
        elementsContainer.appendChild(elementInput);
        elementsContainer.appendChild(elementButton);

        fragment.appendChild(elementsContainer);
        fragment.appendChild(searchElements);
        fragment.appendChild(resultElements);
        root.appendChild(fragment);

        function makeAllLettersLower(item) {
            var i, len,
                newItem = '';
            for (i = 0, len = item.length; i < len; i += 1) {
                newItem += item[i].toLowerCase();
            }
            return newItem;
        }
    };
}

//module.exports = solve;