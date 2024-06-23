#include <iostream>
#include <Windows.h>
using namespace std;

struct Number {
    double a;
};
Number pluss(Number n, Number m)
{
    Number result;
    result.a = n.a + m.a;
    return result;
}
Number minuss(Number n, Number m)
{
    Number result;
    result.a = n.a - m.a;
    return result;
}
Number multiply(Number n, Number m)
{
    Number result;
    result.a = n.a * m.a;
    return result;
}
Number divide(Number n, Number m)
{
    Number result;
    result.a = n.a / m.a;
    return result;
}
int numberMenu() {
    int answer;
    cout << "1 - Сложить\n"
        << "2 - Вычесть\n"
        << "3 - Умножить\n"
        << "4 - Разделить\n"
        << "0 - Выход из программы\n"
        << "Введите команду:";
    cin >> answer;
    cout << endl;
    return answer;
}
void print(Number n)
{
    cout << n.a;
}

struct Auto
{
    int length;
    int clearance;
    int engineVolume;
    int enginePower;
    int wheelDiameter;
    string color;
    string transmissionType;
};
int autoMenu() {
    int answer;
    cout << "1 - Задать новое значение\n"
        << "2 - Найти значение\n"
        << "3 - Вывести автомобиль \n"
        << "0 - Выход из программы\n"
        << "Введите команду:";
    cin >> answer;
    cout << endl;
    return answer;
}
void setLength(int length, Auto& a)
{
    a.length = length;
}
void setClearance(int clearance, Auto& a)
{
    a.clearance = clearance;
}
void setEngineVolume(int engineVolume, Auto& a)
{
    a.engineVolume = engineVolume;
}
void setEnginePower(int enginePower, Auto& a)
{
    a.enginePower = enginePower;
}
void setWheelDiameter(int wheelDiameter, Auto& a)
{
    a.wheelDiameter = wheelDiameter;
}
void setColor(string color, Auto& a)
{
    a.color = color;
}
void setTransmissionType(string transmissionType, Auto& a)
{
    a.transmissionType = transmissionType;
}
void printAuto(Auto a)
{
    cout << "Длина | Клиренс | Объем двигателя | Мощность | Диаметр колес | Цвет | Тип КП" << endl;
    cout << a.length << " | "
        << a.clearance << " | "
        << a.engineVolume << " | "
        << a.enginePower << " | "
        << a.wheelDiameter << " | "
        << a.color << " | "
        << a.transmissionType << " | "
        << endl;
}
void searchInAuto(Auto a, int cmd)
{
    switch (cmd)
    {
    case 1:
        cout << a.length;
        break;
    case 2:
        cout << a.clearance;
        break;
    case 3:
        cout << a.enginePower;
        break;
    case 4:
        cout << a.engineVolume;
        break;
    case 5:
        cout << a.wheelDiameter;
        break;
    case 6:
        cout << a.color;
        break;
    case 7:
        cout << a.transmissionType;
        break;
    default:
        break;
    }
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    cout << "Структуры\nДомашенее задание №1\n" << endl;
    Number n, m, result;
    int answer;

    Auto automobiles;
    string color;
    string transmissionType;

    int cmd;
    bool key = true;
    while (key)
    {
        cout << "Введите номер задания от 1 до 2(0 - выход):"; // Почему во втором задании
        cin >> cmd;                                            // так много переменных в структуре ;_;
        system("cls");
        switch (cmd)
        {
        case 1:
            do {
                answer = numberMenu();
                if (answer != 0) 
                {
                    cout << "Первое число:";
                    cin >> n.a;
                    cout << "Второе число:";
                    cin >> m.a;
                }
                switch (answer)
                {
                case 0:
                    break;
                case 1:
                    result = pluss(n, m);
                    break;
                case 2:
                    result = minuss(n, m);
                    break;
                case 3:
                    result = multiply(n, m);
                    break;
                case 4:
                    result = divide(n, m);
                    break;
                }
                if (answer != 0)
                {
                    cout << "Результат: ";
                    print(result);
                    cout << endl << endl;
                }
            } while (answer != 0);
            system("cls");
            break;
        case 2:
            cout << "Введите длину автомобиля:";
            cin >> automobiles.length;
            cout << "Введите клиренс автомобиля:";
            cin >> automobiles.clearance;
            cout << "Введите объем двигателя автомобиля:";
            cin >> automobiles.engineVolume;
            cout << "Введите мощность двигателя автомобиля:";
            cin >> automobiles.enginePower;
            cout << "Введите диаметр колес автомобиля:";
            cin >> automobiles.wheelDiameter;
            cout << "Введите цвет автомобиля:";
            cin >> automobiles.color;
            cout << "Введите тип коробки передач автомобиля:";
            cin >> automobiles.transmissionType;
            do 
            {
                answer = autoMenu();
                switch (answer)
                {
                case 0:
                    break;
                case 1:
                    system("cls");
                    int newAnswer;
                    cout << "Для чего вы хотите задать новое значение?" << endl;
                    cout << "1 - Длина\n"
                        << "2 - Клиренс\n"
                        << "3 - Объем двигателя\n"
                        << "4 - Мощность двигателя\n"
                        << "5 - Диаметр колес\n"
                        << "6 - Цвет\n"
                        << "7 - Тип коробки передач\n"
                        << "Введите команду:";
                    cin >> newAnswer;
                    switch (newAnswer)
                    {
                    case 1:
                        int length;
                        cout << "Введите новое значение длины:";
                        cin >> length;
                        setLength(length, automobiles);
                        system("cls");
                        break;
                    case 2:
                        int clearance;
                        cout << "Введите новое значение клиренса:";
                        cin >> clearance;
                        setClearance(clearance, automobiles);
                        system("cls");
                        break;
                    case 3:
                        int engineVolume;
                        cout << "Введите новое значение объема двигателя:";
                        cin >> engineVolume;
                        setEngineVolume(engineVolume, automobiles);
                        system("cls");
                        break;
                    case 4:
                        int enginePower;
                        cout << "Введите новое значение мощности двигателя:";
                        cin >> enginePower;
                        setEnginePower(enginePower, automobiles);
                        system("cls");
                        break;
                    case 5:
                        int wheelDiameter;
                        cout << "Введите новое значение диаметра колес:";
                        cin >> wheelDiameter;
                        setWheelDiameter(wheelDiameter, automobiles);
                        system("cls");
                        break;
                    case 6:
                        cout << "Введите новое значение цвета:";
                        cin >> color;
                        setColor(color, automobiles);
                        system("cls");
                        break;
                    case 7:
                        cout << "Введите новое значение типа КП:";
                        cin >> transmissionType;
                        setTransmissionType(transmissionType, automobiles);
                        system("cls");
                        break;
                    default:
                        break;
                    }
                    break;
                case 2:
                    system("cls");
                    cout << "Что вы хотите найти?" << endl;
                    cout << "1 - Длина\n"
                        << "2 - Клиренс\n"
                        << "3 - Объем двигателя\n"
                        << "4 - Мощность двигателя\n"
                        << "5 - Диаметр колес\n"
                        << "6 - Цвет\n"
                        << "7 - Тип коробки передач\n"
                        << "Введите команду:";
                    cin >> newAnswer;
                    cout << "Ответ:";
                    searchInAuto(automobiles, newAnswer);
                    cout << endl;
                    break;
                case 3:
                    system("cls");
                    printAuto(automobiles);
                    break;
                default:
                    break;
                }
            } while (answer != 0);
                system("cls");
                break;
        case 0:
            key = false;
            cout << "\t\nДо свидания!" << endl;
            break;
        default:
            cout << "Нет такого задания!" << endl;
            break;
        }
    }
}