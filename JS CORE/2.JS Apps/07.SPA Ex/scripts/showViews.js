function showView(viewName) {
    // Hide all views and show the selected view only
    $('main > section').hide();
    $('#' + viewName).show();
}

function showHomeView() {
    showView("viewHome");
}

function showLoginView() {
    showView('viewLogin');
    $('#formLogin').trigger('reset');
}

function showRegisterView() {
    $('#formRegister').trigger('reset');
    showView('viewRegister');
}

function showCreateAdView() {
    $('#formCreateAd').trigger('reset');
    showView('viewCreateAd');
}
function showListAdsView() {
    showView('viewAds');
    showAds();
}
function showInfo(message) {
    $('#infoBox').text(message);
    $('#infoBox').show();
    setTimeout(function () {
        $('#infoBox').fadeOut();
    }, 3000);
}

function showError(errorMsg) {
    $('#errorBox').text("Error: " + errorMsg);
    $('#errorBox').show();
    setTimeout(function () {
        $('#errorBox').fadeOut();
    }, 6000);
}

