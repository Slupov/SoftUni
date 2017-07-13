function capitalizeWords(input) {
    return input[0].split(" ").map(x=> x.toLowerCase()).map(x=>x.replace(x[0], x[0].toUpperCase())).join(" ");

}