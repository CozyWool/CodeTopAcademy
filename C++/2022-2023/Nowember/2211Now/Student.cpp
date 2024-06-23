#include "Student.h"

void Student::setName(const char* name) 
{
    strcpy_s(this->name,name);
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
    cout << "Имя:" << name << endl;
    cout << "Оценки:";
    for (int i = 0; i < markCount; i++)
    {
        cout << marks[i] << setw(4);
    }
    cout << endl;
}

void Student::printAver()
{
    cout << "Средняя оценка "<< name << ": " << getAverMark() << endl;
}
