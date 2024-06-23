#include <iostream>
#include <fstream>	
#include <string>	
#include <Windows.h>
#include <vector>
#include <algorithm>
#include "secondTask.h"

bool fileExists(std::string fileName)
{
	std::ifstream test(fileName);
	return bool(test);
}

std::vector<std::pair<size_t, size_t>> findString(std::string path, std::string lineToFind)
{
	std::ifstream in(path);
	std::string line;
	int linePos = 0;
	std::vector<std::pair<size_t, size_t>> foundPositions;

	if (!in)
	{
		std::cout << "Ошибка открытия файла!" << std::endl;		
		return foundPositions;
	}
	while (std::getline(in, line))
	{
		++linePos;
		size_t found = line.find(lineToFind);
		if (found != std::string::npos)
		{
			foundPositions.push_back(std::make_pair(linePos, found));
		}
	}
	in.close();

	return foundPositions;
}

std::vector<std::pair<size_t, size_t>> replaceString(std::string path, std::string oldString, std::string newString)
{
	std::ifstream in(path);
	std::string line;
	int linePos = 0;
	std::vector<std::pair<size_t, size_t>> replacedPositions;
	std::vector<std::string> lines;

	if (!in)
	{
		std::cout << "Ошибка открытия файла!" << std::endl;
		return replacedPositions;
	}

	while (std::getline(in, line))
	{
		++linePos;
		size_t found = line.find(oldString);
		if (found != std::string::npos)
		{
			line.replace(found, oldString.length(), newString);
			replacedPositions.push_back(std::make_pair(linePos, found));
		}
		lines.push_back(line);
	}
	in.close();

	std::ofstream out(path, std::ios::out);
	if (!out)
	{
		std::cout << "Ошибка открытия файла!" << std::endl;
		return replacedPositions;
	}

	for (std::string str : lines)
	{
		out << str << std::endl;
	}
	out.close();

	return replacedPositions;
}


void print(std::string path)
{
	std::ifstream in(path);
	std::string line;

	if (in.is_open())
	{
		std::cout << "Ошибка открытия файла!" << std::endl;
		return;
	}
	while (std::getline(in, line))
	{
		std::cout << line << std::endl;
	}
	in.close();
}

void reverseFile(std::string path)
{
	std::ifstream in(path);
	std::string line;
	std::vector<std::string> lines;

	if (!in)
	{
		while (std::getline(in, line))
		{
			lines.push_back(line);
		}
	}
	in.close();

	std::reverse(lines.begin(), lines.end());

	std::ofstream out(path, std::ios::out);
	if (!out)
	{
		std::cout << "Ошибка открытия файла!" << std::endl;
		return;
	}

	for (std::string str : lines)
	{
		out << str << std::endl;
	}

	out.close();
}

int FirstTask()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	std::string path = "";

	std::cout << "\tПриложение \"Работник с файлами\"\n" << std::endl;

	do
	{
		std::cout << "Введите путь к файлу:";
		std::cin >> path;
		if (!fileExists(path))
		{
			std::cout << "Такого файла нет!" << std::endl;
		}
	} while (!fileExists(path));

	system("cls");


	std::cout << std::endl;

	while (true)
	{
		std::cout << "\tПриложение \"Работник с файлами\"\n" << std::endl
			<< "Путь к файлу: " << path << std::endl
			<< "1 - Найти строку в файле" << std::endl
			<< "2 - Замена строки на новую строку" << std::endl
			<< "3 - Отобразить файл" << std::endl
			<< "4 - Перевернуть содержимое файла" << std::endl
			<< "0 - Выход из программы" << std::endl
			<< "Выберите действие: ";

		std::string lineToFind;
		std::string oldString;
		std::string newString;
		std::vector<std::pair<size_t, size_t>> positions;

		int t;
		std::cin >> t;

		system("cls");

		switch (t)
		{
		case 1:
			std::cout << "\tПоиск строки в файле" << path << std::endl;

			std::cout << "Введите строку для поиска: ";
			std::cin >> lineToFind;

			positions = findString(path, lineToFind);
			if (positions.empty())
			{
				std::cout << "Строка не найдена.";
				break;
			}

			std::cout << "  Статистика по поиску" << std::endl;
			std::cout << "Строка " << lineToFind << " найдена:" << positions.size() << " раз." << std::endl;
			std::cout << "  Позиции строк" << std::endl;
			for (std::pair<size_t, size_t> i : positions)
			{
				std::cout << "Строка " << i.first << " на позиции " << i.second << std::endl;
			}
			break;
		case 2:
			std::cout << "\tПоиск строки в файле" << path << std::endl;

			std::cout << "Введите строку, которую нужно заменить: ";
			std::cin >> oldString;

			std::cout << "Введите новую строку: ";
			std::cin >> newString;

			positions = replaceString(path, oldString, newString);
			if (positions.empty())
			{
				std::cout << "Строка не найдена.";
				break;
			}

			std::cout << "  Статистика по замене" << std::endl;
			std::cout << "Строка " << lineToFind << " заменена:" << positions.size() << " раз." << std::endl;
			std::cout << "  Позиции строк" << std::endl;
			for (std::pair<size_t, size_t> i : positions)
			{
				std::cout << "Строка " << i.first << " на позиции " << i.second << std::endl;
			}
			break;
		case 3:
			std::cout << "\tФайл " << path << std::endl;
			print(path);
			break;
		case 4:
			std::cout << "\tПереворот файла " << path << std::endl;
			reverseFile(path);

			std::cout << "\n\tРезультат" << std::endl;
			print(path);
			break;
		case 0:
			system("cls");
			std::cout << "\n\tДо свидания!\n\n";
			return 0;
			break;
		default:
			break;
		}

		std::cout << "\n\n";
		system("pause");
		system("cls");
	}
}

int main()
{
	Program();
}