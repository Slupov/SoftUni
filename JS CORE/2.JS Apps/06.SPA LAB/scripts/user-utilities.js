function loginUser() {
    let userData = {
        username: $('#formLogin input[name=username]').val(),
        password: $('#formLogin input[name=passwd]').val()
    };
    $.ajax({
        method: "POST",
        url: kinveyBaseUrl + "user/" + kinveyAppKey + "/login",
        headers: kinveyAppAuthHeaders,
        data: userData,
        success: loginSuccess,
        error: handleAjaxError
    });
}

function logoutUser() {
    sessionStorage.clear();
    $('#loggedInUser').text('');
    showView('viewHome');
    showHideMenuLinks();
    showInfo("Logout successful.")
}

function registerUser(event) {
    event.preventDefault();

    let userData = {
        username: $('#formRegister input[name=username]').val(),
        password: $('#formRegister input[name=passwd]').val()
    };
    $.ajax({
        method: "POST",
        url: kinveyBaseUrl + "user/" + kinveyAppKey + "/",
        headers: kinveyAppAuthHeaders,
        data: JSON.stringify(userData),
        contentType: "application/json",
        success: registerSuccess,
        error: handleAjaxError
    });

}

function loginSuccess(userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    listBooks();
    showInfo('Login successful.');
}


function registerSuccess(userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    listBooks();
    showInfo('User registration successful.');
}

function getKinveyUserAuthHeaders() {
    return {
        'Authorization': "Kinvey " +
        desiredStorage.getItem('authToken'),
    };
}