#pragma once
#include <iostream>
using namespace std;
class Person
{
private:
	int age;
	int height;
	string name;
	string surname;
public:
	Person() 
	{
		age = 1;
		height = 1;
		name = "Hеизвестно";
		surname = "Hеизвестно";
	}
	Person(int a,int h)
	{
		age = a;
		height = h;
	}
	void setAge(int a)
	{
		if (a > 0 && a < 120)
			age = a;
		else
			cout << "Возраст не правильный и он равен: " << a << endl;
	}
	int getAge()
	{
		return age;
	}
	void setHeight(int h)
	{
		if (h > 50 && h < 300)
			height = h;
		else
			cout << "Рост не правильный и он равен: " << h << endl;
	}
	int getHeight()
	{
		return height;
	}
	void setName(string n)
	{
		if (n.length() > 1)
		{
			name = n;
		}
		else
			cout << "Имя слишком короткое: " << n << endl;
	}
	string getName()
	{
		return name;
	}
	void setSurname(string sn)
	{
		if (sn.length() > 3)
		{
			surname = sn;
		}
		else
			cout << "Фамилия слишком короткая: " << sn << endl;
	}
	string getSurname()
	{
		return surname;
	}
	void Print()
	{
		cout << "Человека зовут " << name << " " << surname << endl;
		cout << "Возраст " << age << endl;
		cout << "Рост " << height << endl;
	}

	~Person()
	{
		cout << "Объект был удален " << this << endl;
	}
};

