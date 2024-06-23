#include <iostream>
#include <Windows.h>
#include <vector>

using namespace std;

struct Book
{
    string name;
    string author;
    string publisher;
    string genre;
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
   
	cout << "Структуры\nДомашенее задание №2\n" << endl;

	vector<Book> books;
	int cmd;
	bool key = true;
	while (key)
	{
		cout << "Список команд:" << endl <<
			"1 - Изменить книгу" << endl <<
			"2 - Вывести все книги" << endl <<
			"3 - Поиск книг по автору" << endl <<
			"4 - Поиск книги по названию" << endl <<
			"5 - Соритровка по названию книг" << endl <<
			"6 - Соритровака по автору" << endl <<
			"7 - Сортировка по издательству" << endl <<
			"0 - Выйти из программы" << endl;
		cout << "Введите команду:";
		cin >> cmd;
		system("cls");
		switch (cmd)
		{
		case 1:

			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		case 0:
			key = false;
			cout << "\t\nДо свидания!" << endl;
			break;
		default:
			cout << "Нет такой команды!" << endl;
			break;
		}
	}
}
