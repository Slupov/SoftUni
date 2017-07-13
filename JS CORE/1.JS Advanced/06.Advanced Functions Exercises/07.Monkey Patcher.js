function solve(input) {
    //cycle input
    switch (input){
        case "upvote":
            this.upvotes += 1;
            break;
        case "downvote":
            this.downvotes -= 1;
            break;
        case "score":
            return score(this);
        break;
    }

    function score(obj) {
        let modifier = 0;

        if (obj.upvotes + obj.downvotes > 50) {
            modifier = Math.ceil(Math.max(obj.upvotes, obj.downvotes) * 0.25)
        }
        let score = obj.upvotes - obj.downvotes;
        let rating = "";
        if(obj.upvotes + obj.downvotes >= 10){
            if(score < 0){
                rating = 'unpopular';
            }
            else if(obj.upvotes/ (obj.upvotes + obj.downvotes) > 0.66){
                rating = 'positive';
            }
            else if(obj.upvotes > 100 && obj.downvotes > 100 ){
                rating = 'controversial';
            }
            else{
                rating = "new";
            }
        }
        else{
            rating = "new";
        }

        return [obj.upvotes + modifier,
            obj.downvotes + modifier,
            obj.upvotes-obj.downvotes,
            rating];
    }
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

// solve.call(post,"upvote");
console.log(solve.call(post,"score"));
// console.log(post);