#include <iostream>
#include <Windows.h>
#include "Array.h"

using namespace std;

class DynArray 
{
    int* arr;
    int size;
public: // Модификатор доступа
    DynArray(int sizeP) : arr{ new int[sizeP] }, size{ sizeP } {}

    DynArray() : DynArray(5) {} // Конструктор по умолчанию, делигирование
    DynArray(const DynArray& object) : arr{ new int[object.size] }, size{ object.size } // Конструктор копирования, константная ссылка на экземпляр
    {
        for (int i{ 0 }; i < size; i++)
        {
            arr[i] = object.arr[i];
        }
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
        }
        return *this;
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
    friend ostream& operator<<(ostream& out, const DynArray& arr)
    {
        for (int i = 0; i < arr.size; i++)
        {
            out << arr.arr[i] << " ";
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

    ~DynArray() // Деструктор
    {
        delete[] arr;
    }
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
    srand(time(NULL));

    int size = 10;
    DynArray arr1{ size };
    arr1.randomize();
    cout << "arr1 elements: " << arr1 << endl;

    DynArray arr2{ arr1 };
    cout << "arr2 elements: " << arr2 << endl;

    DynArray arr3{ 5 };
    cout << "arr3 elements before copy: " << arr3 << endl;
    arr3 = arr2;
    cout << "arr3 elements after copy: " << arr3 << endl;
   /* Array array{ size };
    array.printFigure();*/
}