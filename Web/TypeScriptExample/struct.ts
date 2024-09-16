type Student = {
    firstName: string,
    lastName: string,
    age: number,
}

let students: Student[] =
    [
        {
            firstName: "Petr",
            lastName: "Petrov",
            age: 24
        },
        {
            firstName: "Ivan",
            lastName: "Ivanov",
            age: 17
        },
        {
            firstName: "Maksim",
            lastName: "Maksimov",
            age: 20
        }
    ]

let count: number = 0;
for (const student of students) {
    console.log(`Студент: ${student.firstName} ${student.lastName} - ${student.age}`);
    if (student.age >= 18) {
        count++;
    }
}
console.log(`Совершеннолетних студентов: ${count}`)

let a;
console.log(a)
