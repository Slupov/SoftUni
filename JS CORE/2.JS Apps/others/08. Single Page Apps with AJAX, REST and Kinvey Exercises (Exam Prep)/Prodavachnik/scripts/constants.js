const kinveyBaseUrl = 'https://baas.kinvey.com';
const kinveyAppKey = 'kid_HybqPBXzl';
const kinveyAppSecret = 'c2dccdc7576e49068fee9260f1355d97';
const base64auth = btoa(`${kinveyAppKey}:${kinveyAppSecret}`);
const kinveyAppBasicAuthHeaders = {
    'Authorization': `Basic ${base64auth}`,
    'Content-Type': 'application/json'
};
const kinveyAppKinveyAuthHeaders = {
    'Authorization': `Kinvey sessionStorage.getItem('authToken')`,
    'Content-Type': 'application/json'
};
