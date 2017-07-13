const kinveyBaseUrl = "https://baas.kinvey.com/";
const kinveyAppKey = "kid_H1JBKhWzl";
const kinveyAppSecret =
    "5694694d19ba41f4acfba480e9ec0b5d";
const kinveyAppAuthHeaders = {
    'Authorization': "Basic " +
    btoa(kinveyAppKey + ":" + kinveyAppSecret),
};

const desiredStorage = localStorage;