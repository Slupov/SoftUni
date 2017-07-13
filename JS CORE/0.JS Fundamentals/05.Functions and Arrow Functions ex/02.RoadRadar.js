function roadRadar([speed, zone]) {

    function getLimit(zone) {
        switch (zone) {
            case 'motorway' :
                return 130;
            case 'interstate':
                return 90;
            case 'city':
                return 50;
            case 'residential':
                return 20;
        }
    }

    speed = Number(speed);
    let difference = speed - getLimit(zone);

    if (difference > 0) {
        if (difference > 40) {
            console.log("reckless driving");
        }
        if (difference > 20 && speed - getLimit(zone) <= 40) {
            console.log("excessive speeding");
        }
        if (difference > 0 && difference <= 20) {
            console.log("speeding");
        }
    }
}