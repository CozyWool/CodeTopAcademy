#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>

using namespace std;


class Name
{
private:
	char* firstName;
	char* secondName;

	void setCharArray(char*& dest, const char* source)
	{
		int strSize = strlen(source) + 1;
		dest = new char[strSize];
		strcpy(dest, source);
	}

	void remove()
	{
		if (firstName != nullptr)
			delete[] firstName;
		if (secondName != nullptr)
			delete[] secondName;
	}
public:

	Name(const char* fName, const char* sName)
	{
		setCharArray(firstName, fName);
		setCharArray(secondName, sName);
	}
	Name()  
	{
		firstName = nullptr;
		secondName = nullptr;
	}
	Name(const Name& name) : Name{ name.firstName,name.secondName } {}
	~Name()
	{
		remove();
	}
	void write()
	{
		cout << firstName << " " << secondName << endl;
	}

	Name& operator& (const Name& name)
	{
		cout << firstName << " " << secondName << endl;
		return *this;
	}

	Name& operator=(const Name& name)
	{
		//обход самокопирования
		if (this == &name)
		{
			return *this;
		}
		
		remove();

		setCharArray(firstName,name.firstName);
		setCharArray(secondName,name.secondName);

		return *this;
	}
};

void writeLine(Name name)
{
	name.write();
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	//srand(time(NULL));

	char firstName[10] = "John";
	char secondName[10] = "Keil";
	{
		Name name{ firstName,secondName };
		cout << "Выполнен конструктор объекта name: ";
		writeLine(name);
	}

	Name aName;
	cout << "Выполнен деструктор объекта name";
	{
		Name name(firstName, secondName);
		cout << "Выполнен конструктор объекта name: ";
		writeLine(name);
		aName = name;
		cout << "Выполнен конструктор объекта aName: ";
		writeLine(aName);
	}

	cout << "Выполнен деструктор объекта name " << endl << endl;
	cout << "Выполнен обращаение к объекту aName: ";
	writeLine(aName);
}