#include <iostream>
#include <Windows.h>
#include <iomanip>
#include "Student.h"

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    const int SIZE = 2;
    double sum = 0;
    double aver;

    Student* students = new Student[SIZE]
    {
        { "Иванов И.И", new int[3] {5, 4, 3}, new int[3] {4, 3, 2} },
        { "Петров П.П", new int[3] {2, 3, 4}, new int[3] {4, 3, 2} }
    };

    cout << "Успеваемость студента\n\n";

    cout << students + SIZE << endl;

    for (Student* students_copy = students;  students_copy < students + SIZE;  students_copy++)
    {
        aver = students_copy->getAverMark();
        students_copy->printAver();
        sum += aver;
    }

    cout << endl;

    cout << "Средний балл по группе:" << sum / SIZE << endl;

    delete[] students;
    /*char* name;

    Student student("Иванов И.И", new int[3] {5, 4, 3}, new int[3] {4, 3, 2});

    student.setName("Петров П.П");

    name = student.getName();

    cout << name << endl;

    student.print();
    student.printAver();

    student.setMark(2,2);
    student.setMark(6,1);
    int* newMarks = new int[markCount];
    newMarks = student.getMarks();

    student.print();
    student.printAver();*/
}