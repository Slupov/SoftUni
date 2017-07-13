function validityChecker([x1,y1,x2,y2]) {
    function calcDistance(x, y, X, Y) {
        let distance = Math.sqrt(Math.pow((x - X), 2) + Math.pow((y - Y), 2));

        if (distance == Math.floor(distance)) {
            return "valid";
        }
        return "invalid"
    }

    console.log(`{${x1}, ${y1}} to {0, 0} is ${calcDistance(x1, y1, 0, 0)}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${calcDistance(x2, y2, 0, 0)}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${calcDistance(x1, y1, x2, y2)}`);

}