#include <iostream>
#include <string>
#include <Windows.h>
#include <cctype>
#include <math.h>

using namespace std;

//struct coords
//{
//    int a;
//    int b;
//};
//
//bool isCross(int a, int b, int a1, int b1)
//{
//    if (a <= b1 && a1 <= b)
//        return true;
//    /*for (int i = a; i <= b; i++)
//    {
//        for (int j = a1; j <= b1; j++)
//        {
//            if (i == j)
//            {
//                return true;
//            }
//        }
//    }*/
//    return false;
//}

struct car
{
    string model;
    int probeg;
    int power;
    int price;
    string ownerName;
};

void fillStructs(car* cars, int size)
{
    for (int i = 0; i < size; i++)
    {
        cout << "\nВведите свойства автомобиля" << endl;
        cout << "Введите модель: ";
        cin >> cars[i].model;
        cout << "Введите пробег: ";
        cin >> cars[i].probeg;
        cout << "Введите мощность: ";
        cin >> cars[i].power;
        cout << "Введите цену: ";
        cin >> cars[i].price;
        cout << "Введите имя владельца: ";
        cin >> cars[i].ownerName;
    }
}

void printStructs(car* cars, int size)
{
    system("cls");
    for (int i = 0; i < size; i++)
    {
        cout << "\nCвойства автомобиля номер " << i + 1 << ":" << endl;
        cout << "1)Модель: " << cars[i].model << endl;
        cout << "2)Пробег: " << cars[i].probeg << endl;
        cout << "3)Мощность: " << cars[i].power << endl;
        cout << "4)Цена: " << cars[i].price << endl;
        cout << "5)Имя владельца: "<< cars[i].ownerName << endl; 
    }
}
void replaceProperties(car* cars, int size)
{
    int index;

    do
    {
        cout << "\nУ какого автомобиля вы хотите заменить свойства? Введите номер автомобиля:  ";
        cin >> index;
        index--;
    } while (index > size || index < 0);
    
    int property;

    do
    {
        cout << "Какое свойство вы хотите заменить? Введите номер свойства(1-5): ";
        cin >> property;
    } while (property > 5 || property < 0);
    
    switch (property)
    {
    case 1:
        cout << "Введите новое значение свойства \"Модель\": ";
        cin >> cars[index].model;
        break;
    case 2:
        cout << "Введите новое значение свойства \"Пробег\": ";
        cin >> cars[index].probeg;
        break;
    case 3:
        cout << "Введите новое значение свойства \"Мощность\": ";
        cin >> cars[index].power;
        break;
    case 4:
        cout << "Введите новое значение свойства \"Цена\": ";
        cin >> cars[index].price;
        break;
    case 5:
        cout << "Введите новое значение свойства \"Имя владельца\": ";
        cin >> cars[index].ownerName;
        break;
    default:
        break;
    }
}
int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    int size = 2;
    car* cars = new car[size];
    fillStructs(cars,size);
    printStructs(cars,size);
    replaceProperties(cars, size);
    printStructs(cars, size);

    delete[] cars;
    /*
    coords line1;
    coords line2;
    
    do
    {
        cout << "Введите 1-ый отрезок" << endl;
        cout << "Введите начало отрезка:";
        cin >> line1.a;
        cout << "Введите конец отрезка:";
        cin >> line1.b;
        cout << (line1.a > line1.b ? "Конец должен быть больше начала отрезка" : "") << endl;
    } while (line1.a > line1.b);

    do
    {
        cout << "Введите 2-ый отрезок" << endl;
        cout << "Введите начало отрезка:";
        cin >> line2.a;
        cout << "Введите конец отрезка:";
        cin >> line2.b;
        cout << (line2.a > line2.b ? "Конец должен быть больше начала отрезка" : "") << endl;
    } while (line2.a > line2.b);
    cout << (isCross(line1.a, line1.b, line2.a, line2.b) ? "Отрезки пересекаются" : "Отрезки не пересекаются") << endl;*/
}