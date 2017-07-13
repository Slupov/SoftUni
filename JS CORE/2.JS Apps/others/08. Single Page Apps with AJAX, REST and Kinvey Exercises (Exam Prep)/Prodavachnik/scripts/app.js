function startApp() {
    showHideMenuLinks();

    attachMenuLinksEvents();

    attachButtonsEvents();

    showHomeView();

    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => {
            $('#loadingBox').hide();
        }
    });
}

function attachButtonsEvents() {
    $('#buttonRegisterUser').click(registerUser);
    $('#buttonLoginUser').click(loginUser);
    $('#buttonCreateAd').click(createAd);
    $('#buttonEditAd').click(editAd);
}

function attachMenuLinksEvents() {
    $('#linkHome').click(showHomeView);
    $('#linkLogin').click(showLoginView);
    $('#linkRegister').click(showRegisterView);
    $('#linkListAds').click(listAds);
    $('#linkCreateAd').click(showCreateAdView);
    $('#linkLogout').click(logoutUser);
}

function showView(viewName) {
    $('main > section').hide();
    $(`#${viewName}`).show();
}

function showHomeView() {
    showView('viewHome');
}

function showLoginView() {
    showView('viewLogin');
}

function showRegisterView() {
    showView('viewRegister');
}

function showListAdsView() {
    showView('viewAds');
}

function showCreateAdView() {
    showView('viewCreateAd');
}

function showEditAdView() {
    showView('viewEditAd');
}

function showAdDetailsView() {
    showView('viewDetailsAd');
}

function showHideMenuLinks() {
    if (sessionStorage.getItem('authToken')) {
        // Logged in user
        $('#linkHome').show();
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkListAds').show();
        $('#linkCreateAd').show();
        $('#linkLogout').show();
    } else {
        // Not logged in user
        $('#linkHome').show();
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkListAds').hide();
        $('#linkCreateAd').hide();
        $('#linkLogout').hide();
    }
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response);

    if (response.readyState === 0) {
        errorMsg = 'Cannot connect due to network error.';
    }

    if (response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description;
    }

    showError(errorMsg);
}

function showInfoBox(message) {
    $('#infoBox').text(message).show().fadeOut(3000);
}

function showError(message) {
    $('#errorBox').text(message).show().click(() => {
        $('#errorBox').hide();
    });
}
