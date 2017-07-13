class Entity{
    constructor(){
        if(new.target === Entity){
            throw new Error("Cannot instantiate an abstract class");
        }
    }
}

let e = new Entity();