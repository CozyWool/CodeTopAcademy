#include <iostream>
#include <algorithm>
#include <string.h>

using namespace std;

char line[5]{'l','i','n','e','!'};
char line2[] = "OK!";
char* mess;

int main()
{
	setlocale(0, "");
	string s = "Hello, 1,% my name i5s810 St1v(!";
	cout << s << endl;
	//replace(s.begin(), s.end(), ' ', '\t');
	cout << s << endl;
	int digit = count_if(s.begin(), s.end(), isdigit);
	int alpha = count_if(s.begin(), s.end(), isalpha);
	int other = s.length() - (digit + alpha);
	//other = count_if(s.begin(), s.end(), [](char lst) { return !(isdigit || isalpha); });
	/*cout << other;
	*/
	char word[] = "PolinniloP";
	bool t = true;
	for (int i = 0; i < strlen(word) / 2; i++)
	{
		if (word[i] != word[strlen(word) - i - 1])
		{
			t = false;
			break;
		}
	}
	if (t)
	{
		cout << "Палиндром!";
	}
	
	//string str;
	//cout << "Введите предложение:";
	//cin >> str;
	//int count = count_if(s.begin(), s.end(), isblank);
	//int count = 1;
	//for (auto s : str)
	//{
	//	if (s == ' ')
	//	{
	//		count++;
	//	}
	//}
	//cout << count;
}
//const char* monthName(int k)
//{
//	const static char* name[] =
//	{
//		"none", "Январь",
//		"Февраль","Март","Апрель",
//		"Май","Июнь","Июль","Август",
//		"Сентябрь","Октябрь","Ноябрь",
//		"Декабрь"
//	};
//	return (k < 1 || k > 12) ? name[0] : name[k];
//}
