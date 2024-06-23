#pragma once
#include <iostream>
#include <iomanip>

using namespace std;

const int maxNameLength = 20; 
const int markCount = 3;

class Student
{
private:
    char name[maxNameLength]; // ���
    int* marks = new int[markCount];//[markCount]; // ������
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
            cout << "��������� ���������� marks" << endl;
            delete[] marks;
        }
        if (m != nullptr)
        {
            cout << "��������� ���������� m" << endl;
            delete[] m;
        }

        cout << "������ �����������...." << endl;
        system("pause");
    }
    // ��������� name
    void setName(const char* name);
    // ��������� name
    char* getName();
    // ��������� mark
    void setMark(int mark, int index);
    // ��������� marks
    int* getMarks();
    // ��������� mark
    int getMark(int index);
    // ���������� ������� ������
    double getAverMark(); 
    // ����� ������ � ��������
    void print(); 
    // ����� ������� ������
    void printAver(); 
};

