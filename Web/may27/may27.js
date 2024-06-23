// window.onload = function () {
//     // document.getElementById("block").onclick = function () {
//     //     alert("New Event")
//     // }
//
//     // document.getElementById("block2").addEventListener("click", (e) => {
//     //     alert("New event 3");
//     //     console.log(e);
//     //})
//     document.getElementById("block2").addEventListener("mousemove", (e) => {
//         e.target.style.backgroundColor = "red"
//     })
//     document.getElementById("block2").addEventListener("mouseleave", (e) => {
//         e.target.style.backgroundColor = "green"
//     })
//     document.getElementById("block").addEventListener("click", (e) => {
//         let d1 = e.target;
//
//         d1.style.backgroundColor = "rgba(" +
//             Math.round(Math.random() * 255) + "," +
//             Math.round(Math.random() * 255) + "," +
//             Math.round(Math.random() * 255) + "," +
//             ((Math.random()) * 0.5 + 0.5) + ")";
//     });
// }