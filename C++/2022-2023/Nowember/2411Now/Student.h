#pragma once
#include <iostream>
#include <iomanip>

using namespace std;

const int maxNameLength = 20;
const int markCount = 3;

class Student
{
private:
    char* name = new char[maxNameLength]; // ФИО
    int* marks = new int[markCount];//[markCount]; // Оценки
public:
    Student()
    {

    }

    Student(const char* name, int* marks)
    {
        setName(name);
        this->marks = marks;
    }

    ~Student()
    {
        if (name != nullptr)
        {
            cout << "Требуется освободить name" << endl;
            delete[] name;
        }
        if (marks != nullptr)
        {
            cout << "Требуется освободить marks" << endl;
            delete[] marks;
        }

        cout << "Память освобождена...." << endl;
        system("pause");
    }
    // Установка name
    void setName(const char* name);
    // Получение name
    char* getName();
    // Установка mark
    void setMark(int mark, int index);
    // Получение marks
    int* getMarks();
    // Получение mark
    int getMark(int index);
    // Вычисление средней оценки
    double getAverMark();
    // Вывод данных о студенте
    void print();
    // Вывод средней оценки
    void printAver();
};

