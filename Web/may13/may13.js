// let obj = {};
// obj.Name = "My Name";
// obj.Age = 31;
// obj.Address = "My Address";
//
// delete obj.Age;
// console.log(obj);
//
// if ("Name" in obj) {
//     console.log(obj["Name"]);
// }else console.log("Нет такого свойства");


// let car = {
//     color: {
//         R: 234,
//         G: 22,
//         B: 12
//     },
//     name: "BMW"
// };
//
// console.log(car.color.R);


function getPoints(rect) {
    for (let point in rect) {
        console.log(`${point}: ${rect[point]}`);
    }
}

function getWidth(rect) {
    return Math.abs(rect.x - rect.endX);
}

function getHeight(rect) {
    return Math.abs(rect.y - rect.endY);
}

function getSquare(rect) {
    return getWidth(rect) * getHeight(rect);
}

function getPerimeter(rect) {
    return (getWidth(rect) + getHeight(rect)) * 2;
}

function changeWidth(rect, width) {
    rect.endX += width;
}

function isPointInRect(rect, point) {
    return rect.x <= point.x && point.x <= rect.endX && rect.y <= point.y && point.y <= rect.endY
}

let rect = {
    x: -20, y: -5, endX: -10, endY: 15
};
let point = {
    x: -10, y: 5
};

getPoints(rect)
console.log(`Ширина: ${getWidth(rect)} - Высота: ${getHeight(rect)}`);
console.log(`Площадь: ${getSquare(rect)} - Периметр: ${getPerimeter(rect)}`);
changeWidth(rect, 5)
console.log(`Увеличение ширины на 5: ${getWidth(rect)}`);
console.log(`Точка (${point.x};${point.y}) внутри прямоугольника? ${isPointInRect(rect, point)}`)


// var prop = "model";
//
// var car = {
//     color: "black",
//     speed: 240,
//     [prop]: "R8",
//     foo: function (){
//         console.log(prop);
//     }
// }
//
// console.log(Object.keys(car));
//
// for (const [key, value] of Object.entries(car)) {
//     console.log(`${key} - ${value}`);
// }
//
// Object.entries(car).forEach(([key, value]) => {
//     console.log(`${key} - ${value}`);
// })
//
// console.log(Object.keys(car));
// console.log(Object.getOwnPropertyNames(car));
