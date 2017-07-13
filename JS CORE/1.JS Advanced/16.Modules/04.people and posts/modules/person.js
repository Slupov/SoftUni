class Person {
    constructor (name, age) {
        this.name = name;
        this.age = age;
        this.posts = [];
    }

    addToSelector (selector) {
        let personDiv = $(`<div class="person ${this.name}"></div>`);
        let nameParagraph = $(`<p class="name">${this.name}</p>`);
        let ageParagraph = $(`<p class="age">${this.age}</p>`);
        let postsDiv = $(`<div class="posts ${this.name}"></div>`);

        personDiv.append(nameParagraph)
                .append(ageParagraph)
                .append(postsDiv);

        $(selector).append(personDiv);
    }
}

module.exports.Person = Person;
