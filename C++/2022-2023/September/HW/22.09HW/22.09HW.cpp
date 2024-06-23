#include <iostream>
#include <Windows.h>

using namespace std;

void fillArr(int** ptrarr, int row, int col)
{
	if (ptrarr == nullptr)
		return;

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			ptrarr[i][j] = (i + 1) * 10 + (j + 1);
		}
	}
}
void printArr(int** ptrarr, int row, int col)
{
	if (ptrarr == nullptr)
		return;

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
		return;

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
void delColArr(int** ptrarr, int row, int& col, int index)
{
	if (ptrarr == nullptr || index < 0)
		return;

	for (int i = 0; i < row; i++)
	{
		for (int j = index; j < col - 1; j++)
		{
			ptrarr[i][j] = ptrarr[i][j + 1];
		}
	}
	col--;
}
void moveArr(int** ptrarr, int row, int col, char dir)
{
	if (ptrarr == nullptr)
		return;
	int* temp = nullptr;
	switch (dir)
	{
	case 'u':
		temp = new int[col];

		for (int j = 0; j < col; j++)
		{
			temp[j] = ptrarr[0][j];
		}
		for (int i = 0; i < row - 1; i++)
		{
			for (int j = 0; j < col; j++)
			{
				ptrarr[i][j] = ptrarr[i + 1][j];
			}
		}
		for (int j = 0; j < col; j++)
		{
			ptrarr[row - 1][j] = temp[j];
		}
		break;

	case 'd':
		temp = new int[col];

		for (int j = 0; j < col; j++)
		{
			temp[j] = ptrarr[row - 1][j];
		}
		for (int i = row - 1; i > 0; i--)
		{
			for (int j = 0; j < col; j++)
			{
				ptrarr[i][j] = ptrarr[i - 1][j];
			}
		}
		for (int j = 0; j < col; j++)
		{
			ptrarr[0][j] = temp[j];
		}
		break;

	case 'r':
		temp = new int[row];

		for (int i = 0; i < row; i++)
		{
			temp[i] = ptrarr[i][0];
		}
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col - 1; j++)
			{
				ptrarr[i][j] = ptrarr[i][j + 1];
			}
		}
		for (int i = 0; i < row; i++)
		{
			ptrarr[i][col - 1] = temp[i];
		}
		break;

	case 'l':
		temp = new int[row];

		for (int i = 0; i < row; i++)
		{
			temp[i] = ptrarr[i][col - 1];
		}
		for (int i = 0; i < row; i++)
		{
			for (int j = col - 1; j > 0; j--)
			{
				ptrarr[i][j] = ptrarr[i][j - 1];
			}
		}
		for (int i = 0; i < row; i++)
		{
			ptrarr[i][0] = temp[i];
		}
		break;
		
	default:
		break;
	}
	delete[] temp;
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int row = 5;
	int col = 5;
	int cmd;
	int index;
	char dir;

	int* newCol = nullptr;
	int* newRow = new int[col];

	int** ptrarr = new int* [row];
	for (int i = 0; i < row; i++)
	{
		ptrarr[i] = new int[col];
	}
	
	cout << "Многомерные динамические массивы\nДомашенее задание №1\n" << endl;

	fillArr(ptrarr, row, col);

	bool key = true;
	while (key)
	{
		cout << "Введите номер задания от 1 до 3(0 для выхода):";
		cin >> cmd;
		system("cls");
		printArr(ptrarr, row, col);
		switch (cmd)
		{
		case 1:
			cout << "\tВведите новый столбец" << endl;
			newCol = new int[row];
			for (int i = 0; i < row; i++)
			{
				cout << "Введите " << i + 1 << " элемент:";
				cin >> newCol[i];
			}
			cout << "Введите позицию нового столбца (1-" << col << "):";
			cin >> index;
			addColArr(ptrarr, row, col, newCol, index - 1);
			cout << "Ваш иннциализированный двумерный массив:" << endl;
			printArr(ptrarr, row, col);
			break;
		case 2:
			
			cout << "Введите позицию столбца, который нужно удалить (1-" << col << "):";
			cin >> index;
			delColArr(ptrarr, row, col, index - 1);
			cout << "Ваш иннциализированный двумерный массив:" << endl;
			printArr(ptrarr, row, col);
			break;
		case 3:
			do
			{
				cout << "В каком направлении вы хотите сместить строку/столбец?(u - вверх,d - вниз, l - влево, r - вправо):";
				cin >> dir;
			} while (dir != 'r' && dir != 'l' && dir != 'u' && dir != 'd');
			
			if (dir == 'u' || dir == 'd')
			{
				do
				{
					cout << "Введите сколько раз нужно переместить вверх/вниз:";
					cin >> index;
				} while (index < 1 || index > row);
			}

			if (dir == 'r' || dir == 'l')
			do
			{
				cout << "Введите сколько раз нужно переместить влево/вправо:";
				cin >> index;
			} while (index < 1 || index > col);

			for (int i = 0; i < index; i++)
				moveArr(ptrarr, row, col, dir);

			cout << "Ваш иннциализированный двумерный массив:" << endl;
			printArr(ptrarr, row, col);
			break;
		case 0:
			key = false;
			cout << "\t\nДо свидания!" << endl;
			break;
		default:
			cout << "Нет такого задания!" << endl;
			break;
		}
	}
	delete[] ptrarr;
	delete[] newCol;
	delete[] newRow;
}