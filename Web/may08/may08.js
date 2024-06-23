let x = prompt("What is your name?");
console.log(x);
function incAndLog(x) {
    x++
    Log.innerHTML += `<br> increment x = ${x}`;
}

let x = 2;
Log.innerHTML += `x = ${x}`;
incAndLog(x);
Log.innerHTML += `<br>x = ${x}`;