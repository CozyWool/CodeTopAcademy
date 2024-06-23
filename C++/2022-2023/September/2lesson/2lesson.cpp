#include <iostream>
#include "Rectangle.h"
using namespace std;
class Cube : public Rectangle
{
private:
    int c;
public:
    Cube();
    Cube(int a, int b, int c, int x, int y) : Rectangle(a, b, x, y)
    {
        this->c = c;
    }
    void PrintInfo() override
    {
        cout << "Это куб и он имеет площадь:" << getS() << endl;
    }
    int getS()
    {
        return a * b * c;
    }
};
int main()
{
    setlocale(0, "");
    Rectangle r(3,3,4,3);
    int x = 5;
    int y = 5;
    /*r.GetCenterPos(x, y);
    cout << "Координаты центра = (" << x << ";" << y << ")" << endl;
    cout << "Периметр = " << r.Perimeter() << endl;
    cout << "Площадь = " << r.Square() << endl;*/
    for (int i = 0; i < x * 2 + 1; i++)
    {
        for (int j = 0; j < y * 2 + 1; j++)
        {
            if (j == y || i == x || (x -1 - i == (r.getX() - 1) && y * 2 - j + 2 == (r.getY() + 1)))
            {
                cout << "*";
            }
            else
            {
                cout << " ";
            }
            cout << " ";
        }
        cout << endl;
    }
 }
