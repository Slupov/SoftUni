function negativePositiveNums(arr) {
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] < 0) {
            arr.unshift(arr[i]);
            arr.splice(i + 1, 1);
        }
    }
    console.log(arr.join(" "));
}