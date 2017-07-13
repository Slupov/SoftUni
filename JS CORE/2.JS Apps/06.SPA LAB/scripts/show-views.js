function showHideMenuLinks() {
    $('#menu a').hide();
    if (desiredStorage.getItem('authToken')) {
        $('#linkHome').show();
        $('#linkListBooks').show();
        $('#linkCreateBook').show();
        $('#linkLogout').show();
    } else {
        //No user logged in
        $('#linkHome').show();
        $('#linkLogin').show();
        $('#linkRegister').show();
    }

}

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

function showCreateBookView() {
    $('#formCreateBook').trigger('reset');
    showView('viewCreateBook');
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
}