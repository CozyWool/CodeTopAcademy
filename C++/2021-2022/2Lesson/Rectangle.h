#pragma once
#include "Point.h"
#include <iostream>
using namespace std;
class Rectangle : public Point
{
protected:
	int a, b;
public:
	Rectangle() {};
	Rectangle(int a, int b, int x, int y) : Point(x, y)
	{
		this->a = a;
		this->b = b;
	}
	int Perimeter()
	{
		return (a + b) * 2;
	}
	int Square()
	{
		return a * b;
	}
	void GetCenterPos(int& x, int& y)
	{
		x = this->x;
		y = this->y;
	}
	void PrintInfo() override
	{
		cout << "Это прямоугольник и он имеет стороны:" << a << "," << b << endl;
	}
};

