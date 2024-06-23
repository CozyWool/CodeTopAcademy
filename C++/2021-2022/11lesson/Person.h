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
		name = "H���������";
		surname = "H���������";
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
			cout << "������� �� ���������� � �� �����: " << a << endl;
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
			cout << "���� �� ���������� � �� �����: " << h << endl;
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
			cout << "��� ������� ��������: " << n << endl;
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
			cout << "������� ������� ��������: " << sn << endl;
	}
	string getSurname()
	{
		return surname;
	}
	void Print()
	{
		cout << "�������� ����� " << name << " " << surname << endl;
		cout << "������� " << age << endl;
		cout << "���� " << height << endl;
	}

	~Person()
	{
		cout << "������ ��� ������ " << this << endl;
	}
};

