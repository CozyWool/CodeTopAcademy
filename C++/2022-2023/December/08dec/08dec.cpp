#include <iostream>
#include <Windows.h>

using namespace std;

class DynArray
{
private:
	int* arr;
	int size;
public:
	DynArray(int sizeP) : arr{new int[sizeP]}, size{sizeP} 
	{
		cout << "DynArray constructed for " << size << " elements,for " << this << endl;
	}
	DynArray() : DynArray(5) {}
	DynArray(const DynArray& object) : arr{ new int[object.size] }, size{ object.size }
	{
		for (int i = 0; i < size; i++)
		{
			arr[i] = object.arr[i];
		}
		cout << "DynArray copy constructed for " << size << " elements,for " << this << endl;
	}
	~DynArray() 
	{
		cout << "Try to free memory from DynArray for " << arr << " pointer" << endl;
		delete[] arr;
		cout << "DynArray destructed for " << size << " elements,for " << this << endl;
	}

	int getElem(int index) { return arr[index]; }
	DynArray& setElem(int index, int value);
	DynArray& print();
	DynArray& randomize();

	/*1. void printArray(DynArray array) - при передаче экземпляра класса в качестве параметра функции, происходит создание
		нового экземпляра класса, используя конструктор копирования
	2. - в случае возврата экземпляра класса из функции, так же создается копия экземпляра класса
	DynArray createArray(int size) 
	{
		DynArray arr{ size };
		arr.randomize();
		return arr;
	}*/

};

DynArray& DynArray::setElem(int index, int value)
{
	arr[index] = value;
	return *this;
}
DynArray& DynArray::print()
{
	for (int i = 0; i < size; i++)
		cout << arr[i] << " ";
	cout << endl;
	return *this;
}
DynArray& DynArray::randomize()
{
	for (int i = 0; i < size; i++)
		arr[i] = rand() % 10;
	return *this;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	DynArray arr1{ 10 };
	arr1.randomize();
	cout << "arr1 elements: ";
	arr1.print();

	DynArray arr2{ arr1 };
	cout << "arr2 elements: ";
	arr2.print();
}
//class Fraction
//{
//private:
//	int numerator;
//	int denominator;
//public:
//	Fraction(const Fraction& fract) : numerator{ fract.numerator }, denominator{ fract.denominator }
//	{
//		cout << "Fraction copy constructed for " << this << endl;
//	}
//
//	Fraction(int num, int denom) : numerator{ num }, denominator{ denom }
//	{
//		cout << "Fraction constructed for " << this << endl;
//	}
//	Fraction() : Fraction{ 1,1 } {}
//	~Fraction()
//	{
//		cout << "Fraction destructed for " << this << endl;
//	}
//	void print()
//	{
//		cout << "(" << numerator << "/" << denominator << ")" << endl;
//	}
//};
//
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//
//	Fraction a{ 2,3 };
//	Fraction b{ a };
//
//	/*Fraction a{ Fraction{4,6} };*/
//
//	cout << "a = ";
//	a.print();
//	cout << "b = ";
//	b.print();
//}


//#include <iostream>
//#include <Windows.h>
//#include <math.h>
//
//using namespace std;
//
//double discriminant(double a, double b, double c)
//{
//	return b*b - 4 * a * c;
//}
//double* findRootByDis(double a, double b, double d, int size)
//{
//	double* result = new double[size];
//	switch (size)
//	{
//	case 1:
//		result[0] = (-b) / (2 * a);
//		break;
//	case 2:
//		result[0] = (-b + sqrt(d)) / (2 * a);
//		result[1] = (-b - sqrt(d)) / (2 * a);
//		break;
//	default:
//		return nullptr;
//		break;
//	}
//	return result;
//}
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	double a, b, c;
//	double* roots;
//	cout << "Введите коэффецент a:";
//	cin >> a;
//	cout << "Введите коэффецент b:";
//	cin >> b;
//	cout << "Введите коэффецент c:";
//	cin >> c;
//
//	double d = discriminant(a, b, c);
//	int size = d == 0 ? 1 : 2;
//	roots = findRootByDis(a, b, d, size);
//	if (roots != nullptr)
//	{
//		for (int i = 0; i < size; i++)
//		{
//			cout << "Корень: " << roots[i] << endl;
//		}
//		cout << endl;
//	}
//	else
//	{
//		cout << "Корней нет" << endl;
//	}
//}