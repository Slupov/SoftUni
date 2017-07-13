function loginUser(event) {
    event.preventDefault();

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

    function loginSuccess(userInfo) {
        saveAuthInSession(userInfo);
        $("#loggedInUser").text(`Hello, ${userInfo.username}`)
        showHideMenuLinks();
        showInfo('User login successful.');
        showView('viewHome');
    }
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

    function registerSuccess(userInfo) {
        saveAuthInSession(userInfo);
        showHideMenuLinks();
        showInfo('User registration successful.');
        updateIdUsernameArray();
    }
}

function updateIdUsernameArray() {
    $.get({
        method: "GET",
        url: kinveyBaseUrl + 'user/' + kinveyAppKey,
        contentType: "application/json",
        headers: getKinveyUserAuthHeaders()
    })
        .then(function (response) {
            for (let user of response) {
                alert(user);
              idUsername.user._id = user.username;
            }
        })
        .catch(handleAjaxError)
}

function logoutUser() {
    sessionStorage.clear();
    $('#loggedInUser').text('');
    showView('viewHome');
    showHideMenuLinks();
    showInfo("Logout successful.")
}

function showAds() {
    let url = kinveyBaseUrl + 'appdata/' + kinveyAppKey + "/Ads";

    $.get({
        method: "GET",
        url: url,
        contentType: "application/json",
        headers: getKinveyUserAuthHeaders()
    })
        .then(drawAdsInTable)
        .catch(handleAjaxError)

    function drawAdsInTable(response) {
        let table = $("#ads table");
        $(table.body).empty();

        for (let ad of response) {
            //get author name from idUsername assoc array
            let newRow = $("<tr></tr>");
            newRow.append($(`<td>${ad.title}</td>`))
                .append($(`<td>${idUsername[ad._acl.creator]}</td>`))
                .append($(`<td>${ad.description}</td>`))
                .append($(`<td>${ad.price}</td>`))
                .append($(`<td>${ad.date}</td>`))
                .append($(`<td>
                        <a href="#">[Delete]</a>
                        <a href="#">[Edit]</a>
                    </td>`));

            table.append(newRow);
            //add Edit and Delete functionality
        }
    }
}

function editAd() {
    showView("viewEditAd");

    let edited = {
        title: $('#formEditAd input[name=title]').val(),
        author: $('#formEditBook input[name=author]').val(),
        description: $('#formEditBook textarea[name=descr]').val()
    }

    $('#formEditBook input[id=buttonEditBook]').click(()=>{
        $.ajax({
            method: "PUT",
            url: kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books/' + book["_id"],
            data: JSON.stringify(edited),
            headers: getKinveyUserAuthHeaders(),
            contentType: "application/json"
        })
            .then(showInfo("Book edited."))
            .catch(handleAjaxError());
    })
}
function createAdvert() {
    let advert = {
        title: $('#formCreateAd input[name=title]').val(),
        description: $('#formCreateAd textarea[name=description]').val(),
        date: $('#formCreateAd input[name=datePublished]').val()
        ,
        price: $('#formCreateAd input[name=price]').val()
    };

    $.ajax({
        method: "POST",
        url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/Ads",
        headers: getKinveyUserAuthHeaders(),
        data: JSON.stringify(advert),
        contentType: "application/json",
        success: adCreateSuccess,
        error: handleAjaxError
    });

    function adCreateSuccess(response) {
        showInfo(`Ad successfully created`);
    }
}

function handleAjaxError(response) {
    showError(response.responseJSON.description);
}