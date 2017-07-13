function* solve (inputArrr) {
    for (let i = inputArrr.length - 1; i >= 0; i--) {
        yield inputArrr[i];
    }
}
