function sortAnArray(input) {
    input.sort(function (a, b) {
        var aSize = a.length;
        var bSize = b.length;

        var aCap = a.toUpperCase();
        var bCap = b.toUpperCase();

        if (aSize == bSize) {
            return (aCap < bCap) ? -1 : 1;
        }
        else if (aSize > bSize) return 1;
        else if (aSize < bSize) return -1;
    }).forEach(x => console.log(x));
}