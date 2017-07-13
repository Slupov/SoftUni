function sort(arr, sortType) {
    let ascendingSort = (a,b) => a-b;
    let descendingSort = (a,b) => b-a;

    let sortingAlgorithms = {
        asc: ascendingSort,
        desc: descendingSort
    };

    return arr.sort(sortingAlgorithms[sortType]);
}