#pragma once
#include <iostream>
#include <iomanip>

using namespace std;

const int maxNameLength = 20;
const int markCount = 3;

class Student
{
private:
    char* name = new char[maxNameLength]; // ���
    int* marks = new int[markCount];//[markCount]; // ������
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
            cout << "��������� ���������� name" << endl;
            delete[] name;
        }
        if (marks != nullptr)
        {
            cout << "��������� ���������� marks" << endl;
            delete[] marks;
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

