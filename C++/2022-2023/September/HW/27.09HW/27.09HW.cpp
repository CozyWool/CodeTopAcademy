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
template <typename T>
void printArr(T** ptrarr, int row, int col)
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
void transportArr(int**& ptrarr, int row, int col)
{
	if (ptrarr == nullptr)
		return;
	int** newPtrArr = new int* [col];
	int i1 = 0;
	int j1 = 0;
	for (int i = 0; i < col; i++)
	{
		newPtrArr[i] = new int[col];
	}
	while (j1 < col)
	{
		for (int j = 0; j < col; j++)
		{
			newPtrArr[i1][j] = ptrarr[j][j1];
		}
		i1++;
		j1++;
	}
	ptrarr = newPtrArr;
}
string searchByName(string**& phonearr, int size, string name) 
{
	for (int i = 0; i < size; i++) // не особо помню как сделать это оптимизированее, как-то через указатель и цикл while
	{
		if (phonearr[i][0] == name)
		{
			return phonearr[i][1];
		}
	}
}
string searchByNumber(string**& phonearr, int size, string number) 
{
	for (int i = 0; i < size; i++)
	{
		if (phonearr[i][1] == number)
		{
			return phonearr[i][0];
		}
	}
}
void changeElement(string**& phonearr, int size, int index, int index2,string newStr)
{
	index2 == 1 ? phonearr[index][0] = newStr : phonearr[index][1] = newStr;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int row = 5;
	int col = 5;
	int size = 2;
	int cmd;
	string answer;
	int index;
	int index2;

	int* newCol = nullptr;
	int* newRow = new int[col];
	
	int** ptrarr = new int* [row];
	string** phonearr = new string*[size];

	for (int i = 0; i < row; i++)
	{
		ptrarr[i] = new int[col];
	}
	for (int i = 0; i < size; i++)
	{
		phonearr[i] = new string[2];
	}

	cout << "Многомерные динамические массивы\nДомашенее задание №2\n" << endl;

	fillArr(ptrarr, row, col);

	bool key = true;
	while (key)
	{
		cout << "Введите номер задания от 1 до 2(0 для выхода):";
		cin >> cmd;
		system("cls");
		switch (cmd)
		{
		case 1:
			printArr(ptrarr, row, col);
			cout << "\n\tТранспортирование матрицы" << endl;
			transportArr(ptrarr, row, col);
			cout << "Ваш иннциализированный двумерный массив:" << endl;
			printArr(ptrarr, row, col);
			break;
		case 2:
			cout << "\n\tЗаполните список владельцев и их номеров" << endl;
			for (int i = 0; i < size; i++)
			{
				cout << "Введите имя владельца №" << i + 1 << " телефона: ";
				cin >> phonearr[i][0];
				cout << "Введите номер телефона \"" << phonearr[i][0] << "\": ";
				cin >> phonearr[i][1];
				cout << endl;
			}
			cout << "Ваш иннциализированный список:" << endl;
			printArr(phonearr, size, 2);

			cout << "\n\tПоиск по имени" << endl;
			cout << "Введите имя, по которому нужно найти номер телефона: ";
			cin >> answer;
			cout << "Номер телефона владельца \"" << answer << "\": " << searchByName(phonearr, size, answer) << endl;

			cout << "\n\tПоиск по номеру телефона" << endl;
			cout << "Введите номер телефона, по которому нужно найти владельца: ";
			cin >> answer;
			cout << "Имя владельца с номером телефона \"" << answer << "\": " << searchByNumber(phonearr, size, answer) << endl;

			cout << "\n\tИзменение данных в списке" << endl;
			cout << "Введите номер объекта, который нужно заменить(1-" << size << "): ";
			cin >> index;
			index--;
			cout << "Что вы хотите заменить?(1 - имя, 2 - номер телефона): ";
			cin >> index2;
			cout << (index2 == 1 ? "Введите новое имя владельца c номером телефона \"" + phonearr[index][1] + "\": " : "Введите новый номер телефона владельца\"" + phonearr[index][0] + "\": ");
			cin >> answer;

			changeElement(phonearr, size, index, index2, answer);

			cout << "Ваш иннциализированный список:" << endl;
			printArr(phonearr, size, 2);
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
	delete[] phonearr;
}