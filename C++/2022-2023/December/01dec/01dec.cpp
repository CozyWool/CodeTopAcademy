#include <iostream>
#include <Windows.h>

using namespace std;

//int fact(int n)
//{
//    if (n > 2)
//        return n * fact(n - 1);
//    else if (n == 0)
//        return 1;
//    return n;
//}

//class Demo
//{
//public:
//    int personal;
//    static int common;
//};
//
//int Demo::common{ 0 };

//class NumberStorage
//{
//private:
//    int* storage;
//    uint32_t elementCount;
//    static uint32_t usedMemory;
//public:
//    NumberStorage(uint32_t elementCount) : 
//        elementCount{ elementCount },
//        storage{ new int[elementCount] }
//    {
//        uint32_t used{ sizeof(storage[0]) * elementCount};
//        usedMemory += used;
//        cout << "NumberStorage: addition " << used << " bytes used." <<
//            "Total:" << usedMemory << endl;
//        for (uint32_t i = 0; i < elementCount; i++)
//        {
//            storage[i] = rand() % 10;
//        }
//    }
//
//    ~NumberStorage()
//    {
//        uint32_t freed{ sizeof(storage[0]) * elementCount };
//        delete[] storage;
//        usedMemory -= freed;
//        cout << "NumberStorage: freed " << freed << " bytes." <<
//            "Total:" << usedMemory << endl;
//    }
//
//    void print()
//    {
//        for (uint32_t i = 0; i < elementCount; i++)
//        {
//            cout << storage[i] << ' ';
//        }
//        cout << endl;
//    }
//
//    static uint32_t getUsedMemory()
//    {
//        return usedMemory;
//    }
//};
//
//uint32_t NumberStorage::usedMemory{ 0 };

class Date
{
private:
    int day;
    int month;
    int year;
public:
    Date(int dayP, int monthP, int yearP) : day{ dayP }, month{ monthP }, year{ yearP } {}
    Date() : Date(1, 1, 1970) {}
    void print()
    {
        cout << (day < 10 ? "0" : "") << day << "." << (month < 10 ? "0" : "") << month << "." << year << endl;
    }
    void setDay(int day) { this->day = day; }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    srand(time(NULL));

    Date date1{ 1,1,2022 };
    Date date2{ 24,7,1995 };

    date1.setDay(5);

    date1.print();
    date2.print();
    /*cout << "Total memory used: " << NumberStorage::getUsedMemory() << endl;

    const int poolSize{ 3 };
    NumberStorage pool[poolSize]{ rand() % 10, rand() % 10, rand() % 10 };

    cout << "Total memory used: " << NumberStorage::getUsedMemory() << endl;*/

    /*Demo d1{ 1 };
    Demo d2{ 2 };

    d1.common = 42;

    cout << "d2.common = " << d2.common << endl;*/
}
