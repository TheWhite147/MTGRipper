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
            var urlSearch = "http://" + window.location.host + "/api/values?q=" + searchTermsInput;

            var request = $.get(urlSearch, function (data) {
                $("#spinnerZone").html("");
                $("#mainContent").show();

                var htmlOutput = getCardsPricesHTML(data);
                $("#mainContent").html(htmlOutput);
            })
            .done(function () {
                //alert("second success");
            })
            .fail(function (err) {
                $("#spinnerZone").html("");
                $("#mainContent").show();
                $("#mainContent").html("<strong>ERROR</strong><br /><br />" + err);
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

    // Permet d'obtenir le prix de la carte trouvée en JSON
    function getCardsPricesHTML(jsonResponse) {
        var cards = JSON.parse(jsonResponse);
        var htmlOutput1 = '<div class="panel panel-info"><div class="panel-heading"><h3 class="panel-title cardName">';
        var htmlOutput2 = '</h3><div class="cardSet">';
        var htmlOutput3 = '</div></div><div class="panel-body"><div class="mainPrice">$ ';
        var htmlOutput4 = ' </div></div></div>';

        var htmlFullOutput = "";

        if (cards.length > 0) {
            for(var i = 0; i < cards.length; i++) {
                var card = cards[i];
                htmlFullOutput += htmlOutput1 + card.name + htmlOutput2 + card.setName + htmlOutput3 + card.fair_price + htmlOutput4;
            }
        }

        return htmlFullOutput;
    }

    // Permet de convertir un prix de USD à CAD
    function convertToCAD(USD, callback) {

    }

});

