class Textbox {
    constructor(selector, regex) {
        this._selector = selector;
        this._elements = $(selector);
        this.value = $(this._elements[0]).val();
        this._invalidSymbols = new RegExp(regex);

        $(this._selector).on('input', (event) => {
            let newValue = $(event.target).val();
            //this is the Textbox object
            this.value = newValue;
            $(this._elements).each((index, element) => {
                $(element).val(newValue);
            });
        });

        $(this._elements).first().val(this.value);

    }

    get elements() {
        return this._elements;
    }

    isValid() {
        if (this._invalidSymbols.test(this.value)) {
            return false;
        }
        return true;
    }

    get value() {
        return this._value
    };

    set value(newValue) {
        $(this._selector).each((index, element) => {
            $(element).val(newValue);
        });
        this._value = newValue;
    };
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
let inputs = $('.textbox');

inputs.on('input', function () {
    //console.log(textbox.value);
});