#include <iostream>
#include <Windows.h>
#include <malloc.h>
#include <assert.h>
#include <conio.h>
#include <typeinfo>

using namespace std;


template<class T>
void print(T* arr)
{
	size_t size = _msize(arr) / sizeof(T);
	for (size_t i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}

void stopProgram(string message)
{
	cout << message << endl;
	cout << "Нажмите любую клавишу, чтобы выйти из программы" << endl;
	_getch();
	exit(1);
}

template<typename T>
class Array
{
	T* array;
	size_t size{ 5 };
public:
	Array(size_t size, T* arrayP) : size{ size }, array{ new T[size] }
	{
		if (arrayP)
		{
			for (size_t i = 0; i < size; i++)
			{
				this->array[i] = arrayP[i];
			}
			return;
		}
		//array = nullptr;
		for (size_t i = 0; i < size; i++)
		{
			this->array[i] = T();
		}
	}
	Array(size_t size) : Array(size, nullptr) {}
	Array() : Array(5, nullptr) {}
	~Array()
	{
		if (array)
			delete[] array;
	}

	/*T getItem(size_t index) const 
	{ 
		if (index < 0 && index >= size)
			stopProgram("Index out or range");
		return array[index];
	}
	void setItem(size_t index, T value)
	{
		if (index < 0 && index >= size)
			stopProgram("Index out or range");
		array[index] = value;
	}*/
	T getAverage()
	{
		double sum = 0;

		for (size_t i = 0; i < size; i++)
		{
			sum += array[i];
		}
		return sum / size;
	}
	bool isEmpty()
	{
		return !array;
	}

	size_t getSize() const { return size; }

	T& operator[](size_t index)
	{
		if (index < 0 && index >= size)
			stopProgram("Index out or range");
		return array[index];
	}
	T operator[](size_t index) const
	{
		if (index < 0 && index >= size)
			stopProgram("Index out or range");
		return array[index];
	}

	friend ostream& operator<<(ostream& out, const Array& a)
	{
		if (a.array)
		{
			for (size_t i = 0; i < a.size; i++)
			{
				out << a.array[i] << " ";
			}
			out << endl;
		}
		return out;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	size_t size = 3;
	Array<int> iArr{ size,new int[size] {5,4,5} };
	Array<string> sArr{ size};

	cout << "Массив чисел: " << iArr << endl;
	cout << "Среднее арифметическое массива чисел: " << iArr.getAverage() << endl;

	cout << "Массив строк: " << sArr << endl;
	cout << "Пустой ли массив строк?: " << sArr.isEmpty() << endl;
}