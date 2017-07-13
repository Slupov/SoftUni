class TitleBar {
    constructor(title) {
        this.title = title;
        this.menu = [];
        this.menuHTML = {};
    }

    addLink(href, name) {
        this.menu.push($(`<a class="menu-link" href="${href}">${name}</a>`));
    }

    appendTo(selector) {
        $(selector).prepend(this.generate());
    }

    generate(){
        let newHtml = $("<header class='header'>")
            .append($("<div class='header-row'>")
                .append($('<a class="button">&#9776;</a>'))
                .append($(`<span class="title">${this.title}</span>`)))
            .append($('<div class="drawer">').append($('<nav class="menu">')));

        this.menuHTML = newHtml.find('.menu');

        for (let item of this.menu) {
            this.menuHTML.append(item);
        }

        let button = newHtml.find(".button");

        button.click(this.toggle.bind(this));

        return newHtml;
    }

    toggle(){
        let menu = this.menuHTML.parent();

        if(menu.css('display') == 'none') {
            menu.css('display', 'block');
        }
        else {
            menu.css('display', 'none');
        }
    }
}

let header = new TitleBar('Title Bar Problem');
header.addLink('/', 'Home');
header.addLink('about', 'About');
header.addLink('results', 'Results');
header.addLink('faq', 'FAQ');
header.appendTo('#container');
