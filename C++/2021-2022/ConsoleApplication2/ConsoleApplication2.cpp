#include <iostream>
#include <cmath>
#include <graphics>

using namespace std;

void Osi_x_y(int x_max, int y_max, int kolvo_del_x, int kolvo_del_y, int n_x, int n_y) //Псстроение координатных осей
//n_max, y_max - максимальное число значений по x и по y,
//kolvo_del_x, kolvo_del_y - количество делений по x и y,
//n_x, n_y - разряды для первого деления по x и по y
{
    int O_x = x_max / 2, O_y = y_max / 2;
    int x_min = 0, y_min = 0;
    //line(x_min, O_y, x_max, O_y);

    line(x_min, O_y, x_max - 5, O_y);
    line(x_min, O_y, x_max - 5, O_y);

    outtextxy(x_max - 10, O_y - 20, "x");

    line(O_x, y_min, O_x, y_max - 5);
    line(O_x, y_min, O_x, y_max - 5);

    outtextxy(O_x - 10, y_max - 20, "y");

    int delenie_x = int(O_x / kolvo_del_x);

    for (int i = 1; i <= kolvo_del_x; i++)
    {
        line(O_x + i * delenie_x, O_y - 5, O_x + i * delenie_x, O_y + 5);
        line(O_x - i * delenie_x, O_y - 5, O_x - i * delenie_x, O_y + 5);
    }

    int delenie_y = int(O_y / kolvo_del_y);

    for (int i = 1; i <= kolvo_del_y; i++)
    {
        line(O_x - 5, O_y + i * delenie_y, O_x + 5, O_y + i * delenie_y);
        line(O_x - 5, O_y - i * delenie_y, O_x + 5, O_y - i * delenie_y);
    }

    setcolor(3); char str[20];
    for (int i = 1; i <= kolvo_del_x; i++)
    {
        outtextxy(O_x + i * delenie_x, O_y + 5, itoa(i * int(pow(10.0, n_x - 1)), str, 10));
        outtextxy(O_x - i * delenie_x, O_y + 5, itoa(-i * int(pow(10.0, n_x - 1)), str, 10));
    }

    for (int i = 1; i <= kolvo_del_y; i++)
    {
        outtextxy(O_x + 5, O_y - i * delenie_y, itoa(i * int(pow(10.0, n_x - 1)), str, 10));
        outtextxy(O_x + 5, O_y + i * delenie_y, itoa(-i * int(pow(10.0, n_x - 1)), str, 10));
    }
}


int main()
{
    setlocale(LC_ALL, "Russian");

    cout << "Максимальная ширина окна" << getmaxwidth() << endl;
    cout << "Максимальная высота окна" << getmaxheight() << endl;
    int rx, ry;
    cout << "Введите размер окна:" << endl;
    cout << "Ширина окна"; cin >> rx;
    cout << "Высота окна"; cin >> ry;
    if ((rx > 0) && (rx < getmaxwidth()))
    {
        if ((ry > 0) && (ry < getmaxheight())) {
            int kolvo_delenii_x, kolvo_delenii_y;
            cout << "Введите количество делений по осямм Ox и Oy" << endl;
            cin >> kolvo_delenii_x >> kolvo_delenii_y;
            int n_x, n_y;
            cout << "Введите разряд первого деления по осям Ox и Oy (1 - отсчет идет; 2 - отсчет идет с 10...)" << endl;
            cin >> n_x >> n_y;
            initwindow(rx, ry);
            Osi_x_y(rx, ry, kolvo_delenii_x, kolvo_delenii_y, n_x, n_y);//Функция для рисования координат
            getch();
            closegraph();
        }
        else cout << "Введены неверные размеры по y" << endl;
    }
    else cout << "Введены неверные размеры по x" << endl;

    system("pause");
    return 0;
}