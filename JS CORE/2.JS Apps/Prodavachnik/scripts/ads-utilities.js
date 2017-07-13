function editAd () {
    let adId = $('#formEditAd input[name=id]').val();
    let dateInfo = $('#formEditAd input[name=datePublished]').val().split('-');
    let dateCreated = `${dateInfo[1]}/${dateInfo[2]}/${dateInfo[0]}`;
    let price = Number($('#formEditAd input[name=price]').val()).toFixed(2);
    price = Number(price);
    let updatedAd = {
        title: $('#formEditAd input[name=title]').val(),
        description: $('#formEditAd textarea[name=description]').val(),
        publisher: $('#formEditAd input[name=publisher]').val(),
        dateCreated: dateCreated,
        price: price,
        image: $('#formEditAd input[name=image]').val()
    };

    let updateAddRequest = {
        method: 'PUT',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/Ads/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(updatedAd),
        success: listAds,
        error: handleAjaxError
    };

    $.ajax(updateAddRequest)
        .then(() => {
            showInfoBox('Ad edited successfully');
        });
}

function createAd () {
    let title = $('#formCreateAd input[name=title]').val();
    let description = $('#formCreateAd textarea[name=description]').val();
    let publisher = sessionStorage.getItem('username');
    let dateInfo = $('#formCreateAd input[name=datePublished]').val().split('-');
    let dateCreated = `${dateInfo[1]}/${dateInfo[2]}/${dateInfo[0]}`;
    let price = Number($('#formCreateAd input[name=price]').val()).toFixed(2);
    price = Number(price);
    let image = $('#formCreateAd input[name=image]').val();
    let newAd = {
        title: title,
        description: description,
        publisher: publisher,
        dateCreated: dateCreated,
        price: price,
        image: image,
        views: 0
    };

    let createAdRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/Ads`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(newAd),
        success: listAds,
        error: handleAjaxError
    };

    $.ajax(createAdRequest)
        .then(() => {
            showInfoBox('Ad created successfully');
        });
}

function displayAdInEditForm (adInfo) {
    $('#formEditAd input[name=id]').val(adInfo._id);
    $('#formEditAd input[name=title]').val(adInfo.title);
    $('#formEditAd textarea[name=description]').val(adInfo.description);
    $('#formEditAd input[name=publisher]').val(adInfo.publisher);
    let datePublished = new Date(adInfo.dateCreated);
    datePublished.setDate(datePublished.getDate() + 1);
    $('#formEditAd input[name=datePublished]').val(datePublished.toISOString().substr(0, 10));
    $('#formEditAd input[name=price]').val(adInfo.price);
    $('#formEditAd input[name=image]').val(adInfo.image);

    showEditAdView();
}

function getAdInfo (event) {
    let adId = $(event.currentTarget).attr('data-ad-id');
    let getAdRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/Ads/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: displayAdInEditForm,
        error: handleAjaxError
    };

    $.ajax(getAdRequest);
}

function deleteAd (event) {
    let adId = $(event.currentTarget).attr('data-ad-id');

    let deleteAdRequest = {
        method: 'DELETE',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/Ads/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: listAds,
        error: handleAjaxError
    };

    $.ajax(deleteAdRequest)
        .then(() => {
            showInfoBox('Ad deleted successfully');
        });
}

function displayAdDetails (ad) {
    $('#viewDetailsAd').empty();

    let adInfo = $('<div>').append(
        $(`<img src="${ad.image}" width="100" height="100">`),
        $('<br>'),
        $('<label>').text('Title:'),
        $('<h1>').text(ad.title),
        $('<label>').text('Description:'),
        $('<p>').text(ad.description),
        $('<label>').text('Publisher:'),
        $('<div>').text(ad.publisher),
        $('<label>').text('Date:'),
        $('<div>').text(ad.dateCreated),
        $('<label>').text('Views:'),
        $('<div>').text(ad.views)
    );

    $('#viewDetailsAd').append(adInfo);
    showAdDetailsView();
}

function attachAdsButtonsEvents () {
    $('.delete-ad-btn').click(deleteAd);
    $('.edit-ad-btn').click(getAdInfo);
    $('.read-more-btn').click(getAdDetails);
}

function getAdDetails (event) {
    let adId = $(event.currentTarget).attr('data-ad-id');
    console.log(adId);
    let getAdDetailsRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/Ads/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: displayAdDetails,
        error: handleAjaxError
    };

    $.ajax(getAdDetailsRequest);
}

function displayAds (ads) {
    let table = $(`<table>
                        <tr>
                            <th>Title</th>
                            <th>Publisher</th>
                            <th>Description</th>
                            <th>Price</th>
                            <th>Date Published</th>
                            <th>Actions</th>
                        </tr>
                    </table>`);

    let userId = sessionStorage.getItem('userId');
    for (let ad of ads) {
        let tr = $('<tr>');
        let titleTd = $('<td>').text(ad.title);
        let publisherTd = $('<td>').text(ad.publisher);
        let descriptionTd = $('<td>').text(ad.description);
        let priceTd = $('<td>').text(ad.price);
        let datePublishedTd = $('<td>').text(ad.dateCreated);
        let moreDetailsLink = $(`<a href="#" data-ad-id="${ad._id}" class="read-more-btn">[Read More] </a>`);
        let actionsTd = $('<td>');
        actionsTd.append(moreDetailsLink);
        tr.append(titleTd)
            .append(publisherTd)
            .append(descriptionTd)
            .append(priceTd)
            .append(datePublishedTd);

        if (ad._acl.creator === userId) {
            let deleteButton = $(`<a href="#" class="delete-ad-btn" data-ad-id="${ad._id}"></a>`).text('[Delete] ');
            let editButton = $(`<a href="#" class="edit-ad-btn" data-ad-id="${ad._id}"></a>`).text('[Edit]');
            actionsTd.append(deleteButton).append(editButton);
        }

        tr.append(actionsTd);
        table.append(tr);
    }

    $('#ads').append(table);
    attachAdsButtonsEvents();
    showListAdsView();
}
