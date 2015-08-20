function createImagesPreviewer(selector, items) {
    var root = document.querySelector(selector);
    var fragment = document.createDocumentFragment();

    var aside = document.createElement('div');
    var asideTitle = document.createElement('h3');
    asideTitle.innerText = 'Filter';
    var input = document.createElement('input');
    aside.style.width = '25%';
    aside.style.float = 'left';
    aside.style.display = 'inline-block';
    aside.style.overflowY = 'scroll';
    aside.style.height = '600px';
    aside.appendChild(asideTitle);
    aside.appendChild(input);
    var asideContainer = document.createElement('ul');
    asideContainer.style.listStyleType = 'none';
    asideContainer.style.padding = '0';
    aside.classList.add('image-container');
    aside.style.textAlign = 'center';

    var main = document.createElement('div');
    var mainTitle = document.createElement('h3');
    mainTitle.innerText = items[0].title;
    var mainImg = document.createElement('img');
    mainImg.src = items[0].url;
    mainImg.style.width = '70%';
    main.style.width = '75%';
    main.style.display = 'inline-block';
    main.style.float = 'left';
    main.style.textAlign = 'center';
    main.classList.add('image-preview');
    main.appendChild(mainTitle);
    main.appendChild(mainImg);


    var animalTitle = document.createElement('h3');
    var animalImg = document.createElement('img');
    var li = document.createElement('li');
    for (var i = 0; i < items.length; i++) {
        var animal = items[i];
        var currentAnimalTitle = animalTitle.cloneNode(true);
        var currentAnimalImg = animalImg.cloneNode(true);
        var currentLi = li.cloneNode(true);
        currentAnimalTitle.innerText = animal.title;
        currentAnimalImg.src = animal.url;
        currentAnimalImg.style.width = '90%';

        currentLi.appendChild(currentAnimalTitle);
        currentLi.appendChild(currentAnimalImg);
        asideContainer.appendChild(currentLi);
    }

    asideContainer.addEventListener('mouseover', function (e) {
        var target = e.target;

        if (target.tagName === 'IMG') {
            target.parentNode.style.backgroundColor = '#808080';
            target.parentNode.style.cursor = 'pointer';
        }
    }, false);

    asideContainer.addEventListener('mouseout', function (e) {
        var target = e.target;

        if (target.tagName === 'IMG') {
            target.parentNode.style.backgroundColor = '';
        }
    }, false);

    asideContainer.addEventListener('click', function (e) {
        var target = e.target;

        if (target.tagName === 'IMG') {
            mainTitle.innerText = target.previousElementSibling.innerText;
            mainImg.src = target.src;
        }
    }, false);

    input.addEventListener('keyup', function (e) {
        var text = input.value;
        var allLi = asideContainer.getElementsByTagName('li');

        for (var i = 0; i < allLi.length; i++) {
            var currentLi = allLi[i];
            var currentTitle = currentLi.firstElementChild.innerText;
            if(currentTitle.toLowerCase().indexOf(text.toLowerCase()) < 0) {
                currentLi.style.display = 'none';
            } else {
                currentLi.style.display = 'block';
            }
        }
    }, false);

    aside.appendChild(asideContainer);
    fragment.appendChild(main);
    fragment.appendChild(aside);

    root.appendChild(fragment);
}