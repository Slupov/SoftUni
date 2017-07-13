function usernames(input) {
    let set = new Set();
    for (let name of input) {
      set.add(name);
    }

    set = Array.from(set);
    set = set.sort(function (a, b) {
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