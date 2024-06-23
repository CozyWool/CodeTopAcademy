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
    /*static const int GOLD{ 0 };
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
        assert(idx >= 0 && idx < 3 && "Index out of range!");
        return medals[idx];
    }
    int operator[](int idx) const
    {
        assert(idx >= 0 && idx < 3 && "Index out of range!");
        return medals[idx];
    }
};

class MedalsTable
{
public:
    static const int maxSize = 10;
private:
    MedalRow medalRows[MedalsTable::maxSize];
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
    MedalsTable(int size, MedalRow* medalRows) : size{ size }
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

    MedalRow& operator[](const char* country)
    {
        int idx{ findCountry(country) };

        if (idx == -1)
        {
            assert(size < MedalsTable::maxSize && "Table is FULL");
            idx = size++;
            medalRows[idx].setCountry(country);
        }

        return medalRows[idx];
    }
    MedalRow operator[](const char* country) const
    {
        int idx{ findCountry(country) };

        assert("Const Table doesn't have country" && idx != -1);
        
        return medalRows[idx];
    }

    friend ostream& operator<<(ostream& out, const MedalsTable& m)
    {
        out << "Страна\tЗолото\tСеребро\tБронза" << endl;
        for (int i = 0; i < m.size; i++)
        {
            out << m.medalRows[i] << endl;
        }
        return out;
    }
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
    
    MedalRow russia{ "RUS",new int[3] {2,3,4} };
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
    cout << mt2["RUS"] << endl;

	//int number;
	//cout << "Введите число: ";
	//cin >> number;
	//int* sums = new int[3];
	//sums[0] = number / 1000 + number / 100 % 10;
	//sums[1] = number / 100 % 10 + number / 10 % 10;
	//sums[2] = number / 10 % 10 + number % 10;
	//
	////Сортировка пузырьком
	//for (int i = 0; i < 2; i++)
	//{
	//	for (int j = 0; j < 2 - i; j++)
	//	{
	//		if (sums[j] > sums[j + 1])
	//		{
	//			sums[j] ^= sums[j + 1];
	//			sums[j + 1] ^= sums[j];
	//			sums[j] ^= sums[j + 1];
	//		}
	//	}
	//}
	//int result = sums[1] * 100 + sums[2];
	//cout << "Результат: " << sums[1] * 100 + sums[2] << endl;
	// delete[] sums;
    // 
	//int* sumsI = new int[3];
	//for (int i = 1000; i < 10000; i++)
	//{
	//	sumsI[0] = i / 1000 + i / 100 % 10;
	//	sumsI[1] = i / 100 % 10 + i / 10 % 10;
	//	sumsI[2] = i / 10 % 10 + i % 10;
	//
	//	//Сортировка пузырьком
	//	for (int i = 0; i < 2; i++)
	//	{
	//		for (int j = 0; j < 2 - i; j++)
	//		{
	//			if (sumsI[j] > sumsI[j + 1])
	//			{
	//				sumsI[j] ^= sumsI[j + 1];
	//				sumsI[j + 1] ^= sumsI[j];
	//				sumsI[j] ^= sumsI[j + 1];
	//			}
	//		}
	//	}
	//	if (sumsI[1] * 100 + sumsI[2] == 1215)
	//	{
	//		cout << "Наименьшее число:" << i << endl;
	//		break;
	//	}
	//}
	//delete[] sumsI;
}