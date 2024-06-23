import {test} from "./add";

var form;

window.onload = function () {
    let btn = document.getElementById("btn")
    btn.addEventListener("click", () => auth())
}
// document.addEventListener("DOMContentLoaded", function() {
//     f();
// });
//
//
// function f() {
//     form = document.getElementById("form");
//     form.addEventListener("submit", function(event) {
//         event.preventDefault();
//         // alert("СТОП!");
//         // this.submit();
//         //
//         // const formData = new FormData(this);
//         // let passw = formData.get("passw");
//         // // console.log(passw.match(/\d/))
//         // if (passw.match(/\d/) !== null) {
//         //     this.submit();
//         // } else {
//         //     alert("В пароле должны присутствовать цифры")
//         // }
//     });
// }
function auth() {
    const formData = new FormData(form);
    let pass = formData.get('pass');
    if (pass.match(/\d/) !== null) {
        alert('bye world')
        form.submit();
    } else {
        alert('hello world')
        test()
    }
}