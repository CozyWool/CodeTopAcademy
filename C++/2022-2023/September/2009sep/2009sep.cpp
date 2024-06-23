#include <iostream>
#include <Windows.h>

using namespace std;

void fillArr(int** ptrarr, int row, int col)
{
	if (ptrarr == nullptr)
	{
		return;
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			ptrarr[i][j] = (i + 1) * 10 + (j + 1);
		}
	}
}

void printArr(int** ptrarr, int row, int& col)
{
	if (ptrarr == nullptr)
	{
		return;
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			cout << ptrarr[i][j];
			if (j != col - 1) {
				cout << " ";
			}
		}
		cout << endl;
	}
}

void addColArr(int** ptrarr, int row, int& col, int* newCol, int index)
{
	if (ptrarr == nullptr)
	{
		return;
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = col; j > index; j--)
		{
			ptrarr[i][j] = ptrarr[i][j - 1];
		}
		ptrarr[i][index] = newCol[i];
	}
	col++;
}
void addRowArr(int** ptrarr, int& row, int& col, int* newRow, int index)
{
	if (ptrarr == nullptr)
	{
		return;
	}

	for (int i = row; i > index; i--)
	{
		ptrarr[i] = ptrarr[i - 1];
	}
	ptrarr[index] = newRow;
	row++;
}
void delColArr(int** ptrarr, int row, int& col, int index)
{
	if (ptrarr == nullptr)
	{
		return;
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = index; j < col - 1; j++)
		{
			ptrarr[i][j] = ptrarr[i][j + 1];
		}
	}
	col--;
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int row = 5;
	int col = 5;

	int** ptrarr = new int* [row];
	for (int i = 0; i < row; i++)
	{
		ptrarr[i] = new int[col];
	}

	cout << "Многомерные динамические массивы\nДомашенее задание №1\n" << endl;

	fillArr(ptrarr, row, col);
	cout << "Ваш иннциализированный двумерный массив:" << endl;
	printArr(ptrarr, row, col);

	int* newCol = new int[col] {00, 00, 00, 00, 00};
	addColArr(ptrarr, row, col, newCol, 2);
	cout << "Ваш иннциализированный двумерный массив:" << endl;
	printArr(ptrarr, row, col);

	delColArr(ptrarr, row, col, 0);
	cout << "Ваш иннциализированный двумерный массив:" << endl;
	printArr(ptrarr, row, col);

	int* newRow = new int[row] {00, 00, 00, 00, 00};
	addRowArr(ptrarr, row, col, newCol, 2);
	cout << "Ваш иннциализированный двумерный массив:" << endl;
	printArr(ptrarr, row, col);
}