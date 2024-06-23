#include <iostream>
#include <Windows.h>
#include <typeinfo>

using namespace std;

class Date
{
private:
	int day;
	int month;
	int year;
public:
	Date(int d, int m, int y) : day{ d }, month{ m }, year{ y } {}
	Date(int y) : Date{ 1,1,y } {}

	friend void displayDate(Date date)
	{
		cout << date.day << "." << date.month << "." << date.year << endl;
	}
};
Date baseDate()
{
	return 2000;
}

class Array
{
private:
	int size;
	int* array;
public:	
	explicit Array(int size = 10);
	~Array();
	int getSize() const;
	int getValue(int index) const;
	void setValue(int index, int value);
	void display(int index) const;
};

Array::Array(int size)
{
	Array::size = size;
	array = new int[size];
}

Array::~Array()
{
	delete[] array;
}

int Array::getSize() const
{
	return size;
}

int Array::getValue(int index) const
{
	return array[index];
}

void Array::setValue(int index, int value)
{
	array[index] = value;
}

void Array::display(int index) const
{
	cout << array[index] << " ";
}

void display(const Array& array)
{
	for (int i = 0; i < array.getSize(); i++)
	{
		array.display(i);
	}
	cout << endl;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	cout << "Динамический массив целых чисел:\n\n";
	int size = 4;
	Array array(size);

	for (int i = 0; i < size; i++)
	{
		array.setValue(i, size - i);
	}
	display(array);

	cout << "!!!" << endl;
	display(Array(3));
	/*displayDate(Date(12, 10, 2020));
	Date date1 = 2010;
	displayDate(date1);
	Date date2 = baseDate();
	displayDate(date2);*/
}