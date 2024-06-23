#include <iostream>
#include <cstring>
#include <string>
#include <cstdio>
#include <Windows.h>
#include <algorithm>

using namespace std;

string spaceToTab(string str)
{
	for (auto &s : str)
	{
		if (s == ' ')
		{
			s = '\t';
		}
	}
	return str;
}
bool checkPalindrome(string str)
{
	bool isPalindrome = true;
	for (int i = 0; i < str.length() / 2; i++)
	{
		if (str[i] != str[str.length() - i - 1])
		{
			isPalindrome = false;
			break;
		}
	}
	return isPalindrome;
}
int countWords(string str)
{
	int count = 1;
	for (auto s : str)
	{
		if (isspace(s))
			count++;
	}
	return count;
}
bool checkPass(string pass)
{
	int digit = count_if(pass.begin(), pass.end(), isdigit);
	int alpha = count_if(pass.begin(), pass.end(), isalpha);
	int other = pass.length() - (digit + alpha);
	int upperCount = count_if(pass.begin(), pass.end(), isupper);
	if (pass.length() >= 8 && digit >= 1 && other >= 1 && upperCount >= 1)
	{
		return true;
	}
	return false;
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout << "\t\tПроверка безопасности пароля\n" << endl;
	string pass;
	cout << "Введите пароль:";
	cin >> pass;
	checkPass(pass) ? cout << "Ваш пароль безопасен" << endl : cout << "Ваш пароль не безопасен" << endl;
}
/*string str = "шалаш шалаш";
	cout << str << endl;
	checkPalindrome(str) ? cout << "Палиндром!" << endl : cout << "Не палиндром" << endl;
	cout << countWords(str);*/
