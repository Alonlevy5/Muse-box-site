

//var btn = document.getElementById("myBtn");

//var span = document.getElementsByClassName("close")[0];

///*--------------------------------------------------------*/

//btn.onclick = function () {
//    modal.style.display = "block";
//}


////span.onclick = function () {
////    modal.style.display = "none";
////}


var modal = document.getElementById("myModal");

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}



$(function () {

    $("p.btn").click(function () {

    });
});

$(window).on('unload', function (event) {
    console.log('Handler for `unload` called.');
});

//$('body').click(function () {
//    if (!$(this.target).is('.modal')) {
//        $(".modal").hide(300);
//    }
//}

//);
