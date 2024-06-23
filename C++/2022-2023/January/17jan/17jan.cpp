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
    srand(time(NULL));

    //int size = 10;
    ///*DynArray arr1{ size };
    //arr1.randomize();
    //cout << "arr1 elements: " << arr1 << endl;

    //DynArray arr2{ arr1 };
    //cout << "arr2 elements: " << arr2 << endl;

    //DynArray arr3{ 5 };
    //cout << "arr3 elements before copy: " << arr3 << endl;
    //arr3 = arr2;
    //cout << "arr3 elements after copy: " << arr3 << endl;*/

    //DynArray arr4{ arrayFactory(size) };
    //cout << "arr4 elements: " << arr4 << endl;

    /*int x{ 42 };
    int& refX{ x };
    const int& cRefX{ x };
    const int& cRefX2{ x + 24 };

    refX = 100;

    cout << x << endl;
    cout << refX << endl;
    cout << cRefX << endl;
    cout << cRefX2 << endl;*/

    /*int&& rvalRef{ 2 + 3 };
    rvalRef += 3;
    cout << rvalRef << endl;

    int&& res{ max(3,5) };
    res += max(6, 4);

    cout << res << endl;

    int& lvalRef{ res };
    cout << lvalRef << endl;*/

   /* int x{ 42 };
    int&& rvalBad{ x };
    int&& rvalBad2{ res };*/
   int x{ 42 };
   int&& rvalRef{ move(x) };
   cout << rvalRef << endl;

}