let Article = require('./article.js').Article;

class TableArticle extends Article {
    constructor (title, content, headings = null, data = null) {
        super(title, content);
        this.headings = headings;
        this.data = data;
    }

    loadData (headings, data) {
        this.headings = headings;
        this.data = data;
    }

    getElementString () {
        let tableHtml = '<table class="data"><tr>';
        for (let heading of this.headings) {
            tableHtml += `<th>${heading}</th>`;
        }
        tableHtml += '</tr>';

        let dataKeys = this.headings.map(x => x.replace(' ', '').toLowerCase());
        
        for (let dataItem of this.data) {
            tableHtml += '<tr>';
            for (let key of dataKeys) {
                tableHtml += `<td>${dataItem[key]}</td>`;
            }
            tableHtml += '</tr>';
        }

        return `<div class="article">
                    <div class="article-title">${this.title}</div>
                    <p>${this.content}</p>
                    <div class="table">
                        ${tableHtml}
                    </div>
                </div>`;
    }
}

module.exports.TableArticle = TableArticle;
