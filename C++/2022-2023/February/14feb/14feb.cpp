#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <string>
#include <iomanip>
#include <cassert>


using namespace std;

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
public:

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
            strcpy(country, _strupr(_strdup(countryP)));
        }
        return *this;
    }

    const char* getCountry() const
    {
        return country;
    }

    friend ostream& operator<<(ostream& out, const MedalRow& m)
    {
        out << "[" << m.country << "]\t";
        for (int i = 0; i < 3; i++)
        {
            out << m.medals[i] << "\t";
        }
        return out;
    }
    int& operator[](int idx)
    {
        assert(idx >= 0 && idx < 3 && "Индекс вышел за пределы!");
        return medals[idx];
    }
    int operator[](int idx) const
    {
        assert(idx >= 0 && idx < 3 && "Индекс вышел за пределы!");
        return medals[idx];
    }
};

class MedalsTable
{
private:
    MedalRow* medalRows;
    int size;

    int findCountry(const char* country) const
    {
        char* c = _strupr(_strdup(country));
        for (int i = 0; i < size; i++)
        {
            char* medalRow = _strupr(_strdup(medalRows[i].getCountry()));
            if (strcmp(medalRow, c) == 0)
                return i;
        }
        return -1;
    }
public:
    MedalsTable(int size, MedalRow* medalRows) : size{ size }, medalRows{ new MedalRow[size] }
    {
        if (medalRows)
        {
            for (int i = 0; i < size; i++)
            {
                this->medalRows[i] = medalRows[i];
            }
        }
    }
    MedalsTable() : MedalsTable{ 0,nullptr } {}
    MedalsTable(const MedalsTable& obj) : MedalsTable{ obj.size,obj.medalRows } {}
    MedalsTable(MedalsTable&& obj) noexcept : MedalsTable{ obj.size,obj.medalRows } 
    {
        obj.size = 0;
        obj.medalRows = nullptr;
    }

    ~MedalsTable()
    {
        if (medalRows)
            delete[] medalRows;
    }

    MedalsTable& operator=(const MedalsTable& obj)
    {
        if(this == &obj)
            return *this;
        size = obj.size;
        medalRows = new MedalRow[size];

        if (obj.medalRows)
        {
            for (int i = 0; i < size; i++)
            {
                medalRows[i] = obj.medalRows[i];
            }
        }

        return *this;
    }
    MedalsTable& operator=(MedalsTable&& obj) noexcept
    {
        if(this == &obj)
            return *this;
        size = obj.size;
        medalRows = new MedalRow[size];

        if (obj.medalRows)
        {
            for (int i = 0; i < size; i++)
            {
                medalRows[i] = obj.medalRows[i];
            }
        }

        obj.size = 0;
        obj.medalRows = nullptr;

        return *this;
    }

    MedalRow& operator[](const char* country)
    {
        int idx{ findCountry(country) };

        if (idx == -1)
        {
            MedalRow* data = new MedalRow[size + 1];
            for (int i = 0; i < size; i++)
            {
                data[i] = medalRows[i];
            }
            delete[] medalRows;

            idx = size++;
            data[idx].setCountry(country);
            medalRows = data;
        }

        return medalRows[idx];
    }
    MedalRow operator[](const char* country) const
    {
        int idx{ findCountry(country) };

        assert("В константной таблице нет такой страны" && idx != -1);

        return medalRows[idx];
    }

    friend ostream& operator<<(ostream& out, const MedalsTable& m)
    {
        cout << "Страна\tЗолото\tСеребро\tБронза" << endl;
        for (int i = 0; i < m.size; i++)
        {
            cout << m.medalRows[i] << endl;
        }
        return out;
    }
};

template<typename T>
void print(T* begin, T* end, char delimiter = ' ')
{
    while (begin != end)
    {
        cout << *begin++ << delimiter;
    }
    cout << endl;
}

template<typename T, typename Predicate>
int copy_if(T* sourceBegin, T* sourceEnd, T* destBegin, T* destEnd, Predicate pred)
{
    int copyCount{ 0 };
    while (destBegin != destEnd && sourceBegin != sourceEnd)
    {
        if (pred(*sourceBegin))
        {
            *destBegin++ = *sourceBegin;
            copyCount++;
        }
        sourceBegin++;
    }
    return copyCount;
}

class NoSequance
{
private:
    bool init;
    int prevEl;
public:
    NoSequance() : init{ false }, prevEl{ 0 } {}

    bool operator()(int el)
    {
        if (init)
        {
            bool result{ prevEl != el };
            if (result)
                prevEl = el;

            return result;
        }
        init = true;
        prevEl = el;
        return true;
    }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    const int size{ 10 };
    int arr1[size]{ 1,1,1,4,5,5,7,8,9,9 };
    int arr2[size]{};

    int* const arr1Begin{ arr1 };
    int* const arr1End{ arr1 + size };

    int* const arr2Begin{ arr2 };
    int* const arr2End{ arr2 + size };

    int* arr2NewEnd{};

    cout << "Оригнинальный arr1: " << endl;
    print(arr1Begin, arr1End);
    cout << "Оригинальный arr2: " << endl;
    print(arr2Begin, arr2End);
    cout << endl;

    cout << "Копирование элементов из arr1 в arr2 без повторений:" << endl;
    arr2NewEnd = arr2Begin + copy_if(arr1Begin, arr1End, arr2Begin, arr2End, NoSequance{});
    print(arr2Begin, arr2NewEnd);
    cout << endl;

    /*MedalRow russia{ "RUS",new int[3] {2,3,4} };
    MedalRow unitedStates{ "USA",new int[3] {0,0,1} };

    int size = 2;
    MedalRow* medalRows = new MedalRow[size]{ russia,unitedStates };

    MedalsTable mt1{ size,medalRows };
    mt1["Rus"][GOLD] = 14;
    mt1["Rus"][SILVER] = 5;
    mt1["Rus"][BRONZE] = 9;

    mt1["Czh"][GOLD] = 2;
    mt1["Czh"][SILVER] = 3;
    mt1["Czh"][BRONZE] = 4;

    mt1["Jap"][SILVER] = 10;

    cout << "Medals Table #1" << endl;
    cout << mt1 << endl;

    const MedalsTable mt2{ mt1 };

    cout << "Medals Table #2" << endl;
    cout << mt2 << endl;*/

}