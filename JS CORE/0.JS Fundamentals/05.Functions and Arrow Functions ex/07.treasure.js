function treasure(input) {
    for (let i = 0; i < input.length; i += 2) {
        if (input[i] >= 8 && input[i] <= 9 && input[i + 1] >= 0 && input[i + 1] <= 1)
            console.log("Tokelau");
        else if (input[i] >= 1 && input[i] <= 3 && input[i + 1] >= 1 && input[i + 1] <= 3)
            console.log("Tuvalu");
        else if (input[i] >= 0 && input[i] <= 2 && input[i + 1] >= 6 && input[i + 1] <= 8)
            console.log("Tonga");
        else if (input[i] >= 5 && input[i] <= 7 && input[i + 1] >= 3 && input[i + 1] <= 6)
            console.log("Samoa");
        else if (input[i] >= 4 && input[i] <= 9 && input[i + 1] >= 7 && input[i + 1] <= 8)
            console.log("Cook");
        else
            console.log("On the bottom of the ocean");
    }
}