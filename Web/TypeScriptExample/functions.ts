function add(x: string, y: string): string;
function add(x: number, y: number): number;
function add(x: any, y: any): any{
    return x + y;
}

let result1 = add(1, 2);
let result2 = add("1", "5");

console.log(result1)
console.log(result2)