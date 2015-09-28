// JavaScript source code
$(document).ready(function () {

    // On set le focus au texte box de username
    $("#inputSearch").trigger("focus");    

    //On cache le contenu de la page
    $("#mainContent").hide();

    if (isFormValid()) {

        $("#searchForm").submit(function (event) {
            var spinner = new Spinner(opts).spin();
            $("#spinnerZone").html(spinner.el);
            $("#mainContent").hide();

            var searchTermsInput = encodeURIComponent($("#inputSearch").val());
            var urlSearch = "http://" + window.location.host + "/ExternalAPI/SearchResults?searchTerms=" + searchTermsInput;

            var request = $.get(urlSearch, function (data) {
                $("#spinnerZone").html("");
                $("#mainContent").show();

                $("#mainContent").html(data);
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
        });
    }

    // Permet de valider le formulaire
    function isFormValid() {
        if ($("#inputSearch").val == "")
            return false;

        return true;
    }

});

