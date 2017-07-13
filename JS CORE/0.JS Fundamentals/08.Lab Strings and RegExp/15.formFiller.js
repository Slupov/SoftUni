function formFiller(input) {

    let username = input.shift();
    let email = input.shift();
    let phone = input.shift();

    let usernameRegex = /<![a-zA-Z]+!>/g;
    let emailRegex = /<@[a-zA-Z]+@>/g;
    let phoneRegex = /<\+[a-zA-Z]+\+>/g;

    for (let i = 0; i < input.length; i++) {
        if (usernameRegex.test(input[i])) {
            input[i] = input[i].replace(usernameRegex, username);
        }
        if (emailRegex.test(input[i])) {
            input[i] = input[i].replace(emailRegex, email);
        }
        if (phoneRegex.test(input[i])) {
            input[i] = input[i].replace(phoneRegex, phone);
        }
    }
    for (let line of input) {
        console.log(line.toString());
    }
}