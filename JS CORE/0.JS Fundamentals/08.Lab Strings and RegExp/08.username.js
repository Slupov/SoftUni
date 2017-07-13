function username(input) {
    let list = [];
    for (let i = 0; i < input.length; i++) {
        let email = input[i];
        email = email.split('@');
        let hosting = email[1].split('.').map(x=>x.charAt(0)).join("");
        email = email[0] + "." + hosting;
        list.push(email);
    }
    return list.join(', ');
}