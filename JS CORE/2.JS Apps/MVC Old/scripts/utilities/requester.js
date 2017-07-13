function _makeRequest(method, url, headers, data) {
    $.ajax({
            method: method,
            url: url,
            headers: headers,
            data: JSON.stringify(data)
        }
    )
}
class Requester {
    constructor() {

    }

    get(headers,url){
        return _makeRequest('GET',url,headers,{})
    }
    post(url,headers,data){
        return _makeRequest('POST',url,headers,data)
    }
    put(){

    }
    delete(){

    }
}