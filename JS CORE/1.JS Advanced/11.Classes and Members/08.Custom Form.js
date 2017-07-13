(function () {

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

    class Form {
        constructor () {
            this._element = $('<div class="form"></div>');
            for (let index in arguments) {
                if (arguments[index].constructor.name !== 'Textbox') {
                    throw new Error('Error');
                }
            }

            this._textboxes = [];
            for (let index in arguments) {
                this._element.append($(arguments[index]._elements));
                this._textboxes.push(arguments[index]);
            }
        }

        submit () {
            let areAllValid = true;
            for (let index in this._textboxes) {
                if (this._textboxes[index].isValid()) {
                    $(this._textboxes[index].elements).css('border', '2px solid green');
                } else {
                    $(this._textboxes[index].elements).css('border', '2px solid red');
                    areAllValid = false;
                }
            }

            return areAllValid;
        }

        attach (selector) {
            $(selector).prepend(this._element);
        }
    }

    return {
        Textbox: Textbox,
        Form: Form
    }
})();