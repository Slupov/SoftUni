class WomanController{
    constructor(model, view){
        this.model = model;
        this.view = view;
    }

    getWomen(){
        this.model.getWomen()
            .then(function (successData) {
                this.view.viewWomen(successData);
            })
            .catch(function (errorData) {
                console.log(errorData);
            });
    }

    postWoman(data){
        this.model.postWoman(data)
            .then(function (successData) {
                console.log("success");
            })
            .catch(function (errorData) {
                console.log("error");
            })
    }
}