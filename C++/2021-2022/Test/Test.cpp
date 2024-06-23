#include <iostream>
#include "Student.h"
#include <Windows.h> // для русского языка в консоли
using namespace std;
/*
	Ответы на вопросы:
	1.Класс - это модель, по которой создаются объекты опредленной структуры
	2. Все файлы имеют расширение .cpp или .h(если это заголовок). Они взаимодействуют между собой с помощью #include
	3. При помощи библиотеки "iostream" и пространства имен "std"
	4. 1)Полиморфизм - свойство, позволяющее использовать одно и то же имя для определния разных функций
	   2)Наследование - процесс, с помощью которого один объект получает свойства другого
	   3)Инкапсуляция - это объединение в классе данных и методов с целью защиты данных
	5. Ниже в коде
*/
class Questions // Ответ на 5-ый вопрос
{

private:
	string smth;
public:
	Questions()
	{

	}
	Questions(string smth)
	{
		this->smth = smth;
	}
};
void searchBadGrade(Student* students,int size) // поиск двоек
{
	int counter = 0; // счётчик двоек
	for (int i = 0; i < size; i++)
	{
		if (students[i].getGrade() == 2)
		{
			counter++;
		}
	}
	cout << "Общее кол-во двоек:" << counter << endl;
}
int main()
{
	// Ответ на 5-ый вопрос(продолжение)
	Questions q;
	Questions q2("Something");
	// Конец 5-ого вопроса
	// для русского языка в консоли
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251); 
	// создаем массив студентов
	int size = 4;
	Student* students = new Student[size];
	string subjects[5]{"Математика","Физика","География","Геометрия","Биология"};
	// заполняем массив студентов
	for (int i = 0; i < size; i++)
	{
		string surname = "";
		string subject = "";
		int grade = 0;
		// Ввод и проверка фамилии
		cout << "Введите фамилию студента под номером " << i + 1 << ":";
		cin >> surname;
		while (surname.size() < 3)
		{
			cout << "Фамилия слишком короткая, введите корректную фамилию:";
			cin >> surname;
		}
		//Ввод и проверка предмета
		cout << "Введите предмет студента под номером " << i + 1<< ":";
		cin >> subject;
		bool foundSubject = false;
		for (auto s : subjects)
		{
			if (subject == s)
			{
				foundSubject = true;
				break;
			}
		}
		while (!foundSubject)
		{
			cout << "Такого предмета не существует, введите существующий предмет:";
			cin >> subject;
			for (auto s : subjects)
			{
				if (subject == s)
				{
					foundSubject = true;
					break;
				}
			}
		}
		//Ввод и проврека оценки
		cout << "Введите оценку по предмету \"" << subject <<"\" студента под номером " << i + 1 << ":";
		cin >> grade;
		while (grade < 2 || grade > 5)
		{
			cout << "Такой оценки не существует, введите корректную оценку:";
			cin >> grade;
		}
		students[i] = Student(surname, subject, grade);
		cout << "Студент записан\n" << endl;
	}
	searchBadGrade(students,size); // поиск двоек
	delete[] students;
}

