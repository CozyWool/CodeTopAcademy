function sum(arr: number[]): number {
    let result = 0;
    arr.forEach(num => result += num);
    return result;
}

function max(arr: number[]): number {
    return arrUnique(arr)
        .reduce((maxNum, num) => {
            if (maxNum < num) {
                maxNum = num;
            }
            return maxNum;
        }, arr[0]);
}

function min(arr: number[]): number {
    return arrUnique(arr)
        .reduce((minNum, num) => {
            if (minNum > num) {
                minNum = num;
            }
            return minNum;
        }, arr[0]);
}

function arrUnique(arr: number[]): number[] {
    return [...new Set(arr)]
}

export {sum};
export {min, max};

export default arrUnique;
