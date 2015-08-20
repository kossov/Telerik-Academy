function createCalendar(selector, events) {
    var root = document.querySelector(selector);
    var fragment = document.createDocumentFragment();
    var lastClickedElementTitle;

    var ul = document.createElement('ul');
    ul.style.listStyleType = 'none';
    var li = document.createElement('li');
    var liTitle = document.createElement('h3');
    var liContent = document.createElement('div');
    for (var i = 0, j = i + 1; i < 30; i += 1, j += 1) {
        var currentLi = li.cloneNode(true);
        currentLi.style.display = 'inline-block';
        currentLi.style.border = '1px solid black';
        currentLi.style.width = '170px';
        currentLi.style.height = '200px';
        var currentLiTitle = liTitle.cloneNode(true);
        var currentLiContent = liContent.cloneNode(true);
        currentLiContent.style.display = 'inline-block';

        if (j >= 8) {
            j = 1;
        }
        var currentDay;
        switch (j) {
            case 1:
                currentDay = 'Sun';
                break;
            case 2:
                currentDay = 'Mon';
                break;
            case 3:
                currentDay = 'Tue';
                break;
            case 4:
                currentDay = 'Wed';
                break;
            case 5:
                currentDay = 'Thu';
                break;
            case 6:
                currentDay = 'Fri';
                break;
            case 7:
                currentDay = 'Sat';
                break;
        }
        currentLiTitle.innerText = currentDay + ' ' + (i+1) + ' June 2014';
        currentLiTitle.style.margin = '0';
        currentLiTitle.style.textAlign = 'center';
        currentLiTitle.style.background = 'grey';
        currentLiTitle.style.fontWeight = 'bold';

        events.forEach(function (event) {
            if (i + 1 === +event.date) {
                var eventTitle = event.title;
                var eventTime = event.hour;
                currentLiContent.innerHTML = eventTime + ' <strong>' + eventTitle + '</strong>';
            }
        });
        currentLi.appendChild(currentLiTitle);
        currentLi.appendChild(currentLiContent);
        ul.appendChild(currentLi);
    }

    ul.addEventListener('mouseover', function (e) {
        var target = e.target;
        if (target.tagName === 'LI') {
            target.firstElementChild.style.background = '#010101';
        }
    }, false);

    ul.addEventListener('mouseout', function (e) {
        var target = e.target;
        if (target.tagName === 'LI') {
            target.firstElementChild.style.background = 'grey';
        }
    }, false);

    ul.addEventListener('click', function (e) {
        var target = e.target;
        if (target.tagName === 'LI') {
            if (lastClickedElementTitle !== target.firstElementChild.innerText) {
                var allLis = ul.getElementsByTagName('li');
                for (var i = 0; i < allLis.length; i++) {
                    var currentLi = allLis[i];
                    if (currentLi.firstElementChild.innerText === lastClickedElementTitle) {
                        currentLi.style.background = '';
                        break;
                    }
                }
            }
            lastClickedElementTitle = target.firstElementChild.innerText;
            target.style.background = 'red';
        }
    }, false);

    fragment.appendChild(ul);
    root.appendChild(fragment);
}