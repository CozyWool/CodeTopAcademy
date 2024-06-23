#include <iostream>
#include <vector>
#include <list>
#include "User.h"
#include "Game.h"
#include <fstream>
#include <sstream>
using namespace std;

void addUser(User u);
bool findUser(string nickname);
void printUsers();
int main()
{
	User u;
	setlocale(0, "");
	while (true)
	{
		int choice;
		cout << "Что вы хотите сделать?\n1 - ввести данные о пользователе\n2 - сохранить\n3 - вывести информацию о пользователе по критерию никнейма\n4 - вывести всех пользователей\n";
		cin >> choice;
		switch (choice)
		{
		case 1:
		{
			u.SetOnKeyboard();
			break;
		}
		case 2:
		{
			addUser(u);
			u.achievements.clear();
			cout << "Пользователь добавлен" << endl;
			break;
		}
		case 3:
		{
			string nickname;
			cout << "Введите имя требуемого пользователя:";
			cin >> nickname;
			if (!findUser(nickname))
				cout << "Пользователь не найден" << endl;
			break;
		}
		case 4:
		{
			cout << "\n----------------------------------\n" << endl;
			printUsers();
			break;
		}
		default:
			break;
		}
	}
}
void addUser(User u)
{
	string path = "Users.txt";
	ofstream ofs;
	ofs.open(path, ofstream::app);
	ofs << u.nickname << "," << u.country << "," << u.age << ",";
	for (int i = 0; i < u.achievements.size(); i++)
	{
		ofs << u.achievements[i] << ",";
	}
	u.achievements.clear();
	ofs << "\n";
	ofs.close();
}
bool findUser(string nickname)
{
	ifstream ifs;
	ifs.open("Users.txt");
	if (ifs.is_open())
	{
		User u;
		string line = "";
		int i = 0;
		while (getline(ifs, line))
		{
			vector<string> ach;
			string name;
			string counrty;
			int age;
			string temp;
			stringstream ifsString(line);
			getline(ifsString, name, ',');
			if (name != nickname)
				continue;
			getline(ifsString, counrty, ',');
			getline(ifsString, temp, ',');
			age = stoi(temp);
			while (getline(ifsString, temp, ','))
			{
				string a;
				stringstream ifsString2(temp);
				getline(ifsString2, a, ',');
				ach.push_back(a);
			}
			u.Set(name, ach, counrty, age);
			if (name == nickname)
			{
				cout << "\nПользователь найден:\n----------------------------------\n" << endl;
				u.Print();
				return true;
			}
		}
		return false;
	}
	else
	{
		cout << "Произошла ошибка во время открытия файла" << endl;
	}
	ifs.close();
}
void printUsers()
{
	ifstream ifs;
	ifs.open("Users.txt");
	if (ifs.is_open())
	{
		string line = "";
		while (getline(ifs, line))
		{
			User u;
			vector<string> ach;
			string name;
			string counrty;
			int age;
			string temp;
			stringstream ifsString(line);
			getline(ifsString, name, ',');
			getline(ifsString, counrty, ',');
			getline(ifsString, temp, ',');
			age = stoi(temp);
			while (getline(ifsString, temp, ','))
			{
				string a;
				stringstream ifsString2(temp);
				getline(ifsString2, a, ',');
				ach.push_back(a);
			}
			u.Set(name, ach, counrty, age);
			u.Print();
		}
	}
}