function wordsUppercase(input) {
    let text = input[0].toUpperCase();
    let arr = text.split(/[^A-Za-z0-9]/);
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] == "") {
            arr.splice(i, 1);
        }

    }
    console.log(arr.join(", "));
}