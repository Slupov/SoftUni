// function solve() {

class Post {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }

    toString() {
        return `Post: ${this.title}\nContent: ${this.content}`;
    }
}

class SocialMediaPost extends Post {
    constructor(title, content, likes, dislikes) {
        super(title, content);
        this.likes = likes;
        this.dislikes = dislikes;
        this.comments = [];
    }

    addComment(comment) {
        this.comments.push(comment);
    }

    //the mistake is here
    toString() {
        let result = super.toString() + `\nRating: ${this.likes - this.dislikes}`;

        if (this.comments.length > 0) {
            let commentsText = this.comments;
            return result + `\nComments:\n * ${commentsText.join('\n * ')}`;
        }
        return result;
    }
}

class BlogPost extends Post {
    constructor(title, content, views) {
        super(title, content);
        this.views = views;
    }

    view() {
        this.views++;
        return this;
    }

    toString() {
        return super.toString() + `\nViews: ${this.views}`;
    }
}

//     return {Post, SocialMediaPost, BlogPost};
// }


// let wtf = solve().Post("Post","Content");

let post = new Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

console.log();
let blogPost = new BlogPost("BlogTitle", "Blog test content", 5);
blogPost.view();
console.log(blogPost.toString());



// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
