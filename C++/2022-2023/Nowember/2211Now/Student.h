#pragma once
#include <iostream>
#include <iomanip>

using namespace std;

const int maxNameLength = 20; 
const int markCount = 3;

class Student
{
private:
    char name[maxNameLength]; // ФИО
    int* marks = new int[markCount];//[markCount]; // Оценки
    int* m;
public:
    Student()
    {

    }

    Student(const char* name, const int* marks, int* m)
    {
        setName(name);
        for (int i = 0; i < markCount; i++)
        {
            setMark(marks[i], i);
        }
        this->m = m;
    }

    ~Student()
    {
        /*if (name != nullptr)
        {
            delete[] name;
        }*/
        if (marks != nullptr)
        {
            cout << "Требуется освободить marks" << endl;
            delete[] marks;
        }
        if (m != nullptr)
        {
            cout << "Требуется освободить m" << endl;
            delete[] m;
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

