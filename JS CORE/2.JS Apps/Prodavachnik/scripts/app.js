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

function attachButtonsEvents () {
    $('#buttonRegisterUser').click(registerUser);
    $('#buttonLoginUser').click(loginUser);
    $('#buttonCreateAd').click(createAd);
    $('#buttonEditAd').click(editAd);
}
function loginUser () {
    let userData = {
        username: $('#formLogin input[name=username]').val(),
        password: $('#formLogin input[name=password]').val()
    };

    let loginUserRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}/login`,
        headers: kinveyAppAuthHeaders,
        data: JSON.stringify(userData),
        success: loginSuccess,
        error: handleAjaxError
    };

    $.ajax(loginUserRequest);
}

function loginSuccess (userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    showHomeView();
    showInfoBox('You are now logged in');
    $('#loggedInUser').show().text('Welcome, ' + sessionStorage.getItem('username'));
}

function registerUser () {
    let userData = {
        username: $('#formRegister input[name=username]').val(),
        password: $('#formRegister input[name=password]').val()
    };

    let registerUserRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}`,
        headers: kinveyAppAuthHeaders,
        data: JSON.stringify(userData),
        success: registerSuccess,
        error: handleAjaxError
    };

    $.ajax(registerUserRequest)
        .then(() => {
            showInfoBox('Registered successfully');
        });
}

function registerSuccess (userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    showHomeView();
    showInfoBox('User registration successful.');
}

function saveAuthInSession (userInfo) {
    sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
    sessionStorage.setItem('userId', userInfo._id);
    sessionStorage.setItem('username', userInfo.username);
}

function attachMenuLinksEvents () {
    $('#linkHome').click(showHomeView);
    $('#linkLogin').click(showLoginView);
    $('#linkRegister').click(showRegisterView);
    $('#linkListAds').click(listAds);
    $('#linkCreateAd').click(showCreateAdView);
    $('#linkLogout').click(logoutUser);
}

function listAds () {
    $('#ads').empty();
    let authToken = sessionStorage.getItem('authToken');
    let getAdsRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/Ads`,
        headers: {
            'Authorization': `Kinvey ${authToken}`,
            'Content-Type': 'application/json'
        },
        success: displayAds,
        error: handleAjaxError
    };

    $.ajax(getAdsRequest);
}

function showView (viewName) {
    $('main > section').hide();
    $(`#${viewName}`).show();
}

function showHomeView () {
    showView('viewHome');
}

function showLoginView () {
    showView('viewLogin');
}

function showRegisterView () {
    showView('viewRegister');
}

function showListAdsView () {
    showView('viewAds');
}

function showCreateAdView () {
    showView('viewCreateAd');
}

function showEditAdView () {
    showView('viewEditAd');
}

function showAdDetailsView () {
    showView('viewDetailsAd');
}

function showHideMenuLinks () {
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

function handleAjaxError (response) {
     let errorMsg = JSON.stringify(response);

    if (response.readyState === 0) {
        errorMsg = 'Cannot connect due to network error.';
    }

    if (response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description;
    }

    showError(errorMsg);
}

function logoutUser () {
    sessionStorage.clear();
    showHideMenuLinks();
    showHomeView();
}

function showInfoBox (message) {
    $('#infoBox').text(message).show().fadeOut(3000);
}

function showError(message) {
     $('#errorBox').text(message).show().click(() => {
         $('#errorBox').hide();
     });
}
