// JavaScript source code
$(document).ready(function () {

    // Set focus on search box
    $("#inputSearch").trigger("focus");    

    // Hide page content
    $("#mainContent").hide();

    // Submit the search form
    $("#searchForm").submit(function (event) {
        if (isFormValid()) {
            var spinner = new Spinner(opts).spin();
            $("#spinnerZone").html(spinner.el);
            $("#mainContent").hide();
            $("#inputSearch").trigger("blur");

            var searchTermsInput = encodeURIComponent($("#inputSearch").val());
            var urlSearch = "http://" + window.location.host + "/ExternalAPI/SearchResults?searchTerms=" + searchTermsInput;

            var request = $.get(urlSearch, function (data) {
                $("#spinnerZone").html("");
                $("#mainContent").show();

                $("#mainContent").html(data);
                updateControls();

            })
            .done(function () {
                //alert("second success");
            })
            .fail(function () {
                $("#spinnerZone").html("");
                $("#mainContent").show();
                $("#mainContent").html("<strong>ERROR</strong>");
            })
            .always(function () {
                // Marche pas?
            });

            event.preventDefault();
        }
    });
  

    // Form validation
    function isFormValid() {
        if ($("#inputSearch").val() == "")
            return false;

        return true;
    }

    updateControls();

});

function updateControls() {

    // Show card image button
    $(".showCardBtn").click(function () {
        if ($(this).hasClass("imageLoaded")) {
            if ($(this).hasClass("show")) {
                $(this).removeClass("show");
                $(this).hide();
            } else {
                $(this).addClass("show");
                $(this).show();
            }
            $(this).show();

        } else {

            var imageSrc = $(this).data("image-src");
            if (!imageSrc)
                return;

            $(this).addClass("imageLoaded");
            $(this).addClass("show");
            var nextImage = $(this).closest($(".imageContent")).closest("img");

            $(nextImage).attr("src", imageSrc);
            $(nextImage).show();
        }
    });
}

