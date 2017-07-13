function listBooks() {
    showView('viewBooks');
    $.ajax({
        method: "GET",
        url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books",
        headers: getKinveyUserAuthHeaders(),
        success: loadBooksSuccess,
        error: handleAjaxError
    });

    function loadBooksSuccess(books) {
        showInfo('Books loaded.');
        if (books.length == 0) {
            $('#books').text('No books in the library.');
        } else {
            let booksTable = $("#books table");
            booksTable.empty();

            booksTable.append($('<tr>').append(
                '<th>Title</th><th>Author</th>',
                '<th>Description</th><th>Actions</th>'));

            for (let book of books)
                appendBookRow(book, booksTable);
            $('#books').append(booksTable);
        }
    }
}

function appendBookRow(book, booksTable) {
    booksTable.append($('<tr>').append(
        $('<td>').text(book.title),
        $('<td>').text(book.author),
        $('<td>').text(book.description),
        $('<td>')
            .append($('<a href="#">[Edit]</a>').click(()=> editBook(book)))
            .append($('<a href="#">[Delete]</a>').click(()=> deleteBook(book)))
    ));
}
//if u bind this to the click event
//it automatically invokes the ajax request
//but why ??
function deleteBook(book) {
    //TO DO:
    //if auth user is not author -> this.display = none
    console.dir(book);

    $.ajax({
        method: "DELETE",
        url: kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books/' + book["_id"],
        headers: getKinveyUserAuthHeaders(),
        contentType: "application/json"
    })
}

function editBook(book){
    showView("viewEditBook");

    //change input default values
    //to the current book info

    let edited = {
        title: $('#formEditBook input[name=title]').val(),
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

function createBook() {
    let book = {
        title: $('#formCreateBook input[name=title]').val(),
        author: $('#formCreateBook input[name=author]').val(),
        description: $('#formCreateBook textarea[name=descr]').val()
    };

    $.ajax({
        method: "POST",
        url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books",
        headers: getKinveyUserAuthHeaders(),
        data: JSON.stringify(book),
        contentType: "application/json",
        success: showInfo("Book created successfully"),
        error: handleAjaxError
    })
}

