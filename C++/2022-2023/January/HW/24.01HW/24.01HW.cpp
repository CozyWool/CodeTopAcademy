#include <iostream>
#include <Windows.h>

using namespace std;

class Complex
{
private:
	double a;// Действительная часть
	double b;// Кооэф. мнимой части
public:
	Complex(double a, double b) : a{ a }, b{ b } {}
	Complex() : Complex{ 0,0 } {}
	Complex(const Complex& obj) : Complex{ obj.a,obj.b } {}
	Complex(Complex&& obj) noexcept : Complex{ obj.a,obj.b } 
	{
		obj.a = 0;
		obj.b = 0;
	}

	double getA() { return a; }
	double getB() { return b; }

	Complex& setA(double a) 
	{ 
		this->a = a;
		return *this; 
	}
	Complex& setB(double b) 
	{ 
		this->b = b;
		return *this;
	}

	friend ostream& operator<<(ostream& out, const Complex& c)
	{
		out << c.a << " + " << c.b << "i";
		return out;
	}
	friend istream& operator>>(istream& in, Complex& c)
	{
		in >> c.a >> c.b;
		return in;
	}

	friend Complex operator+(const Complex& z1, const Complex& z2) { return Complex{ z1.a + z2.a, z1.b + z2.b }; }
	friend Complex operator-(const Complex& z1, const Complex& z2) { return Complex{ z1.a - z2.a, z1.b - z2.b };
	}
	friend bool operator==(const Complex& z1, const Complex& z2) { return z1.a == z2.a && z1.b == z2.b; }
	friend bool operator!=(const Complex& z1, const Complex& z2) { return !(z1 == z2); }

	const Complex& operator()(double a, double b) // Что тут должно происходить?
	{
		this->a += a;
		this->b += b;
		return *this;
	}
};

class Time
{
private:
	int hour;
	int minute;
	int second;
public:
	Time(int hour, int minute, int second) : hour{ hour }, minute{ minute }, second{ second } 
	{
		convertFromSeconds();
	}
	Time(int second) : second{second}
	{
		hour = 0;
		minute = 0;
		convertFromSeconds();
	}
	Time() : Time{ 0,0,0 } {}
	Time(const Time& obj) : Time{ obj.hour,obj.minute,obj.second } {}
	Time(Time&& obj) noexcept : Time{ obj.hour,obj.minute,obj.second } 
	{
		obj.hour = 0;
		obj.minute = 0;
		obj.second = 0;
	}

	Time& addSecond()
	{
		second++;
		return *this;
	}

	int calcInSeconds() const { return hour * 3600 + minute * 60 + second; }
	Time& convertFromSeconds() 
	{
		second = calcInSeconds();
		hour = 0;
		minute = 0;
		if (second <= 59)
			return *this;

		while (hour < 23 && second >= 3600)
		{
			hour++;
			second -= 3600;
		}
		while (minute < 59 && second >= 60)
		{
			minute++;
			second -= 60;
		}
		if (second > 59)
		{
			cout << "Result out of range" << endl;
			second = 59;
		}
		return *this;
	}

	friend ostream& operator<<(ostream& out, const Time& t)
	{
		out << (t.hour < 10 ? "0" : "") << t.hour << ":";
		out << (t.minute < 10 ? "0" : "") << t.minute << ":";
		out << (t.second < 10 ? "0" : "") << t.second;
		return out;
	}
	friend istream& operator>>(istream& in, Time& t)
	{
		in >> t.hour; 
		in.ignore(1);
		in >> t.minute;
		in.ignore(1);
		in >> t.second;
		t.convertFromSeconds();
		return in;
	}

	friend Time operator+(const Time& t1, const Time& t2) 
	{ 
		return Time{ t1.calcInSeconds() + t2.calcInSeconds() };
	}
	friend Time operator-(const Time& t1, const Time& t2)
	{
		int secT1 = t1.calcInSeconds();
		int secT2 = t2.calcInSeconds();
		return Time{ secT1 > secT2 ? secT1 - secT2 : secT2 - secT1 };
	}
	Time operator+=(const Time& t) { return *this + t; }
	Time operator-=(const Time& t) { return *this - t; }

	Time& operator=(const Time& t)
	{
		if (this == &t)
			return *this;

		hour = t.hour;
		minute = t.minute;
		second = t.second;
		
		return *this;
	}
	Time& operator=(Time&& t) noexcept
	{
		if (this == &t)
			return *this;

		hour = t.hour;
		minute = t.minute;
		second = t.second;
		t.hour = 0;
		t.minute = 0;
		t.second = 0;
		
		return *this;
	}

	// префиксная форма
	Time& operator++()
	{
		++hour; ++minute; ++second; return *this;
	}
	Time& operator--()
	{
		--hour; --minute; --second; return *this;
	}
	// постфиксная форма
	const Time operator++(int)
	{
		Time time{ *this };
		++(*this);
		return time;
	}
	const Time operator--(int)
	{
		Time time{ *this };
		--(*this);
		return time;
	}

	friend bool operator==(const Time& t1, const Time& t2) 
	{ 
		return t1.hour == t2.hour && t1.minute == t2.minute && t1.second == t2.second;
	}
	friend bool operator!=(const Time& t1, const Time& t2) { return !(t1 == t2); }
	friend bool operator>(const Time& t1, const Time& t2) { return t1.calcInSeconds() > t2.calcInSeconds(); }
	friend bool operator<(const Time& t1, const Time& t2) { return t1.calcInSeconds() < t2.calcInSeconds(); }

	const Time& operator()(int hour, int minute, int second)
	{
		this->hour += hour;
		this->minute += minute;
		this->second += second;
		return *this;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Complex z1;
	Complex z2;

	Time t1;
	Time t2;

	int t;
	cout << "Введите номер задания (1 - 2): ";
	cin >> t;
	switch (t)
	{
	case 1:
		cout << "Введите z1(a и b через пробел): ";
		cin >> z1;
		cout << "Введите z2(a и b через пробел): ";
		cin >> z2;

		cout << "z1: " << z1 << endl;
		cout << "z2: " << z2 << endl << endl;

		cout << "z1 + z2 = " << z1 + z2 << endl;
		cout << "z1 - z2 = " << z1 - z2 << endl;
		cout << "z1 == z2 = " << (z1 == z2 ? "true" : "false") << endl;
		cout << "z1 != z2 = " << (z1 != z2 ? "true" : "false") << endl;
		cout << "z1(2,2) = " << z1(2, 2) << endl;
		break;
	case 2:
		cout << "Введите t1(hh:mm:ss): ";
		cin >> t1;
		cout << "Введите t2(hh:mm:ss): ";
		cin >> t2;

		cout << "t1: " << t1 << endl;
		cout << "t2: " << t2 << endl << endl;

		cout << "t1 + t2 = " << t1 + t2 << endl;
		cout << "t1 - t2 = " << t1 - t2 << endl;
		cout << "t1 == t2 = " << (t1 == t2 ? "true" : "false") << endl;
		cout << "t1 != t2 = " << (t1 != t2 ? "true" : "false") << endl;
		cout << "t1(2,2) = " << t1(2, 2, 2) << endl;
		break;
	default:
		break;
	}
	
}