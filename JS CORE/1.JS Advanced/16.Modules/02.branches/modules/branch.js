let Employee = require('./employee.js').Employee;

class Branch {
    constructor (id, branchName, companyName) {
        this._branchId = id;
        this._branchName = branchName;
        this._companyName = companyName;
        this._employees = [];
    }

    get employees () {
        return this._employees;
    }

    hire (employee) {
        this._employees.push(employee);
    }

    toString () {
        let resultString = `@ ${this._companyName}, ${this._branchName}, ${this._branchId}\nEmployed:`;

        for (let employee of this.employees) {
            resultString += `\n** ${employee.toString()}`;
        }

        return resultString;
    }
}

module.exports.Branch = Branch;
