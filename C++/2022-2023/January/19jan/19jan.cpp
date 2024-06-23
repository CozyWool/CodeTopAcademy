#include <iostream>
#include <Windows.h>

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
        }

        return *this;
    }
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

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    DynArray arr4{ arrayFactory(10) };
    cout << "arr4 elements: " << arr4 << endl;

    DynArray arr5{ arrayFactory(10) };
    cout << "arr5 elements: " << arr5 << endl;

    cout << "arr5 = arr4. \n";
    arr5 = move(arr4);
    cout << "arr5 elements: " << arr5 << endl;
    cout << "arr4 elements: " << arr4 << endl;
}