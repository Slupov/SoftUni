function startApp() {
    sessionStorage.clear(); // Clear user auth data
    showHideMenuLinks();
    showView('viewHome');

    $("#infoBox, #errorBox, #loadingBox").hide();
    // Bind the navigation menu links
    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);
    $("#linkCreateAd").click(showCreateAdView);
    $("#linkListAds").click(showListAdsView);
    $("#linkLogout").click(logoutUser);

    // Bind the form submit buttons
    $("#buttonLoginUser").click(loginUser);
    $("#buttonRegisterUser").click(registerUser);
    $("#buttonCreateAd").click(createAdvert);
    $("#buttonEditAd").click(editAd);

    // Bind the info / error boxes: hide on click
    $("#infoBox, #errorBox").click(function () {
        $(this).fadeOut();
    });

    // Attach AJAX "loading" event listener
    $(document).on({
        ajaxStart: function () {
            $("#loadingBox").show()
        },
        ajaxStop: function () {
            $("#loadingBox").hide()
        }
    });
}

function showHideMenuLinks() {
    $('#menu a').hide();
    if (sessionStorage.getItem('authToken')) {
        $('#linkHome').show();
        $('#linkListAds').show();
        $('#linkCreateAd').show();
        $('#linkLogout').show();
        $('#loggedInUser').show();
    } else {
        //No user logged in
        $('#linkHome').show();
        $('#linkLogin').show();
        $('#linkRegister').show();
    }
}

function saveAuthInSession(userInfo) {
    let userAuth = userInfo._kmd.authtoken;
    sessionStorage.setItem('authToken', userAuth);
    let userId = userInfo._id;
    sessionStorage.setItem('userId', userId);
    let username = userInfo.username;
    $('#loggedInUser').text(
        "Welcome, " + username + "!");
}

function getKinveyUserAuthHeaders() {
    return {
        'Authorization': "Kinvey " +
        sessionStorage.getItem('authToken')
    };
}

