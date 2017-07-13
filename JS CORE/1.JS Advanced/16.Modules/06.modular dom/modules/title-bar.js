let BaseElement = require('./base-element.js').BaseElement;

class TitleBar extends BaseElement {
    constructor (title) {
        super();
        this.title = title;
        this.links = [];
    }

    addLink (href, name) {
        let newLink = `<a class="menu-link" href="${href}">${name}</a>`;
        this.links.push(newLink);
    }

    getElementString() {
        return `<header class="header">
                    <div><span class="title">${this.title}</span></div>
                    <div>
                        <nav class="menu">
                            ${this.links.join('|')}
                        </nav>
                    </div>
                </header>`;
    }
}

module.exports.TitleBar = TitleBar;
