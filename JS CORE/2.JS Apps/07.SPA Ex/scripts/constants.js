const kinveyBaseUrl = "https://baas.kinvey.com/";
const kinveyAppKey = "kid_HybqPBXzl";
const kinveyAppSecret =
    "c2dccdc7576e49068fee9260f1355d97";
const kinveyAppAuthHeaders = {
    'Authorization': "Basic " +
    btoa(kinveyAppKey + ":" + kinveyAppSecret),
};

//some global variables
let kinveyUserUrl = `${kinveyBaseUrl}user/${kinveyAppKey}/${sessionStorage.getItem('userId')}`;

let idUsername = [];