class Employee {
    constructor (name, age) {
        if (new.target === Employee) {
            throw new Error('Can\'t create instance of an abstract class');
        }
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    work () {
        let currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(`${this.name} ${currentTask}`);
    }

    collectSalary () {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }

    getSalary () {
        return this.salary;
    }
}

module.exports.Employee = Employee;
