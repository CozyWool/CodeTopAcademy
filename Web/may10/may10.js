function factorial(n) {
    if (n === 1)
        return 1;
    return n * factorial(n - 1);
}

function range(start, end) {
    if (start > end)
        return '';
    return start.toString() + ' ' + range(start + 1, end);
}

function reverseRange(start, end) {
    if (start > end)
        return '';
    return end.toString() + ' ' + reverseRange(start, end - 1);
}

function reverseNumber(n) {
    if (n / 10 < 1)
        return n;
    return (n % 10).toString() + reverseNumber(parseInt(n / 10));
}

function sumDigits(n) {
    if (n / 10 < 1)
        return n;
    return n % 10 + sumDigits(parseInt(n / 10));
}

function roundBrackets(n) {
    if (n === 1)
        return '()';
    return '(' + roundBrackets(n - 1) + ')';
}

console.log("Factorial: " + factorial(5));
console.log("Range: " + range(1, 10));
console.log("Reverse Range: " + reverseRange(1, 10));

console.log("Reverse Number: " + reverseNumber(123456789));
console.log("Number's digits sum:" + sumDigits(1307));
console.log("Round brackets: " + roundBrackets(5))

