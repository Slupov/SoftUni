function tripLength(input) {
    let points = {};
    for (let i = 0, o = 1; i < input.length; i += 2, o++) {
        points[o] = {X: input[i], Y: input[i + 1]};
    }
    let distances = {};
    for (let i in points) {
        let temp = Number(i) + 1;
        for (let j in points) {
            if (distances.hasOwnProperty(j + '-' + i)) {
                continue;
            }
            if (j != i) {
                distances[i + '-' + j] = calcDistance(points[i].X, points[i].Y, points[j].X, points[j].Y);
            }
        }
    }
    let max = Object.keys(distances).reduce(function (m, k) {
        return distances[k] > m ? distances[k] : m;

    }, -Infinity);
    if (max == distances['1-3']) {
        console.log(`1->2->3: ${distances['1-2'] + distances['2-3']}`);
    }
    else if (max == distances['1-2']) {
        console.log(`1->3->2: ${distances['1-3'] + distances['2-3']}`);
    }
    else console.log(`2->1->3: ${distances['1-2'] + distances['1-3']}`);


    function calcDistance(x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
    }
}