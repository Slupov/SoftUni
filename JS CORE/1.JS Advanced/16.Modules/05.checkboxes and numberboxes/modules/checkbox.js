class Checkbox {
    constructor (label, selector) {
        this._label = label;
        this._elements = $(selector);
        this.value = this._elements.is(':checked');

        this._elements.on('change', (ev) => {
            this.value = $(ev.target).prop('checked');
        });
    }

    get label () {
        return this._label;
    }

    get elements () {
        return this._elements;
    }

    get value () {
        return this._value;
    }

    set value (val) {
        if (typeof val !== 'boolean') {
            throw new Error('Not Boolean');
        }

        this._value = val;
        this.elements.prop('checked', val);
    }
}

module.exports.Checkbox = Checkbox;
