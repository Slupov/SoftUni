function loginUser(e) {
    e.preventDefault();

    let userData = {
        username: $('#formLogin input[name=username]').val(),
        password: $('#formLogin input[name=password]').val()
    };

    let loginUserRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}/login`,
        headers: kinveyAppBasicAuthHeaders,
        data: JSON.stringify(userData),
        success: loginSuccess,
        error: handleAjaxError
    };

    $.ajax(loginUserRequest);

    function loginSuccess(userInfo) {
        saveAuthInSession(userInfo);
        showHideMenuLinks();
        showHomeView();
        showInfo('You are now logged in');
    }
}

function registerUser(e) {
    e.preventDefault();

    let userData = {
        username: $('#formRegister input[name=username]').val(),
        password: $('#formRegister input[name=password]').val(),
        name: $('#formRegister input[name=name]').val()
    };

    let registerUserRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}`,
        headers: kinveyAppBasicAuthHeaders,
        data: JSON.stringify(userData),
        success: registerSuccess,
        error: handleAjaxError
    };

    $.ajax(registerUserRequest)
        .then(() => {
            showInfo('Registered successfully.');
        });

    function registerSuccess(userInfo) {
        saveAuthInSession(userInfo);
        showHideMenuLinks();
        showHomeView();
        showInfo('User registration successful.');
    }

}

function saveAuthInSession(userInfo) {
    sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
    sessionStorage.setItem('name', userInfo.name)
    sessionStorage.setItem('userId', userInfo._id);
    sessionStorage.setItem('username', userInfo.username);
}

function logoutUser() {
    let registerUserRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}/_logout`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: logoutSuccess,
        error: handleAjaxError
    };

    $.ajax(registerUserRequest)
        .then(() => {
            showInfo('Logout successful');
        });

    function logoutSuccess() {
        sessionStorage.clear();
        showHideMenuLinks();
        showHomeView();
    }
}

function getAllUsers() {
    let registerUserRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: updateSelectOptions,
        error: handleAjaxError
    };

    $.ajax(registerUserRequest)
}

function updateSelectOptions(users) {
    let selectObject = $("#msgRecipientUsername");
    selectObject.empty();

    for (let user of users) {
        let newOption = $(`<option value=${user.username}>
${formatSender(user.name, user.username)}
</option>`)
        selectObject.append(newOption);
    }
}