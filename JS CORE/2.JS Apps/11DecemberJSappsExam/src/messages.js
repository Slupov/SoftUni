function sendMessage(e) {
    e.preventDefault();

    let messageData = {
        recipient_username: $('#formSendMessage select[name=recipient]').val(),
        text: $('#formSendMessage input[name=text]').val(),
        sender_username: sessionStorage.getItem('username'),
        sender_name: sessionStorage.getItem('name')
    };

    let sendMessageRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/messages`,
        headers: {
            'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken'),
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(messageData),
        error: handleAjaxError
    };

    $.ajax(sendMessageRequest)
        .then(() => {
            showInfo('Message sent successfully.');
        });
}

function getMessages(callback) {
    let getMessagesRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/messages`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        error: handleAjaxError
    };

    $.ajax(getMessagesRequest).then(callback);
}

function displayMyMessages(response) {
    let myMessagesTableBody = $('#myMessages tbody');
    myMessagesTableBody.empty();

    let myMessages = response
        .filter(m => m.recipient_username === sessionStorage.getItem('username'))
        .sort(function (a, b) {
            return (a._kmd.lmt < b._kmd.lmt) ? -1 : ((a._kmd.lmt > b._kmd.lmt) ? 1 : 0);
        });

    for (let message of myMessages) {
        let newRow = $(`<tr>
    <td>${formatSender(message.sender_name, message.sender_username)}</td>
</tr>`);

        newRow.append($('<td>').text(message.text));
        newRow.append($('<td>').text(formatDate(message._kmd.lmt)));

        myMessagesTableBody.append(newRow);
    }
}

function displayMyArchive(response) {
    let myArchiveTableBody = $('#sentMessages tbody');
    myArchiveTableBody.empty();

    let myArchives = response
        .filter(m => m.sender_username === sessionStorage.getItem('username'))
        .sort(function (a, b) {
            return (a._kmd.lmt < b._kmd.lmt) ? -1 : ((a._kmd.lmt > b._kmd.lmt) ? 1 : 0);
        });

    for (let message of myArchives) {
        let newRow = $(`<tr>
    <td>${message.recipient_username}</td>
</tr>`);
        newRow.append($('<td>').text(message.text));
        newRow.append($('<td>').text(formatDate(message._kmd.lmt)));

        newRow.append($(`<td>
<button>Delete</button></td>`).click(() => deleteMessage(message._id)));

        myArchiveTableBody.append(newRow);
    }
}

function deleteMessage(id) {
    let deleteAdRequest = {
        method: 'DELETE',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/messages/${id}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: showArchiveSentView,
        error: handleAjaxError
    };

    $.ajax(deleteAdRequest)
        .then(() => {
            showInfo('Message deleted successfully');
        });
}

function formatDate(dateISO8601) {
    let date = new Date(dateISO8601);
    if (Number.isNaN(date.getDate()))
        return '';
    return date.getDate() + '.' + padZeros(date.getMonth() + 1) +
        "." + date.getFullYear() + ' ' + date.getHours() + ':' +
        padZeros(date.getMinutes()) + ':' + padZeros(date.getSeconds());

    function padZeros(num) {
        return ('0' + num).slice(-2);
    }
}

function formatSender(name, username) {
    if (!name)
        return username;
    else
        return username + ' (' + name + ')';
}

