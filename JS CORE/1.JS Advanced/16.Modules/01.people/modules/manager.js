let Employee = require('./employee.js').Employee;

class Manager extends Employee {
    constructor (name, age) {
        super(name, age);
        this.tasks.push('scheduled a meeting.');
        this.tasks.push('is preparing a quarterly report.');
        this.dividend = 0;
    }

    getSalary () {
        return this.salary + this.dividend;
    }
}

module.exports.Manager = Manager;
