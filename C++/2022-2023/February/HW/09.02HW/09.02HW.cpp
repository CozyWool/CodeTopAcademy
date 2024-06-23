#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <string>
#include <cassert>


using namespace std;

enum SubjectType
{
    MATH,
    RUSSIAN,
    IT
};

class StudentRow
{
private:
    string surname;
    int marks[3];
public:
    StudentRow(string surnameP, const int* marksP) : surname{ surnameP }
    {
        for (int i = 0; i < 3; i++)
        {
            marks[i] = marksP ? marksP[i] : 0;
        }
    }
    StudentRow() : StudentRow{ "",nullptr } {}

    int calcMarks() const
    {
        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += marks[i];
        }
        return sum;
    }

    string getSurname() const { return surname; }

    StudentRow& setSurname(string surnameP)
    {
        surname = surnameP;
        return *this;
    }

    friend ostream& operator<<(ostream& out, const StudentRow& s)
    {
        out << "\"" << s.surname << "\"\t";
        for (int i = 0; i < 3; i++)
        {
            out << s.marks[i] << "\t\t";
        }
        return out;
    }
    int& operator[](int idx)
    {
        assert(idx >= 0 && idx < 3 && "Индекс вышел за пределы!");
        return marks[idx];
    }
    int operator[](int idx) const
    {
        assert(idx >= 0 && idx < 3 && "Индекс вышел за пределы!");
        return marks[idx];
    }
};

class StudentsTable
{
public:
    static const int maxSize = 10;
private:
    StudentRow studentRows[StudentsTable::maxSize];
    int size;
    int threshold; // Порог для поступления

    int findStudent(string surname) const
    {
        for (int i = 0; i < size; i++)
        {
            if (surname == studentRows[i].getSurname())
                return i;
        }
        return -1;
    }
public:
    StudentsTable(int size, StudentRow* studentRows, int threshold) : size{ size }, threshold{ threshold }
    {
        if (studentRows)
        {
            for (int i = 0; i < size; i++)
            {
                this->studentRows[i] = studentRows[i];
            }
        }
    }
    StudentsTable() : StudentsTable{ 0,nullptr,0 } {}

    bool checkStudent(int idx) const
    {
        assert(idx >= 0 && idx < size && "Индекс вышел за пределы!");

        return studentRows[idx].calcMarks() >= threshold;
    }
    StudentsTable& sortBySurname()
    {
        //Сортировка пузырьком
        for (int i = 0; i < size; i++)
        {
        	for (int j = 0; j < size - i - 1; j++)
        	{   
        		if (studentRows[j].getSurname() > studentRows[j + 1].getSurname())
        		{
                    StudentRow temp{ studentRows[j] };
                    studentRows[j] = studentRows[j + 1];
                    studentRows[j + 1] = temp;
        		}
        	}
        }
        return *this;
    }

    void printSelection(int count)
    {
        assert("Количество выборки вышло за пределы максимальных размеров" && (count >= 0 && count <= maxSize));
        cout << "Фамилия\t\tМатематика\tРусский язык\tИнформатика\tРезультат поступления" << endl;
        for (int i = 0; i < count; i++)
        {
           cout << studentRows[i] << (checkStudent(i) ? "Посутпил" : "Не поступил") << endl;
        }
    }

    StudentRow& operator[](string surname)
    {
        int idx = findStudent(surname);

        if (idx == -1)
        {
            assert(size < StudentsTable::maxSize && "Таблица заполнена!");
            idx = size++;
            studentRows[idx].setSurname(surname);
        }

        return studentRows[idx];
    }
    StudentRow operator[](string surname) const
    {
        int idx = findStudent(surname);

        assert("В константной таблице нет такого студента!" && idx != -1);

        return studentRows[idx];
    }

    friend ostream& operator<<(ostream& out, const StudentsTable& m)
    {
        out << "Фамилия\t\tМатематика\tРусский язык\tИнформатика\tРезультат поступления" << endl;
        for (int i = 0; i < m.size; i++)
        {
            out << m.studentRows[i] << (m.checkStudent(i) ? "Посутпил" : "Не поступил") << endl;
        }
        return out;
    }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    StudentRow sidorov{ "Сидоров",new int[3] {50,70,100} }; // В сумме 220 баллов
    StudentRow petrov{ "Петров",new int[3] {60,70,80} }; // В сумме 210 баллов
    StudentRow ivanov{ "Иванов",new int[3] {80,50,70} }; // В сумме 200 баллов

    int size = 3;
    StudentRow* studentRows = new StudentRow[size]{ sidorov,petrov,ivanov };

    StudentsTable st1{ size,studentRows,220 };

    st1["Петров"][MATH] = 70;
    st1["Петров"][IT] = 70;

    cout << "\tStudents Table #1\n" << endl;
    cout << st1 << endl;

    st1.sortBySurname();

    cout << "\tStudents Table #1 после сортировки по фамилии\n" << endl;
    cout << st1 << endl;

    cout << "\tВыборка первых двух студентов из Students Table #1\n" << endl;
    st1.printSelection(2);
}