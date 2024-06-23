
#include<iostream>
using namespace std;

class MyStr
{
	char* str;
	int size;
public:
	void Show()const
	{
		cout << str;
	}
	MyStr(const char* pstr = "")
	{
		size = strlen(pstr) + 1;
		str = new char[size];
		strcpy_s(str, size, pstr);
		cout << "M:";
	}
	MyStr(const MyStr& obj)
	{
		size = obj.size;
		str = new char[size];
		strcpy_s(str, size, obj.str);
		cout << "CMC";
	}
	~MyStr()
	{
		delete[]str;
		cout << "~M";
	}
};

int main()
{
	MyStr obj("Great");
	MyStr obj2;
	obj2 = obj;
	obj2.Show();

	return 0;
}