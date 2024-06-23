#include <iostream>
#include <Windows.h>
#include <math.h>
#include <iomanip>

using namespace std;

class Point
{
private:
	double x;
	double y;
public:
	Point(double xP, double yP) : x{ xP }, y{ yP } {}
	Point() : x{ 0 }, y{ 0 } {}

	double getX() { return x; }
	double getY() { return y; }
	void setX(double xP) { x = xP; }
	void setY(double yP) { y = yP; }

	void display() const { cout << "(" << x << ";" << y << ")"; }
	void read() 
	{ 
		cin >> x;
		cin.ignore(1);
		cin >> y; 
	}
	static bool isEqual(const Point& point1, const Point& point2)
	{
		return point1.x == point2.x && point1.y == point2.y;
	}
	static Point add(const Point& point1, const Point& point2)
	{
		return Point(point1.x + point2.x, point1.y + point2.y);
	}
	static Point subtract(const Point& point1, const Point& point2)
	{
		return Point(point1.x - point2.x, point1.y - point2.y);
	}
	static Point multiply(const Point& point1, const Point& point2)
	{
		return Point(point1.x * point2.x, point1.y * point2.y);
	}
	static double distance(const Point& point1, const Point& point2) 
	{ 
		return sqrt(pow(point1.x - point2.x, 2) + pow(point1.y - point2.y, 2));
	}
	static double length(const Point& point)
	{
		return distance(point, Point());
	}
	static bool isBigger(const Point& point1, const Point& point2)
	{
		return length(point1) > length(point2);
	}
	static bool isLess(const Point& point1, const Point& point2)
	{
		return length(point1) < length(point2);
	}
	
	static friend Point operator+(const Point& point1, const Point& point2){ return add(point1, point2); }
	static friend Point operator-(const Point& point1, const Point& point2) { return subtract(point1, point2); }
	static friend Point operator*(const Point& point1, const Point& point2) { return multiply(point1, point2); }
	static friend Point operator*(const Point& point1, double multiplier) { return multiply(point1, Point(multiplier,multiplier)); }
	static friend bool operator>(const Point& point1, const Point& point2) { return isBigger(point1, point2); }
	static friend bool operator<(const Point& point1, const Point& point2) { return isLess(point1, point2); }
	static friend bool operator==(const Point& point1, const Point& point2) { return isEqual(point1, point2); }
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Point point1(1, 1);
	Point point2;
	Point point3(1,1);

	if (point1 == point3)
	{
		cout << "p1 and p3 are equal" << endl;
	}

	cout << "p1: ";
	point1.display();
	cout << endl;

	cout << "Enter point p2 in format x,y (e.g. 12,10): ";
	point2.read();

	cout << "p2: ";
	point2.display();
	cout << endl;

	/*cout << "p2 + p1 = ";
	Point::add(point1, point2).display();
	cout << endl;*/
	cout << "p1 + p2 = ";
	(point1 + point2).display();
	cout << endl;

	cout << "p1 * 2 = ";
    (point1 * Point(2,2).display();
	cout << endl; 

	cout << "p1 and p2 distance = " << Point::distance(point1, point2) << endl; 
	cout << "p2 length = " << Point::length(point2) << endl; 
}