function onButtonClick(event, args) {
    var myWindow = window,
        browser = myWindow.navigator.appCodeName,
        ism = browser == "Mozilla";
    if (ism) {
        alert("Yes");
    } else {
        alert("No");
    }
}