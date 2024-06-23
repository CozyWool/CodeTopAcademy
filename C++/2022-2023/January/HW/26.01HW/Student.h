#pragma once

#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <iomanip>

using namespace std;

const int maxNameLength = 20;
const int markCount = 5;

class Student
{
private:
    char* name = new char[maxNameLength]; // ФИО
    int* marks = new int[markCount]; // Оценки
    int groupNumber;
public:

    Student(const char* name, int* marks, int groupNumber) : groupNumber{ groupNumber }
    {
        setName(name);
        for (int i = 0; i < markCount; i++)
        {
            this->marks[i] = marks[i];
        }
        cout << "Student constructor for " << this << endl;
    }
    Student() : Student{ "",nullptr,0 } {}
    Student(const Student& obj) : Student{ obj.name,obj.marks,obj.groupNumber }
    {
        cout << "Student copy constructor for " << this << endl;
    }
    Student(Student&& obj) noexcept : Student{ obj.name,obj.marks,obj.groupNumber }
    {
        obj.name = nullptr;
        obj.marks = nullptr;
        obj.groupNumber = 0;
        cout << "Student move constructor for " << this << endl;
    }

    void setName(const char* name) { strcpy(this->name, name); }
    void setGroupNumber(int groupNumber) { this->groupNumber = groupNumber; }
    void setMark(int mark, int index)
    {
        if (mark < 2 || mark > 5)
        {
            marks[index] = 0;
            return;
        }
        marks[index] = mark;
    }

    char* getName() { return name; }
    int getGroupNumber() { return groupNumber; }
    int* getMarks()
    {
        return marks;
    }
    int getMark(int index)
    {
        return marks[index];
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

    friend ostream& operator<<(ostream& out, const Student& std)
    {
        out << "Имя: " << std.name << endl;
        out << "Номер группы: " << std.groupNumber << endl;
        out << "Оценки: ";
        for (int i = 0; i < markCount; i++)
        {
            out << std.marks[i] << setw(4);
        }
        out << endl;
        return out;
    }

    void printAver()
    {
        cout << "Средняя оценка " << name << ": " << getAverMark() << endl;
    }

    ~Student()
    {
        if (name != nullptr)
        {
            delete[] name;
        }
        if (marks != nullptr)
        {
            delete[] marks;
        }
        cout << "Student destructor for " << this << endl;
    }
};

