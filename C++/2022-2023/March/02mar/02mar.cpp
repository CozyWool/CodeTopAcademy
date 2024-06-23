#include <iostream>
#include <vector>
#include <conio.h>
#include <Windows.h>
#include <math.h>

using namespace std;

//template<class T>
//struct Point
//{
//	T x;
//	T y;
//	friend ostream& operator<<(ostream& out, const Point& p)
//	{
//		out << "(" << p.x << "," << p.y << ")";
//		return out;
//	}
//};
//
//template <class T>
//struct Array
//{
//	vector<T> data;
//	void Add(T item)
//	{
//		data.push_back(item);
//	}
//	friend ostream& operator<<(ostream& out, const Array& a)
//	{
//		for (auto var : a.data)
//		{
//			out << var << " ";
//		}
//		return out;
//	}
//};
//
//template <template<class> class T, class T1>
//struct Some
//{
//	T<T1> data; // data, типом которой будет шаблон класса T, 
//	// но принимающий параметр-тип T1
//
//	void Add(T1 item)
//	{
//		data.Add(item);
//	}
//	friend ostream& operator<<(ostream& out, const Some& s)
//	{
//		out << s.data;
//		return out;
//	}
//};

class Figure
{
public:
	virtual double getSquare() = 0;
	virtual double getPerimeter() = 0;
	virtual string getTypeFigure() = 0;
};

class Rect : public Figure
{
private:
	double radius;
	double length;
public:
	Rect(double width, double length) : radius{ width }, length{ length } {}
	Rect() : Rect{ 1,1 } {}

	double getSquare() override { return radius * length; }
	double getPerimeter() override { return (radius + length) * 2; }
	double getLength() { return length; }
	double getWidth() { return radius; }

	string getTypeFigure() override { return "Прямоугольник"; }
};

class Circle : public Figure
{
private:
	double radius;
public:
	Circle(double radius) : radius{ radius } {}
	Circle() : Circle{ 1 } {}

	double getSquare() override { return radius * radius * 3.14; }
	double getPerimeter() override { return 2 * 3.14 * radius; }
	double getRadius() { return radius; }

	string getTypeFigure() override { return "Окружность"; }
};

class Triangle : public Figure
{
private:
	double a;
	double b;
	double c;
public:
	Triangle(double a, double b, double c) : a{ a }, b{ b }, c{ c } {}
	Triangle() : Triangle{ 1,1,1 } {}

	double getSquare() override
	{
		double p = getPerimeter() / 2;
		return sqrt(p * (p - a) * (p - b) * (p - c));
	}
	double getPerimeter() override { return a + b + c; }

	string getTypeFigure() override { return "Треугольник"; }

	Triangle& operator+(int number)
	{
		a += number;
		b += number;
		c += number;
		return *this;
		//...
	}
	friend ostream& operator<<(ostream& out, const Triangle& t)
	{
		out << t.a << " " << t.b << " " << t.c << endl;
		return out;
	}
};

class Person
{
protected:
	string name;
	int age;
public:
	Person(string name, int age) : name{ name }, age{ age } {}
	Person() : Person{ "",0 } {}
	friend ostream& operator<<(ostream& out, const Person& p)
	{
		out << "Имя: " << p.name << "\tВозраст: " << p.age;
		return out;
	}
};

class Student : public Person
{
private:
	string group;
public:
	Student(string name, int age, string group) : Person{ name,age }, group{ group } {}

	Student() : Student{ "",0,"" } {}
	friend ostream& operator<<(ostream& out, const Student& s)
	{
		out << "Имя: " << s.name << "\tВозраст: " << s.age << "\tГруппа: " << s.group;
		return out;
	}
};
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Triangle t(1, 2, 3);
	cout << (1 + t) << endl;
	Student s{ "Петров П.П.",20,"П12" };
	cout << s << endl;

	/*Rect r{ 10,20 };
	cout <<"Фигура: "<< r.getTypeFigure() << endl;
	cout <<"Длина | Ширина: "<< r.getLength() << " | " << r.getWidth() << endl;
	cout <<"Периметр: "<< r.getPerimeter() << endl;
	cout << "Площадь: " << r.getSquare() << endl;

	Circle c{ 10 };
	cout <<"\nФигура: "<< c.getTypeFigure() << endl;
	cout <<"Радиус: "<< c.getRadius()  << endl;
	cout <<"Длина окружности: "<< c.getPerimeter() << endl;
	cout << "Площадь: " << c.getSquare() << endl;

	Triangle t{ 2,3,4 };
	cout <<"\nФигура: "<< t.getTypeFigure() << endl;
	cout <<"Периметр: "<< t.getPerimeter() << endl;
	cout << "Площадь: " << t.getSquare() << endl;*/

	/*
	// Структура Point с целыми x, y
	Some<Point, int> intPoint;
	intPoint.data.x = 1;
	intPoint.data.y = 2;
	cout << "Some: struct Point with int x, y: " << intPoint << endl;

	// Структура Point с дробными x, y
	Some<Point, double> doublePoint;
	doublePoint.data.x = 10.086;
	doublePoint.data.y = 20.785;
	cout << "Some: struct Point with double x, y: " << doublePoint << endl;

	// Массив(вектор) целых чисел
	Some<Array, int> intArray;
	intArray.Add(1);
	intArray.Add(5);
	intArray.Add(7);
	cout << "Some: struct Array with int items: " << intArray << endl;

	// Массив(вектор) дробных чисел
	Some<Array, double> doubleArray;
	doubleArray.Add(1.4);
	doubleArray.Add(5.05);
	doubleArray.Add(7.007);
	cout << "Some: struct Array with double items: " << doubleArray << endl;

	// Массив(вектор) символов
	Some<Array, char> charArray;
	charArray.Add('H');
	charArray.Add('E');
	charArray.Add('L');
	charArray.Add('L');
	charArray.Add('O');
	cout << "Some: struct Array with char items: " << charArray << endl;

	// Массив(вектор) строк
	Some<Array, string> stringArray;
	stringArray.Add("Hello");
	stringArray.Add("World!");
	stringArray.Add("Bye");
	stringArray.Add("World!");
	cout << "Some: struct Array with string items: " << stringArray << endl;*/
}