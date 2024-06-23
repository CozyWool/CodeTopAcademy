
#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include "Student.h"

Student studentFactory(const char* name, int* marks, int groupNumber)
{
    Student std{ name,marks,groupNumber };
    return std;
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Student std{ "Петров П.П",new int[5] {3,4,2,5,4}, 2 };
    Student std1{ studentFactory("Иванов И.И",new int[5] {5,4,3,5,4},1) };
    cout << std << endl;
    std.printAver();
    cout << std1 << endl;
    std1.printAver();
}
