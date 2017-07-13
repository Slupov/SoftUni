class CheckingAccount {
    constructor (clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.products = [];
    }

    set clientId (newIdValue) {
        let idRegex = /^\d{6}$/g;

        if (!idRegex.exec(newIdValue)) {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        this._clientId = newIdValue;
    }

    get clientId () {
        return this._clientId;
    }

    set email (newEmailValue) {
        let emailRegex = /[a-zA-Z]{1,}@[a-zA-Z.]{1,}/g
        
        if (!emailRegex.exec(newEmailValue)) {
            throw new TypeError('Invalid e-mail');
        }
        
        this._email = newEmailValue;
    }

    get email () {
        return this._email;
    }

    set firstName (newFirstNameValue) {
        let nameRangeRegex = /^.{3,20}$/g;
        if (!nameRangeRegex.exec(newFirstNameValue)) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        }

        let nameLettersRegex = /^[a-zA-Z]+$/g;
        if (!nameLettersRegex.exec(newFirstNameValue)) {
            throw new TypeError('First name must contain only Latin characters');
        }

        this._firstName = newFirstNameValue;
    }

    get firstName () {
        return this._firstName;
    }

    set lastName (newLastNameValue) {
        let nameRangeRegex = /^.{3,20}$/g;
        if (!nameRangeRegex.exec(newLastNameValue)) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }

        let nameLettersRegex = /^[a-zA-Z]+$/g;
        if (!nameLettersRegex.exec(newLastNameValue)) {
            throw new TypeError('Last name must contain only Latin characters');
        }

        this._lastName = newLastNameValue;
    }

    get lastName () {
        return this._lastName;
    }
}
