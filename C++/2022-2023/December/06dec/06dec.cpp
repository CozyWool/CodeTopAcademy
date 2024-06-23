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
		cout << "Fraction constructed for " << this << endl;
	}
	Fraction() : Fraction{ 1,1 } {}
	~Fraction()
	{
		cout << "Fraction destructed for " << this << endl;
	}
	void print()
	{
		cout << "(" << numerator << "/" << denominator << ")" << endl;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	Fraction a{ 2,3 };
	Fraction b{ a };

	cout << "a = ";
	a.print();
	cout << "b = "; 
	b.print(); 
}

//class Date
//{
//private:
//	int day;
//	int month;
//	int year;
//public:
//	Date(int dayP, int monthP, int yearP) : day{ dayP }, month{ monthP }, year{ yearP } 
//	{
//		cout << "Date constructed for " << this << endl;
//	}
//	Date() : Date{ 1,1,1970 } {}
//
//	~Date()
//	{
//		cout << "Date destructed for " << this << endl;
//	}
//	void print()
//	{
//		cout << (day < 10 ? "0" : "") << day << "." << (month < 10 ? "0" : "") << month << "." << year << endl;
//	}
//	Date& setDay(int day) 
//	{
//		this->day = day;
//		return *this;
//	}
//	Date& setMonth(int month)
//	{
//		this->month = month;
//		return *this;
//	}
//	Date& setYear(int year) 
//	{ 
//		this->year = year;
//		return *this;
//	}
//};
//
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	srand(time(NULL));
//
//	Date date1{ 24,8,1991 };
//	Date date2{ 12,4,1991 };
//	date1.print();
//	date2.print();
//	system("pause");
//}

//Шахматная доска, на которой стоит белая шашка в точке (x1,y1). 
//Пользователь вводит начальную позицию шашки (x1, y1) и конечную позицию (x2, y2).  
//Результат: сможет ли шашка попасть из (x1, y1) и (x2, y2).
//class Point
//{
//private:
//	int x;
//	int y;
//
//public:
//	Point(int pX, int pY) : x{ pX }, y{ pY } {}
//	Point() : Point(0, 0) {}
//	int getX() { return x; }
//	int getY() { return y; }
//	void setX(int pX) { x = pX; }
//	void setY(int pY) { y = pY; }
//	bool canMove(Point endPos)
//	{
//		int x1 = x;
//		int y1 = y;
//		int x2 = endPos.getX();
//		int y2 = endPos.getY();
//
//		int h = y2 - y1; // удаленность конечной позиции от начальной в рядах(шаг)
//
//		/* если мы идем вперед,
//		а также конечная клетка такого же цвета(одинаковая четность суммы x и y),
//		и если конечная клетка входит в промежуток доступных клеток - [x1 - h; x1 + h]*/
//		if ((y2 > y1 && ((x1 + y1) % 2 == (x2 + y2) % 2)) && (x1 - h <= x2 && x2 <= x1 + h))
//			return true;
//
//		return false;
//	}
//};
//
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	Point beginPos;
//	Point endPos;
//	int x1, y1, x2, y2;
//
//	cout << "Введите начальную позицию шашки по" << endl;
//	cout << "x:";
//	cin >> x1;
//	cout << "y:";
//	cin >> y1;
//	beginPos.setX(x1);
//	beginPos.setY(y1);
//
//	cout << "\nВведите конечную позицию шашки по" << endl;
//	cout << "x:";
//	cin >> x2;
//	cout << "y:";
//	cin >> y2;
//	endPos.setX(x2);
//	endPos.setY(y2);
//	cout << "Шашка " << (beginPos.canMove(endPos) ? "может" : "не может") << " дойти до позиции (" << 
//		endPos.getX() << ";" << endPos.getY() << ")" << endl;
//}