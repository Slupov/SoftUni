function validateEmail([email]) {
    let pattern =
        /\b([a-zA-Z0-9])+@([a-z])+\.([a-z])+\b/;
    let result = pattern.test(email);
    if (result) {
        console.log("Valid");
    } else {
        console.log("Invalid");
    }
}