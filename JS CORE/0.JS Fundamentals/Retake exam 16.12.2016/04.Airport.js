function airport(input) {
    let atAirport = [];
    let towns = new Map();

    for (let flight of input) {
        let [planeID,town,passengersCount,action] = flight.split(" ");

        passengersCount = Number(passengersCount);

        let currentFlight = {
            planeID: planeID,
            town: town,
            passengersCount: passengersCount,
            action: action
        };

        //check validity
        if (!atAirport.includes(currentFlight.planeID) && currentFlight.action == "depart") {
            continue;
        }
        if (atAirport.includes(currentFlight.planeID) && currentFlight.action == "land") {
            continue;
        }

        //if ok -> add to flights and at airport
        if (currentFlight.action == "land") {
            atAirport.push(currentFlight.planeID);
        }
        else if (currentFlight.action == "depart") {
            let index = atAirport.indexOf(currentFlight.planeID);
            atAirport.splice(index, 1);
        }

        //save in towns
        if (!towns.has(town)) {
            let townInfo = {
                departures: 0,
                arrivals: 0,
                planes: new Set()
            };

            if (currentFlight.action == "land") {
                townInfo.arrivals += currentFlight.passengersCount;
            }
            else if (currentFlight.action == "depart") {
                townInfo.departures += currentFlight.passengersCount;
            }

            townInfo.planes.add(currentFlight.planeID);
            towns.set(town, townInfo)
        }
        else {
            if (currentFlight.action == "land") {
                towns.get(town).arrivals += currentFlight.passengersCount;
            }
            else if (currentFlight.action == "depart") {
                towns.get(town).departures += currentFlight.passengersCount;
            }

            towns.get(town).planes.add(currentFlight.planeID);
        }

    }

    //printing the result
    console.log("Planes left:");

    //sorting the data
    atAirport = atAirport.sort(function (a, b) {
        let aCap = a.toUpperCase();
        let bCap = b.toUpperCase();
        return (aCap < bCap) ? -1 : (aCap > bCap) ? 1 : 0;
    })

    // console.log(atAirport);
    // return;

    for (let plane of atAirport) {
        console.log("- " + plane);
    }

    //sort towns by arrivals (desc)
    let townToArrivals = [];

    for (let [key, value] of towns.entries()) {
        let currentTown = {
            name: key,
            arrivals: value.arrivals,
            departures: value.departures,
            planes: value.planes
        }
        townToArrivals.push(currentTown)
    }

    townToArrivals = townToArrivals.sort(function (a, b) {
        let aArrivals = a.arrivals;
        let bArrivals = b.arrivals;

        let aCap = a.name.toUpperCase();
        let bCap = b.name.toUpperCase();

        if (aArrivals == bArrivals) {
            return (aCap < bCap) ? -1 : 1;
        }
        else if (aArrivals > bArrivals) return -1;
        else if (aArrivals < bArrivals) return 1;
    });

    //print towns
    for (let town of townToArrivals) {
        console.log(town.name);
        console.log('Arrivals: ' + town.arrivals);
        console.log('Departures: ' + town.departures);
        console.log("Planes:");
        let planesForTown = [...town.planes];
        planesForTown = planesForTown.sort(function (a, b) {
            let aCap = a.toUpperCase();
            let bCap = b.toUpperCase();
            return aCap > bCap
        }).forEach(x => console.log("-- " + x));

        //console.log(planesForTown);
    }

}

airport([
    "Boeing474 Madrid 300 land",
    "AirForceOne WashingtonDC 178 land",
    "Airbus London 265 depart",
    "ATR72 WashingtonDC 272 land",
    "ATR72 Madrid 135 depart"
]);

// airport([
//     "Airbus Paris 356 land",
//     "Airbus London 321 land",
//     "Airbus Paris 213 depart",
//     "Airbus Ljubljana 250 land"
// ])