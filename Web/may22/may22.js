// let date = new Date(2023, 1, 29)
//
// console.log(date)
// date.setDate(date.getDate() + 1)
// console.log(date)
//
// console.log("Date: " + date.getDate())
// console.log("Day: " + date.getDay())
// console.log("Month: " + date.getMonth())
// console.log("FullYear " + date.getFullYear())
// console.log("Time: " + date.getTime())
//
// let group1 = ["Ivanov", "Petrov", "Sidorov", "Baranov"];
// let group2 = ['Zhuravlev', 'Spiridonov', 'Negodin'];
// let students = group1.splice(2, 2);
// group2 = group2.concat(students);
// console.clear()
// console.log("Students: " + students)
// console.log("Group 1: " + group1)
// console.log("Group 2: " + group2)
//
// let ivanov = {
//     firstName: "Ivan",
//     lastName: "Ivanov",
//     birthDate: '22.05.2024',
//     showInfo: function () {
//         console.log(`Name: ${this.firstName}, LastName: ${this.lastName}`);
//     }
// }
// console.log(ivanov);
//
// function Student(firstName, lastName, birthDay) {
//     this.firstName = firstName;
//     this.lastName = lastName;
//     this.birthDay = birthDay
//     this.showInfo = function () {
//         console.log(`Name: ${this.firstName}, LastName: ${this.lastName}`);
//     }
// }
//
// let sidorov = new Student("Petr", "Sidorov", "2012-02-21");
// sidorov.showInfo()

class Person{
    firstName = "";
    lastName = "";
    birthDay = "";
    constructor(firstName, lastName, birthDay){
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDay = birthDay;
    }
    
    showInfo(){
        console.log(this.firstName, this.lastName, this.birthDay);
    }
}

const p = new Person("User", "Name", "15-03-2024");
p.showInfo()