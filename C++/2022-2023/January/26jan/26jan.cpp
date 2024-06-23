#include <iostream>
//#include <Windows.h>

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
    //DynArray(const DynArray& object) : arr{ new int[object.size] }, size{ object.size } // Конструктор копирования, константная ссылка на экземпляр
    //{
    //    for (int i{ 0 }; i < size; i++)
    //    {
    //        arr[i] = object.arr[i];
    //    }
    //    cout << "DynArray copy constructed for " << size << " elements, for " << this << endl;
    //}
    DynArray(const DynArray& object) = delete;
    DynArray(DynArray&& object) noexcept : arr{ object.arr }, size{ object.size } // Конструктор копирования, константная ссылка на экземпляр
    {
        object.arr = nullptr;
        object.size = 0;
        cout << "DynArray move constructed for " << size << " elements, for " << this << endl;
    }

    //DynArray& operator=(const DynArray& object) // Перегрузка оператора, константная ссылка на экземпляр
    //{
    //    if (!(this == &object)) // Указатель на текущий экземпляр(this)
    //    {
    //        if (size != object.size)
    //        {
    //            delete[] arr;
    //            arr = new int[object.size];
    //        }
    //        size = object.size;
    //        for (int i{ 0 }; i < size; i++)
    //        {
    //            arr[i] = object.arr[i];
    //        }
    //        cout << "DynArray copy assigned for " << size << " elements, for " << this << endl;
    //    }
    //    return *this;
    //}
    DynArray& operator=(const DynArray& object) = delete;
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

    int getElem(int idx) const  // Константный метод
    {
        if (idx < 0 || idx >= size)
        {
            cout << "Out of range" << endl;
            exit(1);
        }
        return arr[idx];
    }

    void setElem(int idx, int value)
    {
        if (idx < 0 || idx >= size)
        {
            cout << "Out of range" << endl;
            exit(1);
        }
        arr[idx] = value;
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

class Point
{
private:
	int x;
	int y;
public:
	explicit Point(int x, int y) : x{ x }, y{ y } {}
	Point() = default;

	Point& setX(int x) 
	{
		this->x = x;
		return *this;
	}
	Point& setY(int y)
	{
		this->y = y;
		return *this;
	}

    Point& setX(double x) = delete;
    Point& setY(double y) = delete;

	int getX() { return x; }
	int getY() { return y; }

	friend ostream& operator<<(ostream& out, const Point& p)
	{
		out << "(" << p.x << ";" << p.y << ")";
		return out;
	}
};

int maxx(int a, int b)
{
    return a > b ? a : b;
}
template <typename T1>
int maxx(T1 a, T1 b) { return a > b ? a : b; }
template <typename T1, typename T2>
int maxx(T1 a, T2 b) = delete;


int main()
{
    int size = 20;
    char* a = new char[size]{ 'A', 'a', 'a', 'a','a','a','b', 'b', 'B', 'b', 'C', 'C', 'c', 'a', 'a' };
    for (int i = 0; i < size; i++)
    {
        cout << a[i] << " ";
    }
    cout << endl;
    for (int i = 1; i < size - 1; i++)
    {
        if (a[i - 1] == a[i] && a[i + 1] == a[i])
        {
            for (int j = i - 1; j < size - 2; j++)
            {
                a[j] = a[j + 2];    
            }
        }
    }
    for (int i = 0; i < size; i++)
    {
        cout << a[i] << " ";
    }
    cout << endl;
    delete[] a;
    /*cout << maxx(1, 5) << endl;
    cout << maxx(20.5, 30) << endl;
    cout << maxx(true, false) << endl;
    cout << maxx(true, 'f') << endl;*/

    /*Point p1{};
    Point p2{ 30,40 };

    p1.setX(24.07).setY(35.58); 

    cout << "p1: " << p1 << endl;
    cout << "p2: " << p2 << endl;*/
    /*DynArray arr1{ arrayFactory(10) };
    DynArray arr2{ arrayFactory(20) };

    cout << "arr1: " << arr1 << endl;

    cout << "arr2: " << arr2 << endl;*/
}