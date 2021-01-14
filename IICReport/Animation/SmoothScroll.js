var marginY = 0;
var destination = 0;
var speed = 10;
var scroller = null;

function initScroll(elementId) {

    destination = document.getElementById(elementId).offsetTop;

    scroller = setTimeout(function () {

        initScroll(elementId);

    }, 1);

    marginY = marginY + speed;

    speed += .5;

    if (marginY >= destination) {
        clearTimeout(scroller);
    }

    window.scroll(0, marginY);

}

window.onscroll = function () {
    marginY = this.pageYOffset;
};