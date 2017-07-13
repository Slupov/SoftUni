function solve() {
class Person {
    constructor(firstName, lastName, age, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;
    }

    toString() {
        return (`${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`)
    }
}

let people = [];
let mara = people.push(new Person('Maria', 'Petrova', 22, 'mp@yahoo.com'));
let softUni = people.push(new Person('SoftUni'));
let chefo = people.push(new Person('Stephan', 'Nikolov', 25));
let peter = people.push(new Person('Peter','Kolev',24,'ptr@gmail.com'));

    return people;
}
