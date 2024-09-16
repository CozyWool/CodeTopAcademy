let list: number[] = [10, 20, 30];
let colors: string[] = ["red", "green", "blue"];
console.log(list);
console.log(colors);

// let arr: (string | number | boolean)[] = [1, "str", true]
let arr: Function;
arr = () => {
    console.log(list);
}
arr();

let names: Array<string | number> = ["Tom", "Bob", "Alice", 1];
console.log(names);