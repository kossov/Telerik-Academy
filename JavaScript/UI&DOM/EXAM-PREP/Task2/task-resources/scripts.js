/* globals $ */
$.fn.gallery = function (colPerRow) {
    var columnsPerRow = colPerRow || 4;
    var $gallery = $('#gallery').addClass('gallery');
    var $galleryList = $gallery.children('.gallery-list');
    var $selected = $gallery.children('.selected').hide();
    var allImages = $galleryList.find('img'),
        currentImageData;

    for (var i = 0; i < $galleryList.children().length; i++) {
        var tmpImage = $($galleryList.children()[i]);
        if (i % columnsPerRow === 0 && i !== 0) {
            tmpImage.addClass('clearfix');
        }
    }

    $galleryList.on('click', 'img', function () {
        var $clickedImage = $(this);
        currentImageData = $clickedImage.attr('data-info');
        findImages($clickedImage);
        $gallery.append($('<div />').addClass('disabled-background'));
        $galleryList.addClass('blurred');
        $selected.show();
    });

    function findImages($clickedImg) {
        var clickedImgSrc = $clickedImg.attr('src');
        var $currentImage = $selected.find('#current-image');
        $currentImage.attr('src', clickedImgSrc);

        var $previousImage = $selected.find('#previous-image');
        var previousImageData = findPreviousImgData(currentImageData);
        var previousImageSrc = findSrcByData(previousImageData);
        $previousImage.attr('src', previousImageSrc);

        var $nextImage = $selected.find('#next-image');
        var nextImageData = findNextImgData(currentImageData);
        var nextImageSrc = findSrcByData(nextImageData);
        $nextImage.attr('src', nextImageSrc);
    }

    $selected.on('click', 'img', function (e) {
        var $clickedImg = $(e.target);
        if ($clickedImg.attr('id') === 'previous-image') {
            currentImageData = findPreviousImgData(currentImageData);
            findImages($clickedImg);
        } else if ($clickedImg.attr('id') === 'next-image') {
            currentImageData = findNextImgData(currentImageData);
            findImages($clickedImg);
        } else {
            var $disabledBackground = $gallery.children('.disabled-background');
            $disabledBackground.remove();
            $galleryList.removeClass('blurred');
            $selected.hide();
        }
    });

    function findSrcByData(data) {
        var src;
        for (var i = 0; i < allImages.length; i++) {
            var $currImg = $(allImages[i]);
            if ($currImg.attr('data-info') === data) {
                src = $currImg.attr('src');
                break;
            }
        }
        return src;
    }

    function findPreviousImgData(currentImageData) {
        var result = +currentImageData;
        if (result === 1) {
            result = 12;
        } else {
            result -= 1;
        }
        return '' + result;
    }

    function findNextImgData(currentImageData) {
        var result = +currentImageData;
        if (result === allImages.length) {
            result = 1;
        } else {
            result += 1;
        }
        return '' + result;
    }
};