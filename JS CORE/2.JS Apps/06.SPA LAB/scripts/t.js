var BooksDAL = function (countBooks) {
    var BooksCount = countBooks;
    var GetAllBooks = function () {
        var booksFromAJax;
        $.ajax(function () {
            method:"GET",
                url:"",
                error: "",
                success: function() {

            }(data) => {
                booksFromAJax = data;
            }
        });
        return BooksCount;
    };
    this.deleteBooks = function (DeleteBookElement) {

    }
    this.Append = function (BookToAppend) {

    }
    this.ListBooks = function() {
        return this.GetAllBooks();
    }
    this.EditBooks = function(book) {

    }

}
var BooksWOrk = function(BooksDAL) {
    var booksCurentDAL = BooksDAL;
    var buttons1 = document.getElementById("")
    this.addEventDAL = function () {

    }
}
var pr = new Books(10);
