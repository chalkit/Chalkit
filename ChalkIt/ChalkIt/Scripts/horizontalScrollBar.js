$(function () {
    var pressTimer;
    $("#hroizontalBarScrollRightButton").click(function (e) {
        moveRight(false);
    });
    $("#hroizontalBarScrollLeftButton").click(function (e) {
        moveLeft(false);
    });

    $("#hroizontalBarScrollRightButton").mouseup(function () {
        clearTimeout(pressTimer)
        // Clear timeout
        return false;
    });
    $("#hroizontalBarScrollRightButton").mousedown(function () {
        // Set timeout
        pressTimer = window.setTimeout(function () { moveRight(true) }, 100)
        return false;
    });

    $("#hroizontalBarScrollLeftButton").mouseup(function () {
        clearTimeout(pressTimer)
        // Clear timeout
        return false;
    });
    $("#hroizontalBarScrollLeftButton").mousedown(function () {
        // Set timeout
        pressTimer = window.setTimeout(function () { moveLeft(true) }, 100)
        return false;
    });

    function moveRight(useTimer) {
        $(".hroizontalBarScrollFrame").scrollLeft($(".hroizontalBarScrollFrame").scrollLeft() + 300);
        if (useTimer) {
            pressTimer = window.setTimeout(function () { moveRight(true) }, 100);
        }
    };

    function moveLeft(useTimer) {
        $(".hroizontalBarScrollFrame").scrollLeft($(".hroizontalBarScrollFrame").scrollLeft() - 300);
        if (useTimer) {
            pressTimer = window.setTimeout(function () { moveLeft(true) }, 100);
        }
    };

});