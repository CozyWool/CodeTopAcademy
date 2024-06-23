#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <string>
#include <stdio.h>
#include <fstream>
#include <algorithm>

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	cout << "Файлы\nДомашенее задание №1\n" << endl;

	ifstream in;
	ofstream out;

	string str;
	string newStr;
	string word;
	string wordToReplace;

	int count = 0;
	int maxLen = 0;

	int cmd;
	bool key = true;

	while (key)
	{
		cout << "Введите номер задания от 1 до 4(0 - выход):";
		cin >> cmd;
		system("cls");
		switch (cmd)
		{
		case 1:
			in.open("text1.txt");
			out.open("textWithoutLastString.txt");

			if (in.is_open()) {
				while (getline(in, str))
				{
					if(in.eof())
					{
						break;
					}
					out << str << endl;
				}
			}

			in.close();
			out.close();
			break;
		case 2:
			in.open("text1.txt");

			if (in.is_open()) {
				while (getline(in, str))
				{
					if(maxLen < str.length())
						maxLen = str.length();
				}
			}
			cout << "Длина самой длинной строки:" << maxLen << endl;

			in.close();
			break;
		case 3:
			in.open("text1.txt");

			cout << "Введите слово, кол-во которого нужно посчитать:";
			cin >> word;
			
			count = 0;
			if (in.is_open()) {
				while (getline(in, str))
				{
					size_t found = str.find(word);
					while (found != str.npos)
					{
							count++;
							found = str.find(word, found + 1);
					}
				}
			}

			cout << "Слово \"" << word << "\" встречается в файле " << count << " раз" << endl;
			in.close();
			break;
		case 4:
			in.open("textToReplace.txt");
			out.open("textReplaced.txt");

			cout << "Введите слово, которое нужно заменить:";
			cin >> wordToReplace;
			cout << "Введите слово, на которое нужно заменить:";
			cin >> word;

			if (in.is_open() && out.is_open())
			{
				while (getline(in, str))
				{
					newStr.clear();
					char* tempChar;
					tempChar = strtok(const_cast<char*>(str.c_str()), " ");
					while (tempChar != NULL)
					{
						if (tempChar == wordToReplace)
						{
							tempChar = const_cast<char*>(word.c_str());
						}
						newStr.append(tempChar);
						newStr.append(" ");
						tempChar = strtok(NULL, " ");
					}
					out << newStr;
					out << endl;
					delete[] tempChar;
				}
			}

			in.close();
			out.close();
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
}
