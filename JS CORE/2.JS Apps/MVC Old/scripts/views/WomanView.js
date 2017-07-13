class WomanView{
    constructor(){
    }

    viewWomen(data){
        data.forEach(function (woman) {
            let womenList = $('<div class="womenList"></div>');
            data.forEach(function (woman) {
                let womanElement = $('<div class="womanElement"></div>');

                womanElement.append(`<div>${woman.name}</div>`);
                womanElement.append(`<div>${woman.age}</div>`);
                womanElement.append(`<div>${woman.weight}</div>`);
                womanElement.append(`<div>${woman.mantalitet}</div>`);

                womenList.append(womanElement);
            })
        })
    }
}