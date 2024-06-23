#include <iostream>
using namespace std;
class Point
{
protected:
	int x;
	int y;
public:
	Point() {};
	Point(int x, int y)
	{
		this->x = x;
		this->y = y;
	}
	~Point()
	{
		
	}
	virtual void PrintInfo()
	{
		cout << "Это точка и она имеет координаты:" << x << "," << y << endl;
	}
	int getX()
	{
		return x;
	}
	int getY()
	{
		return y;
	}
};
