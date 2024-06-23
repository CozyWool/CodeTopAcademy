#include <iostream>
#include <string.h>
#include <Windows.h>
#include <math.h>
#include <map>
#pragma warning(disable : 4996)
using namespace std;

struct car
{
    string model;
    int price;
    string mode;
    int power;
    int speed;
    int weight;
};

enum Seasons
{
    WINTER,
    SPRING,
    SUMMER,
    AUTUMN
} b;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    char s[] = "Hello World";
    char* str = s;
    char* w = strtok(str, " ");
    while (w != NULL)
    {
        cout << w << endl;
        w = strtok(NULL, " ");
    }

    // ПО МНОГОМЕРНЫМ МАССИВАМ:

    /*cout << "\tВведите новую строку" << endl;
            newRow = new int[col];
            for (int j = 0; j < col; j++)
            {
                cout << "Введите " << j + 1 << " элемент:";
                cin >> newRow[j];
            }
    fillArr(ptrarr, row, col);
    cout << "Ваш иннциализированный двумерный массив:" << endl;
    printArr(ptrarr, row, col);

    addColArr(ptrarr, row, col, newCol, 2);
    cout << "Ваш иннциализированный двумерный массив:" << endl;
    printArr(ptrarr, row, col);

    delColArr(ptrarr, row, col, 0);
    cout << "Ваш иннциализированный двумерный массив:" << endl;
    printArr(ptrarr, row, col);

    addRowArr(ptrarr, row, col, newCol, 2);
    cout << "Ваш иннциализированный двумерный массив:" << endl;
    printArr(ptrarr, row, col);
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

	void printArr(int** ptrarr, int row, int& col)
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
	void addRowArr(int** ptrarr, int& row, int& col, int* newRow, int index)
	{
		if (ptrarr == nullptr || index < 0)
			return;

		for (int i = row; i > index; i--)
		{
			ptrarr[i] = ptrarr[i - 1];
		}
		ptrarr[index] = newRow;
		row++;
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
	*/

    /*map<int, string> mp;
    mp[0] = "Зеленый";
    mp[1] = "Желтый";
    mp[2] = "Оранжевый";
    mp[3] = "Фиолетовый";

    for (auto& ob : mp)
    {
        cout << ob.first << " => " << ob.second << endl;
    }*/

    /*bool key = true;
    int size = 2;
    car* cars = new car[size];
    string cmd;
    
    cout << "Список автомобилей:" << endl;

    while (key)
    { 
        cout << "Новый автомобиль\nВведите данные для заполнения" << endl;
        for (int i = 0; i < size; i++)
        {
            cout << "Модель:";
            cin >> cars[i].model;
            cout << "Стоимость:";
            cin >> cars[i].price;
            cout << "Режим:";
            cin >> cars[i].mode;
            cout << "Мощность двигателя:";
            cin >> cars[i].power;
            cout << "Скорость:";
            cin >> cars[i].speed;
            cout << "Масса:";
            cin >> cars[i].weight;
            cout << endl;
            cout << "Продолжить ввод?(y/n)";
            cin >> cmd;
            if (cmd == "n")
                key = false;
                break;
        }
     
    }

    system("cls");

    for (int i = 0; i < size; i++)
    {
        cout << "Модель:" << cars[i].model << endl;
        cout << "Стоимость:" << cars[i].price << endl;
        cout << "Режим:" << cars[i].mode << endl;
        cout << "Мощность двигателя:" << cars[i].power << endl;
        cout << "Скорость:" << cars[i].speed << endl;
        cout << "Масса:" << cars[i].weight << endl;
        cout << endl;
    }

    delete[] cars;*/
}



    /*int h1, m1, s1;
    int h2, m2, s2;*/

    /*int time1, time2, diffTime;

    cout << "\t\tПрограмма по подсчёту разности во времени\n" << endl;
    cout << "Введите первое время в часах, минутах и секундах:";
    cin >> h1 >> m1 >> s1;
    cout << "Введите второе время в часах, минутах и секундах:";
    cin >> h2 >> m2 >> s2;
    
    time1 = h1 * 3600 + m1 * 60 + s1;
    time2 = h2 * 3600 + m2 * 60 + s2;
    diffTime = abs(time1 - time2);

    diffH = diffTime / 3600;
    diffTime %= 3600;
    diffM = diffTime / 60;
    diffTime %= 60;
    diffS = diffTime;
    cout << "Ваша разница:" << diffH << " ч. " << diffM << " мин. " << diffS << " сек. " << endl;*/