//80/100
function radicalMarketing(input) {
    let people = new Set();
    let personWithSubscribers = new Map();
    //person with how many subsciptions he has
    let personSubscribedTo = new Map();

    for (let line of input) {
        //if the line registers a new person
        if (line.length == 1) {
            people.add(line[0]);
            if (people.has(line[0])) {
                continue;
            }
        }
        //if the line is subscription
        else {
            line = line.split("-");
            let subscriber = line[0];
            let person = line[1];

            if (subscriber == person) {
                continue;
            }
            if (!people.has(subscriber) || !people.has(person)) {
                continue;
            }

            //subscriber with subscribers
            //if there is no such subscriber
            if (!personSubscribedTo.has(subscriber)) {
                //set a new set of subscriptions
                personSubscribedTo.set(subscriber, new Set());
                personSubscribedTo.get(subscriber).add(person);
            }
            //if there is such subscriber with subscriptions
            else {
                personSubscribedTo.get(subscriber).add(person);
            }
            //if there is no such person
            if (!personWithSubscribers.has(person)) {
                //set a new set of his subscribers
                personWithSubscribers.set(person, new Set());
                personWithSubscribers.get(person).add(subscriber);
            }
            //if there is such person with subscribers
            else {
                personWithSubscribers.get(person).add(subscriber);
            }
        }
    }
    //We've already populated correctly
    //the maps person -> subscribers
    //and      subscriber -> subcriptions
    personWithSubscribers = Array.from(personWithSubscribers.entries());
    console.log(personWithSubscribers);
    console.log(personSubscribedTo);

    let mostImportantPerson = {name: "A", subs: new Set()};
    let mostSubscribers = 0;

    //loop through all entries
    for (let [key,value] of personWithSubscribers) {
        if (value.size > mostSubscribers) {
            mostImportantPerson.name = key;
            mostImportantPerson.subs = value;
            mostSubscribers = value.size;
        }
        //if theres already someone with so many subscriptions
        else if (value.size == mostImportantPerson.subs.size) {
            //check how many subscriptions does he have
            let currentSubscriptions = personSubscribedTo.get(key).size;
            let mostImportantPersonSubscriptions = personSubscribedTo.get(mostImportantPerson.name).size;
            //now sort them by subscription count
            if (currentSubscriptions > mostImportantPersonSubscriptions) {
                mostImportantPerson.name = key;
                mostImportantPerson.subs = value;
            }
        }
    }
    console.log(mostImportantPerson.name);
    let mostImportantPersonSubs = Array.from(mostImportantPerson.subs);

    for (let i = 0; i < mostImportantPersonSubs.length; i++) {
        console.log(`${i + 1}. ${mostImportantPersonSubs[i]}`);
    }
}

let test = [
    'A',
    'B',
    'C',
    'D',
    'A-B',
    'B-A',
    'C-A',
    'D-A',

];

radicalMarketing(test);