#include <iostream>
#include <string>
#include <windows.h>
#include <cctype>
#include <math.h>

using namespace std;

//struct times {
//    int hours;
//    int minutes;
//    int seconds;
//};

//enum
//{
//    ADD = 1,
//    DEL = 2,
//    QUERY = 3,
//    FIND = 4,
//    SORT = 5
//};

//auto myfunction(int a)->decltype(a) {
//    a = 5;
//    return a;
//}

//int myFunc(char ch)
//{
//    return 5;
//}
//
//int myFunc2(char ch)
//{
//    return 6;
//}
//
//int myFunc3(char ch)
//{
//    return 7;
//}
//
//int myFunc4(char ch)
//{
//    return 8;
//}

//struct owners
//{
//    string name;
//    string passport;
//    string address;
//};
//
//struct car
//{
//    int cntDanger = 0;
//    int probeg = 0;
//    owners owner;
//};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int num;
    cout << "Введите число:";
    cin >> num;

    string strNum = to_string(num);
    bool isPalindrom = true;

    /*for (int i = 0; i < strNum.length(); i++)
    {
        if (strNum[i] == strNum[strNum.length() - 1 - i])
        {
            continue;
        }
        else
        {
            isPalindrom = false;
        }
    }*/
    int length = to_string(num).length();
    for (int i = 0; i < length; i++)
    {
        if (num / (int)pow(10, i) == num / (int)pow(10, length - 1 - i))
        {
            continue;
        }
        else
        {
            isPalindrom = false;
        }
    }
    cout << (isPalindrom ? "Палиндром" : "Не палиндром") << endl;

    /*car* cars = nullptr;

    car bmw;

    bmw.cntDanger = 5;
    bmw.probeg = 10;
    bmw.owner.name = "ct";
    bmw.owner.passport = "0770";
    bmw.owner.address = "los at";

    cars = &bmw;

    cout << cars->probeg;*/

   /* car audi;
    
    audi.cntDanger = bmw.cntDanger;

    cout << audi.owner.name << endl;*/

    /*int (*ptr[4])(char) {myFunc,myFunc2,myFunc3,myFunc4};
    cout << (*ptr[0])('h');*/


    //typedef char* ch;

    //ch b; // char* b

    //int num = 1;

    //auto b = num;

    //decltype(num) a;
    //times time1;
    //times time2;
    //times timeDiff;

    //cout << "Введите первую точку времени\n";
    //cout << "Часы: ";
    //cin >> time1.hours;
    //cout << "Минуты: ";
    //cin >> time1.minutes;
    //cout << "Секунды: ";
    //cin >> time1.seconds;
    //cout << endl;
    //cout << "Введите вторую точку времени\n";
    //cout << "Часы: ";
    //cin >> time2.hours;
    //cout << "Минуты: ";
    //cin >> time2.minutes;
    //cout << "Секунды: ";
    //cin >> time2.seconds;
    //cout << endl;

    //timeDiff.seconds = abs((time1.hours * 3600 + time1.minutes * 60 + time1.seconds) -
    //    (time2.hours * 3600 + time2.minutes * 60 + time2.seconds));
    //timeDiff.hours = timeDiff.seconds / 3600;
    //timeDiff.seconds %= 3600;
    //timeDiff.minutes = timeDiff.seconds / 60;
    //timeDiff.seconds %= 60;

    //cout << "Разница во времени: " << timeDiff.hours / 10 << timeDiff.hours % 10 << ":"  << timeDiff.minutes / 10<< timeDiff.minutes % 10 << ":" << timeDiff.seconds / 10 <<timeDiff.seconds % 10 << endl;
    //// 2-ой вариант
    //cout << "Разница во времени: " << (timeDiff.hours >= 10 ? "" : "0") << timeDiff.hours << ":" << (timeDiff.minutes >= 10 ? "" : "0") << timeDiff.minutes << ":" << (timeDiff.seconds >= 10 ? "" : "0") << timeDiff.seconds << endl;
}