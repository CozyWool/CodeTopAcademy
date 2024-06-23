#define _CRT_SECURE_NO_WARNINGS

#include "Student.h"

void Student::setName(const char* name)
{
    strcpy(this->name, name);
}

char* Student::getName()
{
    return name;
}

double Student::getAverMark()
{
    double sum = 0;
    for (int i = 0; i < markCount; i++)
    {
        sum += marks[i];
    }
    return sum / markCount;
}

void Student::setMark(int mark, int index)
{
    if (mark < 2 || mark > 5)
    {
        marks[index] = 0;
        return;
    }
    marks[index] = mark;
}

int* Student::getMarks()
{
    return marks;
}

int Student::getMark(int index)
{
    return marks[index];
}

void Student::print()
{
    cout << "���:" << name << endl;
    cout << "������:";
    for (int i = 0; i < markCount; i++)
    {
        cout << marks[i] << setw(4);
    }
    cout << endl;
}

void Student::printAver()
{
    cout << "������� ������ " << name << ": " << getAverMark() << endl;
}
