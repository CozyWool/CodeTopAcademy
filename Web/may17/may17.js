function compareLength(str1, str2) {
    if (str1.length < str2.length) return -1;
    if (str1.length > str2.length) return 1;

    return 0;
}

function firstCharToUpper(str) {
    str = str[0].toUpperCase() + str.slice(1);
    return str;
}

function isSpam(str) {
    let spamWords = ["100% бесплатно", "увеличение продаж", "только сегодня", "не удаляйте", "xxx"];
    str = str.toLowerCase()
    for(let word of spamWords) {
        if (str.indexOf(word) !== -1){
            return true
        }
    }
    return false
}

console.log(compareLength("abc", "abcd"));
let str = "abc";
let spamStr = "Отдам машину 100% бесплатно только сегодня"
console.log(firstCharToUpper(str));
console.log(isSpam(spamStr));