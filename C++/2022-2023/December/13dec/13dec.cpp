#include <iostream>
#include <Windows.h>
#include <typeinfo>
using namespace std;

class Account
{
private:
    double sum;
    const double rate;
public:
    Account(double sum, double rate) : rate{ rate }
    {
        this->sum = sum;
    }

    double getRate() const
    {
        return rate;
    }
    double getIncome()
    {
        return sum * rate / 100;
    }
    double getIncome() const
    {
        return sum * rate / 100;
    }
    double getSum() const
    {
        return sum;
    }
    double setSum()
    {
        sum += getIncome();
        return sum;
    }
};

//class Date
//{
//private:
//    const int baseYear;
//    int& currentYear;
//    int day;
//    int month;
//    int year;
//public:
//    Date(int currYear) : baseYear{ 2000 }, currentYear{ currYear } {}
//    
//    void setCurr()
//    {
//        currentYear = 10;
//    }
//    int& getCurr()
//    {
//        return currentYear;
//    }
//
//    void setDay(int dayP) 
//    { 
//        day = dayP;
//    }
//    int getDay() const
//    {
//        return day;
//    }
//    /*Date(int dayP, int monthP, int yearP) : day{ dayP }, month{ monthP }, year{ yearP } {}
//    Date() : Date(1, 1, 1970) {}
//    Date(const Date& obj) : day{ obj.day }, month{ obj.month }, year{ obj.year } {}
//    void print()
//    {
//        cout << (day < 10 ? "0" : "") << day << "." << (month < 10 ? "0" : "") << month << "." << year << endl;
//    }
//    void setDay(int day) { this->day = day; }
//    int getDay() const
//    {
//        return this->day;
//    }
//    int getDay() 
//    {
//        return this->day;
//    }*/
//};

void f(long a)
{

}
float f1(long a)
{
    return 10.0;
}
int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int I = 10;
    float F = 5.5;
    double D = 15.4;
    short S = 2;

    cout << typeid(F * S).name();

    time_t t;


   /* Account acc1(2000, 5);
    const Account acc2(5000, 8);

    acc1.getRate();
    acc2.getRate();

    acc1.getSum();
    acc2.getSum();

    acc1.getIncome();
    acc2.getIncome();

    acc1.setSum();*/

    /*int treeHeight;
    int totalHeight = 0;
    int dayStep;
    int nightStep;
    cout << "Введите высоту дерева:";
    cin >> treeHeight;
    cout << "Введите шаг за день:";
    cin >> dayStep;
    cout << "Введите шаг за ночь:";
    cin >> nightStep;
    
    cout << "Вариант через формулу:";
    int days = ceil(float(treeHeight - dayStep) / (dayStep - nightStep) + 1);
    cout << days << endl;

    days = 0;

    cout << "Вариант через цикл:";
    while (treeHeight > totalHeight)
    {
        totalHeight += dayStep;
        days++;
        if (treeHeight <= totalHeight)
            break;
        totalHeight -= nightStep;
    }
    cout << days << endl;

    days = 0;

    cout << "Вариант учителя:";
    cout << (treeHeight - nightStep - 1) / (dayStep - nightStep) + 1;*/
}