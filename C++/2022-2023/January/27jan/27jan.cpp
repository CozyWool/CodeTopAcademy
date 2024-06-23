#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <cassert>

using namespace std;

class DynArray
{
private:
    int* arr;
    int size;
public: // Модификатор доступа
    DynArray(int sizeP) : arr{ new int[sizeP] }, size{ sizeP }
    {
        cout << "DynArray constructed for " << size << " elements, for " << this << endl;
    }

    DynArray() : DynArray(5) {} // Конструктор по умолчанию, делигирование
    DynArray(const DynArray& object) : arr{ new int[object.size] }, size{ object.size } // Конструктор копирования, константная ссылка на экземпляр
    {
        for (int i{ 0 }; i < size; i++)
        {
            arr[i] = object.arr[i];
        }
        cout << "DynArray copy constructed for " << size << " elements, for " << this << endl;
    }
    //DynArray(const DynArray& object) = delete;
    DynArray(DynArray&& object) noexcept : arr{ object.arr }, size{ object.size } // Конструктор копирования, константная ссылка на экземпляр
    {
        object.arr = nullptr;
        object.size = 0;
        cout << "DynArray move constructed for " << size << " elements, for " << this << endl;
    }

    DynArray& operator=(const DynArray& object) // Перегрузка оператора, константная ссылка на экземпляр
    {
        if (!(this == &object)) // Указатель на текущий экземпляр(this)
        {
            if (size != object.size)
            {
                delete[] arr;
                arr = new int[object.size];
            }
            size = object.size;
            for (int i{ 0 }; i < size; i++)
            {
                arr[i] = object.arr[i];
            }
            cout << "DynArray copy assigned for " << size << " elements, for " << this << endl;
        }
        return *this;
    }
    //DynArray& operator=(const DynArray& object) = delete;
    DynArray& operator=(DynArray&& object) noexcept
    {
        if (!(this == &object)) // Указатель на текущий экземпляр(this)
        {
            delete[] arr;
            arr = object.arr;
            size = object.size;
            object.arr = nullptr;
            object.size = 0;

            cout << "DynArray move assigned for " << size << " elements, for " << this << endl;
        }

        return *this;
    }
    int& operator[](int idx)
    {
        assert(idx >= 0 && idx < size && "Index is out of range!");
        return arr[idx];
    }
    int operator[](int idx) const
    {
        assert(idx >= 0 && idx < size && "Index is out of range!");
        return arr[idx];
    }
    friend ostream& operator<<(ostream& out, const DynArray& arr)
    {
        for (int i = 0; i < arr.size; i++)
        {
            out << arr[i] << " ";
        }
        return out;
    }

    void randomize()
    {
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand() % 10;
        }
    }

    int getElem(int idx) const  // Константный метод
    {
        if (idx < 0 || idx >= size)
        {
            cout << "Out of range" << endl;
            exit(1);
        }
        return arr[idx];
    }

    void setElem(int idx, int val)
    {
        if (idx < 0 || idx >= size)
        {
            cout << "Out of range" << endl;
            exit(1);
        }
        arr[idx] = val;
    }

    ~DynArray()
    {
        cout << "Try to free memory from DynArray for " << arr << " pointer\n";
        delete[] arr;
        cout << "DynArray destructed for " << size << " elements, for " << this << endl;
    }
};

DynArray arrayFactory(int arrSize)
{
    DynArray arr{ arrSize };
    arr.randomize();
    return arr;
}

enum MedalType
{
    GOLD,
    SILVER,
    BRONZE
};

class MedalRow
{
private:
    char country[4];
    int medals[3];
public:/*
    static const int GOLD{ 0 };
    static const int SILVER{ 1 };
    static const int BRONZE{ 2 };*/

    MedalRow(const char* countryP, const int* medalsP)
    {
        strcpy(country, countryP ? countryP : "NON");
        for (int i = 0; i < 3; i++)
        {
            medals[i] = medalsP ? medalsP[i] : 0;
        }
    }
    
    MedalRow() : MedalRow{ nullptr,nullptr } {}

    MedalRow& setCountry(const char* countryP)
    {
        if (countryP)
        {
            strcpy(country, countryP);
        }
        return *this;
    }

    const char* getCountry() const
    {
        return country;
    }

    friend ostream& operator<<(ostream& out, const MedalRow& m)
    {
        out << "[" << m.country << "] - ( ";
        for (int i = 0; i < 3; i++)
        {
            out << m.medals[i] << setw(4);
        }
        out << setw(1) << " )" << endl;
        return out;
    }
    int& operator[](int idx)
    {
        assert(idx >= 0 && idx < 3 && "Index out of range!");
        return medals[idx];
    }
    int operator[](int idx) const
    {
        assert(idx >= 0 && idx < 3 && "Index out of range!");
        return medals[idx];
    }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    MedalRow mr;
    mr.setCountry("RUS");

    mr[GOLD] = 3;
    mr[SILVER] = 2;
    mr[BRONZE] = 4;
    cout << mr << endl;

    /*const int size = 10;

    DynArray arr1{ arrayFactory(size) };
    cout << "arr1: " << arr1 << endl;
    cout << arr1[0] << endl;

    for (int i = 0; i < size; i++)
    {
        arr1[i] *= arr1[i];
    }
    cout << "Change every arr1 element ot its square: " << arr1 << endl;

    const DynArray arr2{ arrayFactory(size) };
    cout << "arr2: " << arr2 << endl;*/
}