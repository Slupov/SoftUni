function varNames(input) {
    let regex = new RegExp(/_([a-zA-Z0-9]+)/g);
    let match = regex.exec(input[0]);
    let result = [];
    while (match != null) {
        result.push(match[1]);
        match = regex.exec(input[0]);
    }
    return result.join(",");
}