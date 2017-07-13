const kinveyBaseUrl = 'https://baas.kinvey.com';
const kinveyAppKey = 'kid_B1my2Oc7e';
const kinveyAppSecret = '178d1b1841d8468f9c7e2f7b26f78c04';

const base64auth = btoa(`${kinveyAppKey}:${kinveyAppSecret}`);

const kinveyAppBasicAuthHeaders = {
    'Authorization': `Basic ${base64auth}`,
    'Content-Type': 'application/json'
};

