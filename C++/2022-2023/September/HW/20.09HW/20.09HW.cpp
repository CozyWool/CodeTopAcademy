#include <iostream>
#include <Windows.h>
#include <cctype>
#include <string>
#include <algorithm>

using namespace std;

string subReplace(string str, string substr, string strReplace)
{
	SetConsoleCP(1252);
	SetConsoleOutputCP(1251);
	int pos = str.find(substr);
	int len = str.length();
	int cnt = substr.length();
	if (!(pos > 0 && pos < len))
	{
		cout << "\nНе найдено вхождений этого слова\n" << endl;
		return str;
	}
	while (pos > 0 && pos < len)
	{
		str.replace(pos, cnt, strReplace);
		pos = str.find(substr);
		len = str.length();
	}
	
	return str;
}
string uppFirstAlpha(string str)
{
	for (int i = 0; i < str.length() - 1; i++)
	{
		if (str[i] == '!' || str[i] == '.' || str[i] == '?')
		{
			str[i+1] = toupper(str[i+1]);
		}
	}
	return str;
}
int countAlpha(string str)
{
	return count_if(str.begin(), str.end(), isalpha); // не понимаю как посчитать каждую букву в тексте
													  // (т.е сколько букв "А", сколько "Б" и т.д
}
int countDigit(string str)
{
	int digit = count_if(str.begin(), str.end(), isdigit);
	return digit;
}
int main()
{	
	//cin.seekg(cin.eof());
	SetConsoleCP(1252);
	SetConsoleOutputCP(1251);

	cout << "Строки\nДомашнее задание №3\n";

	int cmd;
	int count;
	string str; 
	string substr;
	string strReplace;
	
	while (true)
	{
		cout << "Введите номер задания от 1 до 4:";
		cin >> cmd;
		cin.seekg(cin.eof());
		switch (cmd)
		{
		case 1:
			cout << "Введите исходное слово:";
			getline(cin, str);
			cout << "Введите некоторое вхождение:";
			getline(cin, substr);
			cout << "Введите слово для замены:";
			getline(cin, strReplace);
			str = subReplace(str, substr, strReplace);

			cout << "Новая строка:" << str << endl;
			break;
		case 2:
			cout << "Введите текст:";
			getline(cin, str);
			str = uppFirstAlpha(str);

			cout << "Новая строка:" << str << endl;
			break;
		case 3:
			cout << "Введите текст:";
			getline(cin, str);
			count = countAlpha(str);

			cout << "Букв в тексте:" << count << endl;
			break;
		case 4:
			cout << "Введите текст:";
			getline(cin, str);
			count = countDigit(str);

			cout << "Цифр в тексте:" << count << endl;
			break;
		default:
			cout << "Нет такого задания!" << endl;
			break;
		}
	}
}