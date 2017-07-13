class TitleBar {
    constructor(title) {
        this.title = title;
        this.menu = [];
        this.menuHTML  = {};
    }

    addLink(href, name) {
        this.menu.push($(`<a class="menu-link" href="${href}">${name}</a>`));
    }

    appendTo(selector) {
        $(selector).prepend(this.generate());
    }

    generate() {
        let newHtml = $(`<header class="header">
  <div class="header-row">
    <a class="button">&#9776;</a>
    <span class="title">${this.title}</span>
  </div>
  <div class="drawer">
    <nav class="menu">
    </nav>
  </div>
</header>
`);
        this.menuHTML = newHtml.find(".menu");
        for (let item of this.menu) {
            this.menuHTML.append(item);
        }

        //click eventite se puskat asinhronno i ima
        // wyzmojnost da se pusnat predi documenta da
        // e sysdaden
        let button = newHtml.find(".button");
        //the button will steal the context so we bind it
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
