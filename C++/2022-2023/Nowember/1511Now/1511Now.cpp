#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>
#include <string.h>
#include <conio.h>
#include <stdlib.h>
#include <iomanip>

using namespace std;

const int maxNameLength = 20;
const int markCount = 3;

class Student
{
private:
    char name[maxNameLength];
    int marks[markCount];
public:
    Student(const char* name, const int* marks)
    {
        strncpy(this->name, name, maxNameLength);
        for (int i = 0; i < markCount; i++)
        {
            this->marks[i] = marks[i];
        }
    }
    double getAverMark()
    {
        double sum = 0;
        for (int i = 0; i < markCount; i++)
        {
            sum += marks[i];
        }
        return sum / markCount;
    }
    void print()
    {
        cout << "Имя:" << name << endl;
        cout << "Оценки:";
        for (int i = 0; i < markCount; i++)
        {
            cout << marks[i] << setw(4);
        }
        cout << endl;
    }
    void printAver()
    {
        cout << "Средняя оценка:" << getAverMark();
    }
};

//struct Student
//{
//    char name[maxNameLength];
//    int marks[markCount];
//};

//void initStudent(Student& student, const char* name, const int marks[])
//{
//    strncpy(student.name, name, maxNameLength);
//    for (int i = 0; i < markCount; i++)
//    {
//        student.marks[i] = marks[i];
//    }
//}
//
//double averMark(Student& student)
//{
//    double sum = 0;
//    for (int i = 0; i < markCount; i++)
//    {
//        sum += student.marks[i];
//    }
//    return sum / markCount;
//}
//
//void printStudent(Student& student)
//{
//    cout << "Имя:" << student.name << endl;
//    cout << "Оценки:";
//    for (int i = 0; i < markCount; i++)
//    {
//        cout << student.marks[i] << setw(4);
//    }
//    cout << endl;
//}
int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    cout << "Успеваемость студента\n\n";
    
    Student student("Иванов И.И", new int[3] {5, 4, 3});

    student.print();
    student.printAver();
    /*const char* studentName{"Иванов И.И"};
    int studentMarks[]{ 5,4,3 };

  
    student.print
    cout << "Средняя оценка:" << averMark(student);*/
}