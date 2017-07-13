sessionStorage.setItem('authToken' , btoa('guest:guest'));

function run() {

    let router = Sammy('.wrapper',function () {
        const baseURL = 'https://baas.kinvey.com/';
        const appKey = 'kid_HyeIcljMe';
        const appSecret = '511dde895bc74759b913617cb9483d4c';

        let requester = new Requester();
        let authorizationService = new AuthorizationService();

        let womanView = new WomanView();
        let womanModel = new WomanModel(baseURL,appKey,requester,authorizationService);
        let womanController = new WomanController(womanModel,womanView);

        womanController.postWoman({
            'name' : 'tuhlichka',
            'age' : 35,
            'weight' : 135,
            'mantalitet' : 'selski'
        });

        womanController.postWoman({
            'name' : 'buhtichka',
            'age' : 1,
            'weight' : 20,
            'mantalitet' : 'bebeshki'
        });

        womanController.postWoman({
            'name' : 'Emo',
            'age' : 28,
            'weight' : 105,
            'mantalitet' : 'mnoo zle'
        });

        womanController.postWoman({
            'name' : 'Mara',
            'age' : 20,
            'weight' : 66,
            'mantalitet' : 'Dqvola-Zmiq'
        });

        womanController.getWomen();
    })

    router.run('#/');
}