#include "Array.h"

Array::Array(int sizeP) : size{ sizeP }, arr{ new char[size] } {}

Array::Array() : Array{ 20 } {}

Array::Array(const Array& a) : size{ a.size }, arr{ new char[size]} 
{
	for (int i = 0; i < size; i++)
	{
		arr[i] = a.arr[i];
	}
}
Array::~Array()
{
	delete[] arr;
}

int Array::length() const
{
	return size;
}

void Array::printFigure()
{
	Array* array = new Array[size];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (i >= j && i + j <= size - 1)
			{
				array[i][j] = '*';
			}
			else
			{
				array[i][j] = '-';
			}
		}
	}
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
			cout << array[i][j] << " ";
		cout << endl;
	}
	delete[] array;
}

const Array& Array::operator=(const Array& a)
{
	if (this != &a)
	{
		if (size != a.size)
		{
			delete[] arr;
			size = a.size;
			arr = new char[size];
		}
		for (int i = 0; i < size; i++)
		{
			arr[i] = a.arr[i];
		}
	}
	return *this;
}

bool Array::operator==(const Array& a) const
{
	if (a.size != size)
		return 0;
	for (int i = 0; i < size; i++)
	{
		if (a.arr[i] != arr[i])
		{
			return 0;
		}
	}
	return 1;
}

bool Array::operator!=(const Array& a) const
{
	return !(*this == a);
}

char& Array::operator[](int index)
{
	if (index < 0 || index >= size)
	{
		cout << "Out of range" << endl;
		exit(1);
	}
	return arr[index];
}

char Array::operator[](int index) const
{
	if (index < 0 || index >= size)
	{
		cout << "Out of range" << endl;
		exit(1);
	}
	return arr[index];
}

ostream& operator<<(ostream& output, const Array& a)
{
	for (int i = 0; i < a.length(); i++)
	{
		output << a[i] << " ";
	}
	output << endl;
	return output;
}

istream& operator>>(istream& input, Array& a)
{
	for (int i = 0; i < a.length(); i++)
	{
		cout << "Введите " << i + 1 << " элемент масcива: ";
		input >> a[i];
	}
	return input;
}