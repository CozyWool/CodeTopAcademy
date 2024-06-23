#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <cassert>

using namespace std;

class String
{
private:
	char* str;
public:
	String(const char* strP)
	{
		str = new char[strlen(strP) + 1]; // + 1 для \0
		strcpy(str, strP);
	}

	String() : String{ "" } {}
	String(const String& obj)
	{
		str = new char[obj.getLength()];
		strcpy(str, obj.str);
	}
	String(String&& obj) noexcept
	{
		str = new char[obj.getLength()];
		strcpy(str, obj.str);
		obj.str = nullptr;
	}

	~String()
	{
		if(str != nullptr)
			delete[] str;
		
	}

	char* getStr() const { return str; }
	int getLength() const { return strlen(str) + 1; } // + 1 для \0

	void setStr(const char* strP)
	{ 
		str = new char[strlen(strP) + 1]; // + 1 для \0
		strcpy(str, strP);
	}

	friend ostream& operator<<(ostream& out, const String s)
	{
		out << s.str;
		return out;
	}
	char& operator[](int idx)
	{
		assert((idx >= 0 && idx < getLength()) && "Index is out of range!");
		return str[idx];
	}
	char operator[](int idx) const
	{
		assert((idx >= 0 && idx < getLength()) && "Index is out of range!");
		return str[idx];
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	String str("Hello World");
	cout << str << endl;
	cout << str[0] << endl << endl;

	str.setStr("Bye!");
	cout << str << endl << endl;

	const String str1{ str };
	cout << str1[0] << endl;
}