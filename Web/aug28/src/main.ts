import {el, setChildren} from "redom";
import "./style.css";
import logo from "./img/logo.svg";

let x: number = 5;

const header = el('header');
const icon = el('a');
const button = el('button', 'Войти');
const h1 = el('h1', 'Заголовок проекта')

header.classList.add('header');
icon.href = '/'
h1.classList.add('h1');
button.classList.add('button');
setChildren(icon,  [el('img', {src: logo})]);
setChildren(header, [icon, h1, button]);
document.addEventListener('DOMContentLoaded', () =>{
    setChildren(document.body, [header]);
})