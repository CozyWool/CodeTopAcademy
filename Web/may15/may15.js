function clearArray(arr) {
    var arr = [1, 2, 3, 4];
    arr[7] = 5;
    arr = arr.filter(x => x !== undefined);
}

var arr = [1, 2, 3, 4];
arr[7] = 5;

console.log(`Array1: ${arr}`);