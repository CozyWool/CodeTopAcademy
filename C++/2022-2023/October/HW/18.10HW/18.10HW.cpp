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

	ifstream in1;
	ifstream in2;
	ofstream of1;
	string str1, str2;
	int cmd;
	bool key = true;

	char vowels[]{"aeiouyаоуыиеёэюя"};
	int charCount = 0;
	int stringCount = 0;
	int vowelCount = 0;
	int consonantsCount = 0;
	int digitCount = 0;

	while (key)
	{
		cout << "Введите номер задания от 1 до 3(0 - выход):";
		cin >> cmd;
		system("cls");
		switch (cmd)
		{
		case 1:
			in1.open("text1.txt");
			in2.open("text2.txt");
			if (in1.is_open() && in2.is_open()) {
				while (getline(in1, str1) && getline(in2,str2))
				{
					if (str1 != str2)
					{
						cout << "Несовпадающие строки: \"" << str1 << "\" и \"" << str2 << "\"" << endl;
					}
				}
			}
			in1.close();
			in2.close();
			break;
		case 2:
			in1.open("text1.txt");
			of1.open("textCount.txt");

			if (in1.is_open()) {
				while (getline(in1, str1))
				{
					charCount += str1.length();
					stringCount++;
					for (int i = 0; i < str1.length(); i++)
					{
						if (!isalpha(str1[i]))
							continue;
						strchr(vowels, str1[i]) ? vowelCount++ : consonantsCount++;
					}
					digitCount += count_if(str1.begin(), str1.end(), isdigit);
				}
			}
			of1 << "Количество символов:" << charCount << endl
				<< "Количество строк:" << stringCount << endl
				<< "Количество гласных:" << vowelCount << endl
				<< "Количество согласных:" << consonantsCount << endl
				<< "Количество цифр:" << digitCount << endl;

			in1.close();
			of1.close();
			break;
		case 3: 
			// С кириллицой не работает :/
			// Калькулятор по шифру онлайн https://planetcalc.ru/1434/
			in1.open("text1.txt");
			of1.open("textCaesar.txt");

			int codeKey;
			cout << "Введите ключ:" << endl;
			cin >> codeKey;
			
			if (in1.is_open()) {
				while (getline(in1, str1))
				{
					for (int i = 0; i < str1.length(); i++)
					{
						str1[i] += codeKey;
					}
					of1 << str1 << endl;
				}
			}
			
			in1.close();
			of1.close();
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
