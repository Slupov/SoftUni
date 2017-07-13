function restaurantBill(input) {
    let list = [];
    let total = 0;
    for (let i = 0; i < input.length; i += 2) {
        list.push(input[i]);
        total += Number(input[i + 1]);
    }
    list = list.join(", ");
    console.log(`You purchased ${list} for a total sum of ${total}`);
}