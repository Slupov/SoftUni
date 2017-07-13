function startApp() {
    desiredStorage.clear(); // Clear user auth data
    showHideMenuLinks();
    showView('viewHome');

    $("#infoBox, #errorBox, #loadingBox").hide();
    // Bind the navigation menu links
    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);
    $("#linkListBooks").click(listBooks);
    $("#linkCreateBook").click(showCreateBookView);
    $("#linkLogout").click(logoutUser);

    // Bind the form submit buttons
    $("#buttonLoginUser").click(loginUser);
    $("#buttonRegisterUsero").click(registerUser);
    $("#buttonCreateBook").click(createBook);
    $("#buttonEditBook").click(editBook);

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


function saveAuthInSession(userInfo) {
    let userAuth = userInfo._kmd.authtoken;
    desiredStorage.setItem('authToken', userAuth);
    let userId = userInfo._id;
    desiredStorage.setItem('userId', userId);
    let username = userInfo.username;
    $('#loggedInUser').text(
        "Welcome, " + username + "!");
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response);
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error.";
    if (response.responseJSON &&
        response.responseJSON.description)
        errorMsg = response.responseJSON.description;
    showError(errorMsg);
}



