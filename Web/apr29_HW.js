alert("ДЗ за 29.04.24")
let isExitRequested = false


while (!isExitRequested) {
    let t = parseInt(prompt("Выберите задание 1 - 10 (0 - для выхода):"))
    switch (t) {
        case 1:
            firstTask()
            break;
        case 2:
            secondTask()
            break;
        case 3:
            thirdTask()
            break;
        case 4:
            fourthTask()
            break;
        case 5:
            fifthTask()
            break;
        case 6:
            sixthTask()
            break;
        case 7:
            seventhTask()
            break;
        case 8:
            eighthTask()
            break;
        case 9:
            ninthTask()
            break;
        case 10:
            tenthTask()
            break;
        case 0:
            isExitRequested = true;
            break;
    }
}

function firstTask() {
    let name = prompt("Введите ваше имя:");
    alert(`Привет, ${name}!`)
}

function secondTask() {
    const CURRENT_YEAR = 2024;
    let birthday_year = parseInt(prompt("Введите ваш год рождения:"))
    alert(`Вам ${CURRENT_YEAR - birthday_year} лет!`)
}

function thirdTask() {
    let a = parseFloat(prompt("Введите сторону квадрата:"))
    alert(`Периметр квадрата: ${4 * a}`)
}

function fourthTask() {
    const pi = 3.14
    let r = parseFloat(prompt("Введите радиус окружности"))
    alert(`Площадь окружности: ${(pi * r ** 2).toFixed(2)}`)
}

function fifthTask() {
    let distance = parseFloat(prompt("Введите расстояние между двумя городам в км:"))
    let time = parseFloat(prompt("Введите за сколько часов вы хотите добраться:"))
    alert(`Скорость, чтобы успеть вовремя: ${(distance / time).toFixed(2)} км/ч`)
}

function sixthTask() {
    const EURO = 0.93
    let dollars = prompt("Введите сумму для конвертации долларов в евро:")
    alert(`Результат конвертации в евро: ${dollars * EURO} евро`)
}

function seventhTask() {
    let flashSize = parseFloat(prompt("Введите размер флешки в Гб:"))
    alert(`В вашу флешку поместится ${Math.floor(flashSize * 1024 / 820)} файлов размером 820 Мб`)
}

function eighthTask() {
    let money = parseInt(prompt("Введите сумму денег в кошельке в рублях:"))
    let price = parseFloat(prompt("Введите цену одной шоколадки:"))
    let count = Math.floor(money / price)
    let change = (money - count * price).toFixed(2)
    alert(`Вы можете купить ${count} шоколадок, и у вас останется ${change} руб!`)
}

function ninthTask() {
    let number = parseInt(prompt("Введите трехзначное число:"))
    alert(`Число наоборот: ${(number % 10).toString() + Math.floor(number % 100 / 10).toString() + Math.floor(number / 100).toString()}`)
}

function tenthTask() {
    let number = parseInt(prompt("Введите целое число:"))
    alert(`Число - ${number % 2 === 0 ? "" : "не "}четное`)
}
