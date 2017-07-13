function addOrRemove(input) {
    let num = 0;
    let array = [];

    for (let i = 0; i < input.length; i++) {
        num++;
        if (input[i] == "add") {
            array.push(num)
        }
        else if (input[i] == "remove") {
            array.pop();
        }
    }
    if (array.length != 0) {
        array.forEach(x => console.log(x));

    }
    else console.log("Empty");
}