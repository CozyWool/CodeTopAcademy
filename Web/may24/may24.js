window.onload = function () {
    console.log("Loaded");

    // let p1 = new Point(5, 10);
    // p1.x = 100;
    // p1.print();
    // console.log(p1);

    let btnAdd = document.getElementById("btnAdd");
    btnAdd.onclick = function () {
        let arr = [
            new Product("Phone", 24000, false),
            new Product("TV", 18000, true),
            new Computer("Notebook", 100000, true, "Laptop")
        ]
        let str = "<ul id='u1'>";
        for (let i = 0; i < arr.length; i++) {
            str += "<li>" + arr[i].getProduct() + "</li>";
        }
        // let block = document.getElementById("block");
        // block.innerHTML += str;
        let unorderedList = document.getElementById("u1");
        
    }
}

class Point {
    #x = 0
    #y = 0

    constructor(x, y) {
        this.#x = x;
        this.#y = y;
    }

    set x(x) {
        this.#x = x;
    }

    set y(y) {
        this.#y = y;
    }

    get x() {
        return this.#x;
    }

    get y() {
        return this.#y;
    }

    print() {
        console.log(`(${this.#x}; ${this.#y})`)
    }
}

class Product {
    #price = 0
    #name = "";
    #sale = false

    constructor(name, price, sale) {
        this.#name = name;
        this.#price = price;
        this.#sale = sale;
    }

    set name(name) {
        this.#name = name;
    }

    get name() {
        return this.#name;
    }

    set price(price) {
        this.#price = price;
    }

    get price() {
        return this.#price;
    }

    get sale() {
        return this.#sale;
    }

    set sale(sale) {
        this.#sale = sale;
    }


    getProduct() {
        return `${this.#name} ${this.#price} (${this.#sale ? "Скидка есть" : "Скидки нет"})`;
    }
}

class Computer extends Product {
    #type = "PC"

    constructor(name, price, sale, type) {
        super(name, price, sale);
        this.#type = type;
    }

    getProduct() {
        return `${this.name} ${this.price} (${this.sale ? "Скидка есть" : "Скидки нет"}) - ${this.#type}`;
    }
    
    enable(){
        console.log(`${this.#type} enabled`)
    }
    disable(){
        console.log(`${this.#type} disabled`)
    }
    
}