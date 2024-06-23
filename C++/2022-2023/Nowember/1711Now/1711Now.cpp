#include <iostream>
#include <Windows.h>
#include <math.h>
#include <algorithm>
#include <stdlib.h>
#include <string>

using namespace std;

class Time
{
private:
	int hour;
	int minute;
	int second;
public:
    Time()
    {

    }
	Time(int hour, int minute, int second)
	{
        this->hour = hour;
        this->minute = minute;
        this->second = second;
	}
    int getTimeInSeconds()
    {
        int result = second;
        result += hour * 3600;
        result += minute * 60;
        return result;
    }
    void printTime()
    {
        cout << (hour < 10 ? "0" : "") << hour << "ч. ";
        cout << (minute < 10 ? "0" : "") << minute << "мин. ";
        cout << (second < 10 ? "0" : "") << second << "сек. ";
        cout << endl;
    }
    Time calcDiff(Time t)
    {
        int L_TotalSec = getTimeInSeconds(); // local
        int T_TotalSec = t.getTimeInSeconds(); // t
        Time resultTime;
        if (T_TotalSec < L_TotalSec)
        {
            resultTime.second = L_TotalSec - T_TotalSec;
        }
        else
        {
            resultTime.second = T_TotalSec - L_TotalSec;
        }
        resultTime.hour = resultTime.second / 3600;
        resultTime.second %= 3600;
        resultTime.minute = resultTime.second / 60;
        resultTime.second %= 60;
        return resultTime;
    }

};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	// Разница во времени в стиле ООП
    Time t1(14, 30, 40);
    Time t2(16, 6, 40);
    cout << "Разница между первым и вторым:";
    t1.calcDiff(t2).printTime();
    cout << "Разница между вторым и первым:";
    t2.calcDiff(t1).printTime();
    long long n = 1;
    int k = 1;
    for (int i = 0; i < 1024; i++)
    {
        n *= 2;
        n++;
        k++;
    }
    for (int i = 0; i < 1024; i++)
    {
        n *= 2;
        n++;
        k++;
    }
            for (int i = 0; i < 256; i++)
            {
                n *= 2;
                n++;
                k++;
            }
    cout << n << endl;
    cout << k << endl;
    
    //int n;
    //int k = 0; // Делитель
    //cout << "Введите число:";
    //cin >> n;
    //for (int i = 2; i < (n / 2 + 1); i++)
    //{
    //    if (n % i == 0)
    //    {
    //        k = i;
    //        break;
    //    }
    //}
    //cout << "Минимальный делитель:" << (k != 0 ? k : n) << endl;
}