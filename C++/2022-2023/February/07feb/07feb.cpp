#include <iostream>
#include <Windows.h>
#include <cassert>

using namespace std;

class Dyn2DArrLinear
{
private:
	int sizeX;
	int sizeY;
public:
	int** data;
	Dyn2DArrLinear(int sizeXP, int sizeYP) : sizeY{ sizeYP },
		sizeX{ sizeXP }, data{ new int* [sizeXP] }
	{
		// Выделяем блок памяти для хранения всех элементов двумерного динамического массива
		int* dataElements{ new int[sizeX * sizeY] };

		for (int x = 0; x < sizeX; x++)
		{
			//data[x] = new int[sizeY];
			data[x] = dataElements + x * sizeY;
		}
	}

	friend ostream& operator<<(ostream& out, const Dyn2DArrLinear& d)
	{
		for (int x = 0; x < d.sizeX; x++)
		{
			for (int y = 0; y < d.sizeY; y++)
			{
				out << d.data[x][y] << "\t";
			}
			out << endl;
		}
		return out;
	}

	~Dyn2DArrLinear()
	{
		delete[] data[0];
		delete[] data;
	}
};

class Matrix
{
private:
	int sizeY;
	int sizeX;
	int* data;

	int index2d(int y, int x) const
	{
		return y * sizeX + x;
	}
	int index2d(int y, int x, int sizeXP) const
	{
		return y * sizeXP + x;
	}
public:
	Matrix(int sizeYP, int sizeXP) : sizeY{ sizeYP }, 
		sizeX{ sizeXP }, 
		data{ new int[sizeYP * sizeXP] } 
	{}
	Matrix() : Matrix{1, 1} {}

	int operator()(int y, int x) const
	{
		return *(data + index2d(y, x));
	}
	int& operator()(int y, int x)
	{
		return *(data + index2d(y, x));
	}

	friend ostream& operator<<(ostream& out, const Matrix& m)
	{
		for (int y = 0; y < m.sizeY; y++)
		{
			for (int x = 0; x < m.sizeX; x++)
			{
				out << m(y,x) << "\t";
			}
			out << endl;
		}
		return out;
	}

	void deleteColumn(int columnPos)
	{
		assert((columnPos >= 0 && columnPos < sizeX) && "ColumnIndex out of range!");
		sizeX--;
		int* newData{ new int[sizeY * sizeX] };

		for (int y = 0; y < sizeY; y++)
		{
			for (int x = 0; x < sizeX; x++)
			{
				*(newData + index2d(y, x)) = *(data + index2d(y, x + (x >= columnPos),sizeX + 1));
			}
		}
		delete[] data;
		data = newData;
	}
	void addColumn(int columnPos, int* newCol = nullptr)
	{
		int* newData{ new int[sizeY * (sizeX + 1)] };

		for (int y = 0; y < sizeY; y++)
		{
			for (int x = 0; x < sizeX; x++)
			{
					*(newData + index2d(y, x + (x >= columnPos), sizeX + 1)) = *(data + index2d(y, x));
			}
			*(newData + index2d(y, columnPos, sizeX + 1)) = newCol ? *(newCol + y) : 0;
		}

		delete[] data;
		sizeX++;
		data = newData;
	}

	void deleteRow(int rowPos)
	{
		assert((rowPos >= 0 && rowPos < sizeY) && "ColumnIndex out of range!");
		sizeY--;
		int* newData{ new int[sizeY * sizeX] };

		for (int y = 0; y < sizeY; y++)
		{
			for (int x = 0; x < sizeX; x++)
			{
				*(newData + index2d(y, x)) = *(data + index2d(y + (y >= rowPos), x));
			}
		}
		delete[] data;
		data = newData;
	}
	void addRow(int rowPos, int* newRow = nullptr)
	{
		int* newData{ new int[(sizeY + 1) * sizeX]};

		for (int y = 0; y < sizeY; y++)
		{
			for (int x = 0; x < sizeX; x++)
			{
					*(newData + index2d(y + (y >= rowPos), x)) = *(data + index2d(y, x));
			}
			*(newData + index2d(rowPos, 0)) = newRow ? *(newRow + y) : 0;
		}

		delete[] data;
		sizeY++;
		data = newData;
	}

	~Matrix()
	{
		delete[] data;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
#define USER_INPUT 0;

	int rows{ 3 };
	int columns{ 3 };
	int counter{ 1 };

#if USER_INPUT
	cout << "Введите кол-во строк матрицы: ";
	cin >> rows;
	cout << "Введите кол-во столбцов матрицы: ";
	cin >> columns;
#endif

	Matrix m{ rows,columns };
	for (int y = 0; y < rows; y++)
	{
		for (int x = 0; x < columns; x++)
		{
			m(y, x) = counter++;
		}
	}

	cout << m << endl;

	//m.deleteColumn(2);
 	cout << m << endl;

	int* newColumn{ new int[columns] {10,11,12} };
	int* newRow{ new int[rows] {20,21,22} };
	//m.addColumn(0,newColumn);
	//m.addRow(0,newRow);
	m.deleteRow(0);
	cout << m << endl;

	delete[] newColumn;
	delete[] newRow;
	/*const int sizeX = 3;
	const int sizeY = 3;
	int** data = new int* [sizeX];
	int* dataElements{ new int[sizeX * sizeY] };

	cout << "DataElements: " << dataElements << endl << endl;
	
	for (int x = 0; x < sizeX; x++)
	{
		cout << "data[" << x << "]: " << dataElements + x * sizeY << endl;

		data[x] = dataElements + x * sizeY;
	}

	cout << "DataElements + 1: " << dataElements + 1 << endl;
	cout << "DataElements + 2: " << dataElements + 2 << endl;
	cout << "DataElements + 3: " << dataElements + 3 << endl;
	cout << "DataElements + 4: " << dataElements + 4 << endl;
	cout << "DataElements + 5: " << dataElements + 5 << endl;

	int rows{ 3 };
	int columns{ 3 };
	int counter{ 1 };

	Dyn2DArrLinear arr2d{ rows,columns };

	for (int x = 0; x < rows; x++)
	{
		for (int y = 0; y < columns; y++)
		{
			arr2d.data[x][y] = counter++;
		}
	}

	cout << arr2d << endl;*/

}

//#include <iostream>
//#include <Windows.h>
//#include <cassert>
//
//using namespace std;
//
//class Point
//{
//private:
//	double x;
//	double y;
//public:
//	Point(double x, double a, double b, double c) : x{ x }
//	{
//		y = calcY(x, a, b, c);
//	}
//	Point() : Point{ 0,0,1,0 } {}
//	Point(const Point& obj) : x{ obj.x }, y{ obj.y } {}
//	Point(Point&& obj) noexcept : x{ obj.x }, y{ obj.y }
//	{
//		obj.x = 0;
//		obj.y = 0;
//	}
//
//	double getX() { return x; }
//	double getY() { return y; }
//
//	void setX(double xP, double a, double b, double c) 
//	{
//		if (x != xP)
//		{
//			x = xP;
//			y = calcY(x, a, b, c);
//		}
//	}
//
//	friend ostream& operator<<(ostream& out, const Point& p)
//	{
//		out << "(" << p.x << ";" << p.y << ")";
//		return out;
//	}
//
//	double calcY(double x, double a, double b, double c)
//	{
//		assert(x + b != 0 && "Division by zero(x + b = 0)");
//		return y = a / (x + b) + c;
//	}
//};
//
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//
//	Point p1;
//	cout << p1 << endl;
//}