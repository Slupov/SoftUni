function stringOfnums(input) {
    let n = Number(input[0]);
    let string="";
    for (var i = 1; i <= n; i++) {
        string+=i;
    }
    return string;
}