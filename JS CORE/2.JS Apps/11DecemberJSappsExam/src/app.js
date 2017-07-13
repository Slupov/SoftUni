function startApp() {
     //test users: slupov -> 123
    //user->pass : klupov -> 123

    hideUIboxes();

    showHideMenuLinks();

    attachMenuLinksEvents();

    attachButtonsEvents();

    showHomeView();

    //show loading box on every query
    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => {
            $('#loadingBox').hide();
        }
    });
}

function hideUIboxes() {
    $('#infoBox').hide();
    $('#loadingBox').hide();
    $('#errorBox').hide();
    $('#spanMenuLoggedInUser').hide();
}

function attachButtonsEvents() {
    $('#formRegister').submit(registerUser);
    $('#formLogin').submit(loginUser);
    $('#formSendMessage').submit(sendMessage);

    $('#linkUserHomeMyMessages').click(showMyMessagesView);
    $('#linkUserHomeSendMessage').click(showSendMessageView);
    $('#linkUserHomeArchiveSent').click(showArchiveSentView);

}

function attachMenuLinksEvents() {
    $('#linkMenuAppHome').click(showHomeView);
    $('#linkMenuLogin').click(showLoginView);
    $('#linkMenuRegister').click(showRegisterView);
    $('#linkMenuUserHome').click(showUserHomeView);
    $('#linkMenuMyMessages').click(showMyMessagesView);
    $('#linkMenuArchiveSent').click(showArchiveSentView);
    $('#linkMenuSendMessage').click(showSendMessageView);
    $('#linkMenuLogout').click(logoutUser);
}

function showView(viewName) {
    $('main > section').hide();
    $(`#${viewName}`).show();
}

function showHomeView() {
    showView('viewAppHome');
}

function showLoginView() {
    showView('viewLogin');
}

function showRegisterView() {
    showView('viewRegister');
}

function showUserHomeView() {
    showView('viewUserHome');
}

function showMyMessagesView() {
    showView('viewMyMessages');
    getMessages(displayMyMessages);
}

function showArchiveSentView() {
    getMessages(displayMyArchive);
    showView('viewArchiveSent');
}

function showSendMessageView() {
    $('#msgText').val("");
    showView('viewSendMessage');
    getAllUsers();
}

function showHideMenuLinks() {
    if (sessionStorage.getItem('authToken')) {
        // If there's a logged in user
        $('#linkMenuUserHome').show();
        $('#linkMenuMyMessages').show();
        $('#linkMenuArchiveSent').show();
        $('#linkMenuSendMessage').show();
        $('#linkMenuLogout').show();
        $('#spanMenuLoggedInUser').text("Welcome, " + sessionStorage.username).show();
        $('#viewUserHomeHeading').text("Welcome, " + sessionStorage.username);

        $('#linkMenuAppHome').hide();
        $('#linkMenuLogin').hide();
        $('#linkMenuRegister').hide();

    } else {
        // No logged in user
        $('#linkMenuAppHome').show();
        $('#linkMenuLogin').show();
        $('#linkMenuRegister').show();

        $('#linkMenuUserHome').hide();
        $('#linkMenuMyMessages').hide();
        $('#linkMenuArchiveSent').hide();
        $('#linkMenuSendMessage').hide();
        $('#linkMenuLogout').hide();
        $('#spanMenuLoggedInUser').hide();
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

function showInfo(message) {
    $('#infoBox').text(message).show().fadeOut(3000);
}

function showError(message) {
    $('#errorBox').text(message).show().click(() => {
        $('#errorBox').hide();
    });
}
