#include <iostream>
#include <Windows.h>
#include <iomanip>
#include "Student.h"

using namespace std;

class Point
{
protected:
    int x {28};
    int y {-100};
public:
    Point() : x{0}, y {0}
    {
        cout << "Point constuctor default" << endl;
    }
    /*Point()
    {
        x = 0;
        y = 0;
        cout << "Point constuctor default" << endl;
    }*/
    Point(int x, int y) : x{ x } , y{ y }
    {
        cout << "Point constuctor parametrized" << endl;
    }
    /*Point(int x, int y)
    {
        this->x = x;
        this->y = y;
        cout << "Point constuctor parametrized" << endl;
    }*/
    int getX()
    {
        return x;
    }
    int getY()
    {
        return y;
    }
    void setX(int pX)
    {
        x = pX;
    }
    void setY(int pY)
    {
        y = pY;
    }
};

class Rect
{
private:
    Point leftUpperCorner;
    int width;
    int height;
public:
    Rect()
    {
        leftUpperCorner.setX(10);
        leftUpperCorner.setY(10);
        width = 0;
        height = 0;
        cout << "Rectangle constuctor default" << endl;
    }
    Rect(int x, int y, int width, int height)
    {
        leftUpperCorner.setX(x);
        leftUpperCorner.setY(y);
        this->width = width;
        this->height = height;
        cout << "Rectangle constuctor parametrized" << endl;
    }

};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    /*Point p1;
    cout << endl;
    Point p2{ 50, 109 };
    cout << endl;
    Rect rect1;
    cout << endl;
    Rect rect2{ 50,109,10,5 };
    cout << endl;*/

    Point point1;
    cout << "x:" << point1.getX() << endl;
    cout << "y:" << point1.getY() << endl;

    Point point2{ 42,48 };
    cout << "x:" << point2.getX() << endl;
    cout << "y:" << point2.getY() << endl;

    //int num[2];
    //int value(40);
    //int size{ 60 };

    //num[0] += 20;
    //cout << num[0] << endl;

    /*const int SIZE = 2;
    double sum = 0;
    double aver;

    Student* students = new Student[SIZE]
    {
        { "Иванов И.И", new int[3] {5, 4, 3} },
        { "Петров П.П", new int[3] {2, 3, 4} }
    };

    cout << "Успеваемость студента\n\n";

    cout << students + SIZE << endl;

    for (Student* students_copy = students; students_copy < students + SIZE; students_copy++)
    {
        aver = students_copy->getAverMark();
        students_copy->printAver();
        sum += aver;
    }

    cout << endl;

    cout << "Средний балл по группе:" << sum / SIZE << endl;

    delete[] students;*/
    
}