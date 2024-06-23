function isPrime(x) {
    for (let i = 2; i <= (x ** 0.5) + 1; i++) {
        if (x % i === 0) {
            return false;
        }
    }
    return true;
}

function module(x, y) {
    return x - Math.floor(x / y) * y;
}

function allEvenOrOddNumbers(start, end, isEvenRequested){
    for (let i = start; i <= end; i++) {
        if (i % 2 == !isEvenRequested) {
            console.log(i);
        }
    }
}

console.log(isPrime(69));
console.log(module(17,4));
allEvenOrOddNumbers(2,12,true)