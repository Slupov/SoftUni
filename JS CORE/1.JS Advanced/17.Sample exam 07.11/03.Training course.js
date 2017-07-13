class TrainingCourse {
    constructor(title, trainer) {
        this.title = title;
        this.trainer = trainer;
        this.topics = [];
    }

    addTopic(title, date) {
        let topic = {
            title: title,
            date: date
        };
        this.topics.push(topic);
        this.sortTopics();

        return this;
    }

    sortTopics() {
        if (this.topics.length > 0) {
            this.topics.sort(function (a, b) {
                if (a.date > b.date) return 1;
                else return -1;
            });
        }
    }

    get firstTopic() {
        if (this.topics.length > 0) {
            this.sortTopics();
            return this.topics[0];
        }
    }

    get lastTopic() {
        if (this.topics.length > 0) {
            this.sortTopics();
            return this.topics[this.topics.length - 1];
        }
    }

    toString() {
        let result = 'Course "' + this.title + '" by ' + this.trainer;

        if(this.topics.length === 0){
            return result + '\n';
        }

        for (let topic of this.topics) {
            result += `\n * ${topic.title} - ${topic.date}`;
        }
        return result;
    }
}

let js = new TrainingCourse("JS Intro", "Svetlin Nakov");
console.log("First topic: " + JSON.stringify(js.firstTopic));
console.log("Last topic: " + JSON.stringify(js.lastTopic));
console.log("" + js);

js.addTopic("Maps", new Date(2016, 9, 6, 18, 0));
js.addTopic("JS Overview", new Date(2016, 8, 27, 18, 0));
js.addTopic("Program Logic", new Date(2016, 8, 29, 18, 0));
js.addTopic("Arrays", new Date(2016, 9, 3, 18, 0));
console.log("First topic: " + JSON.stringify(js.firstTopic));
console.log("Last topic: " + JSON.stringify(js.lastTopic));
console.log("" + js);

console.log("-----------------------------------------------");

let php = new TrainingCourse("PHP Intro", "Ivan Yonkov")
    .addTopic("Strings", new Date(2017, 2, 16, 18, 0))
    .addTopic("PHP First Steps", new Date(2017, 2, 12, 18, 0))
    .addTopic("Arrays", new Date(2017, 2, 14, 18, 0));
console.log("" + php);

console.log("Last topic: " + JSON.stringify(php.firstTopic));

