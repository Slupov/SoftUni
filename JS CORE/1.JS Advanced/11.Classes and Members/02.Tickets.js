function solve(input) {
    let tickets = [];
    let sortingCriteria = arguments[1];

    class Ticket{
        constructor(destination,price,status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }

        compareTo(other,criteria){
            if(this[criteria] > other[criteria]){
                return 1;
            }
            else if(this[criteria] < other[criteria]){
                return -1
            }
            return 0;
        }
    }

    for (let t of input) {
        let tokens = t.split("|");
        let ticket = new Ticket(tokens[0],Number(tokens[1]),tokens[2]);
        tickets.push(ticket);
    }

    tickets.sort( (a,b) => a.compareTo(b,sortingCriteria));
    
    return tickets;
}

console.log(solve(
    [
        'Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'
    ],
        'destination'
));