class Post {
    constructor (title, body, author) {
        this.title = title;
        this.body = body;
        this.author = author;
    }

    addToSelector (selector) {
        let postDiv = $(`<div class="post ${this.author}"></div>`);
        let titleHeading = $(`<h3 class="title">${this.title}</h3>`);
        let bodyParagraph = $(`<p class="body">${this.body}</p>`);
        let authorParagraph = $(`<p class="author">${this.author}</p>`);

        postDiv.append(titleHeading)
            .append(bodyParagraph)
            .append(authorParagraph);

        $(selector).append(postDiv);
    }
}

module.exports.Post = Post;
