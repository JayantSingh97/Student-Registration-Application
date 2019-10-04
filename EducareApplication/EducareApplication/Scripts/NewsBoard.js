

$("#viewtoggler").click(function () {
    $("#isloading").show();
    $("#lodertext").html("Creating UI...");

    $("#iconview").toggleClass("fa fa-table");
    $("#iconview").toggleClass("fa fa-address-book ");
    $("#tableview").fadeToggle();
    $("#cardview").fadeToggle();
    $("#lodertext").html("Loading...");
    $("#isloading").hide();

});


$("#filterbtn").click(function () {
    $("#isloading").show();
    $("#lodertext").html("Filtering data...");


});

$("#refresh").click(function () {
    $("#isloading").show();
    setTimeout(function () {
        window.location.reload(true);
    }, 1000);
});


$("#viewtoggler").click(function () {
    $("#filtercontiner").fadeToggle();


});
$("#viewtoggler").click(function () {
    $("#Video").fadeToggle();
    $("#Picture").fadeToggle();

});


$("#Picture").click(function () {

    $(".Picture").slideDown();
    $(".Video").fadeOut();
});
$("#Video").click(function () {
    $(".Picture").fadeOut();

    $(".Video").slideDown();

});
$("#All").click(function () {
    $(".Picture").slideDown();
    $(".Video").slideDown();
    $(".Rejected").slideDown();
    $(".Approved").slideDown();
    $(".Pending").slideDown();
});

$("#rejected").click(function () {
    $(".Rejected").slideDown();
    $(".Approved").fadeOut();
    $(".Pending").fadeOut();
});

$("#approved").click(function () {

    $(".Approved").slideDown();
    $(".Rejected").fadeOut();
    $(".Pending").fadeOut();

});

$("#pending").click(function () {
    $(".Pending").slideDown();
    $(".Approved").fadeOut();
    $(".Rejected").fadeOut();

});





$("#dark").click(function () {
    $("#dark").hide();
    $("#normal").show();
    $("body").toggleClass("table-dark");
    $("#tablenews").toggleClass("table-dark");
    $("textarea").toggleClass("table-dark");
    $(".card").toggleClass("table-dark");
    $(".card-body").toggleClass("table-dark");
    $(".row").toggleClass("table-dark");
    $(".card-header").toggleClass("table-dark");
    $(".navbar-brand").css({ 'color': 'black' });


    $(".form-control-sm").toggleClass("table-dark");
    $("#navslide").css({ 'background': ' #343a40!important' });

    $("#navslide").toggleClass("d-none");
    $("#navslide").toggleClass("d-md-block");
    $("#navslide").toggleClass("bg-light");
    $("#navslide").toggleClass("slidenav-custom");
    $(".sidebar").css({ 'border-right': '1px solid rgb(0, 123, 255)', 'position': 'fixed', 'height': '100%' });
    $(".nav-link").css({ 'color': 'white' });
    $(".available").toggleClass("table-dark");


});

$("#normal").click(function () {
    $("#dark").show();
    $("#normal").hide();
    $("body").toggleClass("table-dark");
    $("#tablenews").toggleClass("table-dark");
    $("textarea").toggleClass("table-dark");
    $(".card").toggleClass("table-dark");
    $(".card-body").toggleClass("table-dark");
    $(".row").toggleClass("table-dark");
    $(".card-header").toggleClass("table-dark");
    $(".navbar-brand").css({ 'color': 'black' });


    $(".form-control-sm").toggleClass("table-dark");
    $("#navslide").css({ 'background': ' #343a40!important' });

    $("#navslide").toggleClass("d-none");
    $("#navslide").toggleClass("d-md-block");
    $("#navslide").toggleClass("bg-light");
    $("#navslide").toggleClass("slidenav-custom");
    $(".sidebar").css({ 'border-right': '2px solid #cacaca', 'position': 'fixed', 'height': '100%' });
    $(".nav-link").css({ 'color': 'black' });


});






 