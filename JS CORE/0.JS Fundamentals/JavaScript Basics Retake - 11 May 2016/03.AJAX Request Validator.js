function ajaxRequestValidator(input) {
    let hashPass = input.pop().split("");

    for (let i = 0; i < input.length; i+=2) {
        let response = "Response-";

        let method = input[i].split(":").map(x=>x.trim())[1];
        let credentials = input[i+1].split(" ").map(x=>x.trim()).filter(x=>x!="");
        let authType = credentials[1];
        let authToken = credentials[2];
        let content = input[i+2].split(":").map(x=>x.trim())[1];

        let isAuthTokenValid = false;
        //start to check if the auth token is valid

        if(authType == "Basic" && (method == "POST" || method == "DELETE" || method == "PUT")){
            console.log(`Response-Method:${method}&Code:401`);
        }

    }
}

let arr = [
    'Method: GET',
    'Credentials: Bearer asd918721jsdbhjslkfqwkqiuwjoxXJIdahefJAB',
    'Content: users.asd.1782452.278asd',
    'Method: POST',
    'Credentials: Basic 028591u3jtndkgwndsdkfjwelfqkjwporjqebhas',
    'Content: Johnathan',
    '2q'
];

ajaxRequestValidator(arr);