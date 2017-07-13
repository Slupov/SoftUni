function loginUser() {
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

function loginSuccess(userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    showHomeView();
    showInfoBox('You are now logged in');
}

function registerUser() {
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
            showInfoBox('Regsitered successfully');
        });
}

function registerSuccess(userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    showHomeView();
    // showInfo('User registration successful.');
}

function saveAuthInSession(userInfo) {
    sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
    sessionStorage.setItem('userId', userInfo._id);
    sessionStorage.setItem('username', userInfo.username);
}

function logoutUser() {
    ///POST user/:appKey/_logout
    sessionStorage.clear();
    showHideMenuLinks();
    showHomeView();
}
