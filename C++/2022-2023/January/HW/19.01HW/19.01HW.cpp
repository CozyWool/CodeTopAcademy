#include <iostream>
#include <Windows.h>
#include <string>

using namespace std;

class Date 
{
private:
	int day;
	int month;
	int year;
public:
	Date(int day, int month, int year) : day{ day }, month{ month }, year{ year } {}
	Date() : Date{ 1,1,1970 } {}
	Date(int day) : day{ day }
	{
		month = 0;
		year = 0;
		convertFromDays();
	}

	int calcInDays() const
	{
		return year * 360 + month * 30 + day; // не буду учитывать вискосные года и номер месяца
	}
	Date& convertFromDays() // Не особо понял как правильно переводить, поэтому вышло немного не так
	{
		day = calcInDays();
		month = 0;
		year = 0;
		if (day <= 30)
			return *this;

		while (day >= 360) // т.к я не учитывал номера месяцов, то в каждом месяце по 30 дней
		{
			year++;
			day -= 360;
		}
		while (month < 12 && day >= 30)
		{
			month++;
			day -= 30;
		}
		if (day > 30)
		{
			cout << "Result out of range" << endl;
			day = 30;
		}
		return *this;
	}

	friend ostream& operator<<(ostream& out, const Date& date)
	{
		out << (date.day < 10 ? "0" : "") << date.day << ".";
		out << (date.month < 10 ? "0" : "") << date.month << ".";
		out << date.year;
		return out;
	}
	friend istream& operator>>(istream& in, Date& date)
	{
		in >> date.day;
		in.ignore(1);
		in >> date.month;
		in.ignore(1);
		in >> date.year;
		return in;
	}

	friend int operator-(const Date d1, const Date d2)
	{
		int dayD1 = d1.calcInDays();
		int dayD2 = d2.calcInDays();
		return dayD1 > dayD2 ? dayD1 - dayD2 : dayD2 - dayD1;
	}

	Date& operator+(int day)
	{
		this->day += day;
		convertFromDays();
		return *this;
	}
};

string operator*(string s1, string s2)
{
	string result = "";
	for (int i = 0; i < s1.length(); i++)
	{
		for (int j = 0; j < s2.length(); j++)
		{
			if (s1[i] == s2[j] && result.find(s1[i]) == std::string::npos)
			{
				result += s1[i];
			}
		}
	}
	return result;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	while(true)
	{
		Date date1{ 28,6,2023 };
		string a, b;


		int t;
		cout << "Введите номер задания(1 - 2): ";
		cin >> t;
		switch (t)
		{
		case 1:
			cout << "Date1: " << date1 << endl;

			cout << date1;
			cout << " + 3: " << date1 + 3 << endl;

			cout << date1 << " - 28.5.2023: " << (date1 - Date{ 28,5,2023 }) << endl;
			break;
		case 2:
			cout << "Введите строку a: " << endl;
			cin >> a;
			cout << "Введите стркоу b: " << endl;
			cin >> b;
			cout << "a * b: " << a * b << endl;
			break;
		default:
			break;
		}
	}
}