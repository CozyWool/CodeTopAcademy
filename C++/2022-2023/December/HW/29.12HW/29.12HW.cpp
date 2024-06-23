#include <iostream>
#include <Windows.h>

using namespace std;

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
			cout << "Знаменатель не может быть равен нулю!" << endl;
			exit(1);
		}
	}
	Fraction() : Fraction{ 1,1 } {}
	Fraction(const Fraction& f) : numerator{ f.numerator }, denominator{ f.denominator } 
	{
		if (denominator == 0)
		{
			cout << "Знаменатель не может быть равен нулю!" << endl;
			exit(1);
		}
	}
	~Fraction()
	{
		// тут нечего писать ¯\_(ツ)_/¯, у нас же нет динамических переменных
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

int main()
{
	// Если что, оператор () пергружен как операция сокращения
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Fraction frac1{ 1,5 };
	Fraction frac2{ 4,10 };

	cout << "frac1: " << frac1 << endl;
	cout << "frac2: " << frac2 << endl;
	
	cout << "\n\tВ виде дроби" << endl;
	cout << "frac1 + frac2: " << (frac1 + frac2)() << endl;
	cout << "frac1 - frac2: " << (frac1 - frac2)() << endl;
	cout << "frac1 * frac2: " << (frac1 * frac2)() << endl;
	cout << "frac1 / frac2: " << (frac1 / frac2)() << endl;

	cout << "\n\tВ виде десятичной" << endl;
	cout << "frac1 + frac2: " << (frac1 + frac2).calcFraction() << endl;
	cout << "frac1 - frac2: " << (frac1 - frac2).calcFraction() << endl;
	cout << "frac1 * frac2: " << (frac1 * frac2).calcFraction() << endl;
	cout << "frac1 / frac2: " << (frac1 / frac2).calcFraction() << endl;
}