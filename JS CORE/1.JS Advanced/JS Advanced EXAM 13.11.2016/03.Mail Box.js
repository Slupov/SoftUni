class MailBox {
    constructor() {
        this.mailBox = [];
    }

    addMessage(subject, text) {
        let message = {
            subject: subject,
            text: text
        };
        this.mailBox.push(message);
        return this;
    }

    get messageCount() {
        return this.mailBox.length;
    }

    deleteAllMessages() {
        this.mailBox = [];
    }

    findBySubject(substr){
        return this.mailBox.filter(x=>x.subject.indexOf(substr) >= 0);
    }

    toString(){
        if(this.mailBox.length == 0){
            return " * (empty mailbox)"
        }
        else if(this.mailBox.length > 0){
            let output = "";
            for (let message of this.mailBox) {
              output += ` * ${message.subject} ${message.text}\n`;
            }
            return output;
        }
    }
}