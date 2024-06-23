#include <iostream>
#include <Windows.h>
#include <math.h>
#include <istream>
#include <string>

using namespace std;

/*template <class t>

void sort(t array[], size_t size)
{
    for (int i = 0; i < size - 1; ++i)
    {
        for (int j = 0; j < size - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                swap(array[j], array[j + 1]);
            }
        }
    }
}

template <class t>
void display(t array[], size_t size)
{
    for (size_t i = 0; i < size; i++)
    {
        cout << array[i] << " ";
    }
    cout << endl;
}*/

template<class T>

T averageValue(T* array, size_t size)
{
    T sum = array[0];
    for (size_t i = 1; i < size; i++)
    {
        sum += array[i];
    }
    return sum / size;
}

template<class T>

T solveLinear(T a, T b)
{
    return -b / a;
}

template<class T>
T* solveQuadratic(T a, T b, T c)
{
    T disc = b * b - 4 * a * c;

    if (disc < 0)
        return nullptr;
    if (disc > 0)
        return new T[2]{ (-b - sqrt(disc)) / (2 * a),(-b + sqrt(disc)) / (2 * a) };
    return new T[1]{ (-b) / (2 * a) };
}

template<class T>
T* Max(T a, T b)
{
    return a > b ? a : b;
}

template<class T>
T* Min(T a, T b)
{
    return a < b ? a : b;
}

template<class T>
void getValue(string promt, T& value)
{
    cout << promt;
    cin >> value;

    while (cin.fail())
    {
        cin.clear();
        cin.ignore(32767, '\n');
        cout << "Error...try again" << endl;

        cout << promt;
        cin >> value;
    }
    
    string endLine;
    getline(cin, endLine);

    getchar();
}
int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    
    int number;
    getValue("Введите число: ", number);

    string name;
    getValue("Введите имя: ", name);

   /* int iArr[]{ 1, 2, 4, -2, 2, 1, 7, 0 };
    int iSize = sizeof(iArr) / sizeof(int);
    
    cout << "Оригинальный iArr: " << endl;
    display<int>(iArr, iSize);

    sort(iArr, iSize);

    cout << "Отсортированный iArr: " << endl;
    display<int>(iArr, iSize);

    char cArr[]{ 'o','l','h','e','l' };
    int cSize = sizeof(cArr) / sizeof(char);

    cout << "Оригинальный cArr: " << endl;
    display<char>(cArr, cSize);

    sort(cArr, cSize);

    cout << "Отсортированный cArr: " << endl;
    display<char>(cArr, cSize);

    string sArr[]{ "one","two","three","four","five" };
    int sSize = sizeof(sArr) / sizeof(string);

    cout << "Оригинальный sArr: " << endl;
    display<string>(sArr, sSize);

    sort(sArr, sSize);

    cout << "Отсортированный sArr: " << endl;
    display<string>(sArr, sSize);*/
}