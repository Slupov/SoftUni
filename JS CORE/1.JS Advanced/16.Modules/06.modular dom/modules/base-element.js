class BaseElement {
    constructor () {
        if (new.target === BaseElement) {
            throw new Error('Cannot create an instance of an abstract class');
        }

        this.element = null;
    }

    appendTo (selector) {
        let element = this.createElement();
        $(selector).append(element);
    }

    createElement () {
        this.element = $(this.getElementString());
        return this.element;
    }

    getElementString () {
    }
}

module.exports.BaseElement = BaseElement;
