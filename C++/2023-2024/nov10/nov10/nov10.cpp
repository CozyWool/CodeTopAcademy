#include <iostream>
#include <string>
#include <Windows.h>
#include "Stack.h"

//using namespace std;
//
//int CalculateFromString(string str);
//
//namespace hello
//{
//	void print(const std::string& text) 
//	{
//		std::cout << text << std::endl;
//	}
//
//	const std::string message{ "hello world" };
//}
//
//namespace console
//{
//	namespace msg 
//	{
//		const std::string hello{ "hello" };
//		const std::string welcome{ "welcome" };
//		const std::string goodbye{ "goodbye" };
//	}
//
//	void print(const std::string& text)
//	{
//		std::cout << text << std::endl;
//	}
//
//	void print_default()
//	{
//		std::cout << msg::hello << std::endl;
//	}
//}
//
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//
//	try
//	{
//		string str = "123412312412";
//		cout << CalculateFromString(str) << endl;
//	}
//	catch (const char* errorMessage)
//	{
//		cout << "\n\tОшибка" << endl;
//		cout << errorMessage << endl;
//	}
//
//	try
//	{
//		auto s = Stack(-3);
//
//		cout << "Добавление 5 в стек" << endl;
//		cout << "Добавление 6 в стек" << endl;
//		cout << "Добавление 4 в стек" << endl;
//		cout << "Добавление 3 в стек" << endl;
//		cout << "Добавление 2 в стек" << endl;
//		s.push(5);
//		s.push(6);
//		s.push(4);
//		s.push(3);
//		s.push(2);
//
//		cout << "Добавление 10 в стек" << endl;
//		s.push(10);
//	}
//	catch (exception e)
//	{
//		cout << "\n\tОшибка" << endl;
//		cout << e.what() << endl;
//	}
//
//	cout << endl;
//
//	hello::print(hello::message);
//	console::print(console::msg::goodbye);
//}
//
//int CalculateFromString(string str)
//{
//	try
//	{
//		int result = stoi(str);
//		return result;
//	}
//	catch (const out_of_range& e)
//	{
//		throw "Выход за границы диапазона int";
//	}
//	catch (const invalid_argument& e)
//	{
//		throw "Неверный аргумент";
//	}
//}
//
//namespace
//{
//	void func()
//	{
//		std::cout << "Hello" << std::endl;
//	}
//}
//
//int main()
//{
//	::func();
//}


namespace math
{
	class Fraction
	{
	private:
		int numerator;
		int denominator;
	public:
		Fraction(int num, int denom) : numerator{ num }, denominator{ denom }
		{
			if (denominator == 0)
			{
				throw invalid_argument("Знаменатель не может быть равен нулю!");
			}
		}
		Fraction() : Fraction{ 1,1 } {}
		Fraction(const Fraction& f) : numerator{ f.numerator }, denominator{ f.denominator }
		{
			if (denominator == 0)
			{
				throw invalid_argument("Знаменатель не может быть равен нулю!");
			}
		}

		double calcFraction() { return double(numerator) / denominator; }

		int getNum() { return numerator; }
		int getDenom() { return denominator; }
		int setNum(int num) { numerator = num; }
		int setDenom(int denom) { denominator = denom; }

		const Fraction& operator()() // Перегрузил этот оператор как сокращение дроби
		{
			for (int i = 1; i < denominator; i++)
			{
				if (numerator % i == 0 && denominator % i == 0)
				{
					numerator /= i;
					denominator /= i;
				}
			}
			return *this;
		}

		friend ostream& operator<<(ostream& out, const Fraction& f)
		{
			out << "(" << f.numerator << "/" << f.denominator << ")";
			return out;
		}
		static friend Fraction operator+(const Fraction& frac1, const Fraction& frac2)
		{
			int denom, num1, num2;
			if (frac1.denominator != frac2.denominator)
			{
				denom = frac1.denominator * frac2.denominator;
				num1 = frac1.numerator * frac2.denominator;
				num2 = frac2.numerator * frac1.denominator;
			}
			else
			{
				denom = frac1.denominator;
				num1 = frac1.numerator;
				num2 = frac2.numerator;
			}
			return Fraction{ num1 + num2,denom };
		}
		static friend Fraction operator-(const Fraction& frac1, const Fraction& frac2)
		{
			int denom, num1, num2;
			if (frac1.denominator != frac2.denominator)
			{
				denom = frac1.denominator * frac2.denominator;
				num1 = frac1.numerator * frac2.denominator;
				num2 = frac2.numerator * frac1.denominator;
			}
			else
			{
				denom = frac1.denominator;
				num1 = frac1.numerator;
				num2 = frac2.numerator;
			}
			return Fraction{ num1 - num2,denom };
		}
		static friend Fraction operator*(const Fraction& frac1, const Fraction& frac2)
		{
			return Fraction{ frac1.numerator * frac2.numerator,frac1.denominator * frac2.denominator };
		}
		static friend Fraction operator/(const Fraction& frac1, const Fraction& frac2)
		{
			return (frac1 * Fraction{ frac2.denominator,frac2.numerator });
		}
	};

	class Complex
	{
	private:
		double x;// Действительная часть
		double y;// Кооэф. мнимой части
	public:
		Complex(double a, double b) : x{ a }, y{ b } {}
		Complex() : Complex{ 0,0 } {}
		Complex(const Complex& obj) : Complex{ obj.x,obj.y } {}
		Complex(Complex&& obj) noexcept : Complex{ obj.x,obj.y }
		{
			obj.x = 0;
			obj.y = 0;
		}

		double getA() { return x; }
		double getB() { return y; }

		Complex& setA(double a)
		{
			this->x = a;
			return *this;
		}
		Complex& setB(double b)
		{
			this->y = b;
			return *this;
		}

		friend ostream& operator<<(ostream& out, const Complex& c)
		{
			out << c.x << " + " << c.y << "i";
			return out;
		}
		friend istream& operator>>(istream& in, Complex& c)
		{
			in >> c.x >> c.y;
			return in;
		}

		friend Complex operator+(const Complex& z1, const Complex& z2) { return Complex{ z1.x + z2.x, z1.y + z2.y }; }
		friend Complex operator-(const Complex& z1, const Complex& z2) {
			return Complex{ z1.x - z2.x, z1.y - z2.y };
		}
		friend bool operator==(const Complex& z1, const Complex& z2) { return z1.x == z2.x && z1.y == z2.y; }
		friend bool operator!=(const Complex& z1, const Complex& z2) { return !(z1 == z2); }
	};
}