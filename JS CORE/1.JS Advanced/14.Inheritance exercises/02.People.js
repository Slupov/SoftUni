function solve() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.responsibilities = [];
        }

        work() {
            let currentTask = this.responsibilities.shift();
            console.log(this.name + currentTask);
            this.responsibilities.push(currentTask);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.getSalary()} this month.`);
        }

        getSalary() {
            return this.salary;
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.responsibilities.push(' is working on a simple task.');
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.responsibilities.push(' is working on a complicated task.');
            this.responsibilities.push(' is taking time off work.');
            this.responsibilities.push(' is supervising junior workers.');
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.responsibilities.push(' scheduled a meeting.');
            this.responsibilities.push(' is preparing a quarterly report.');
        }

        getSalary() {
            return this.salary + this.dividend;
        }
    }
    return {Employee, Junior, Senior, Manager}

}
