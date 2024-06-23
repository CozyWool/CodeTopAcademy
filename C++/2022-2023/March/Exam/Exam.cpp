#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <time.h>
#include <vector>
#include <fstream>
#include <algorithm>

using namespace std;

string CesearDecode(string word, int step)
{
	for (int i = 0; i < word.length(); i++)
	{
		word[i] -= step;
	}
	return word;
}
void CesearDecodeFile(ifstream& codedFile, int step, string fileName)
{
	string s;
	ofstream decodedFile(fileName + "Decoded.txt", ios::out);
	for (codedFile >> s; !codedFile.eof(); codedFile >> s)
	{
		codedFile >> s;
		s = CesearDecode(s, step);
		decodedFile << s << endl;
	}
	/*while (!codedFile.eof())
	{
		codedFile >> s;
		s = CesearDecode(s, step);
		decodedFile << s << endl;
	}*/
	
	codedFile.seekg(codedFile._Seekbeg);
}

class Hangman
{
private:
	clock_t startTime{ 0 }; // Стартовое время
	clock_t endTime{ 0 }; // Конечное время
	int attempts = 0; // Кол-во попыток
	int errorCount = 0; // Кол-во ошибок
	vector<char> letters; // Ввёденные буквы
	string hiddenWord; // Слово в процессе игры
	string word; // Загаданное слово
public:
	Hangman(ifstream& codedWordList)
	{
		CesearDecodeFile(codedWordList, 2, "Words"); // Я закодировал файл шифром Цезаря с шагом 2
		codedWordList.close();
		codedWordList.open("WordsDecoded.txt");
		int wordsNumber = 0;
		while (!codedWordList.eof()) // Подсчёт кол-ва слов в файле
		{
			codedWordList >> word;
			wordsNumber++;
		}
		codedWordList.clear();
		codedWordList.seekg(codedWordList._Seekbeg);

		int randomWordNumber = rand() % wordsNumber; // Выбор случайного слова
		for (int i = 0; i < randomWordNumber; i++)
			codedWordList >> word;

		transform(word.begin(), word.end(), word.begin(), toupper); // Повышение регистра всему слову

		for (int i = 0; i < word.length(); i++)
		{
			if (word[i] == 'я') // toupper() не работает для 'я'
				word[i] = 'Я';
			hiddenWord += "-";
		}
	}

	friend ostream& operator<<(ostream& out, const Hangman& h)
	{
		out << "----------" << endl
			<< "|  " << (h.errorCount >= 1 ? "|" : "") << endl
			<< "|  " << (h.errorCount >= 1 ? "0" : "") << endl
			<< "| " << (h.errorCount >= 3 ? "/" : " ") << (h.errorCount >= 2 ? "|" : "") << (h.errorCount >= 4 ? "\\" : "") << endl
			<< "|  " << (h.errorCount >= 2 ? "|" : "") << endl
			<< "| " << (h.errorCount >= 5 ? "/" : "") << (h.errorCount >= 6 ? " \\" : "") << endl
			<< "|" << endl
			<< "------------" << endl;



		out << "Кол-во ошибок: " << h.errorCount << endl
			<< "Кол-во попыток: " << h.attempts << endl
			<< "Введённые буквы: ";
		for (int i = 0; i < h.letters.size(); i++)
		{
			out << h.letters[i];
			out << (i < h.letters.size() - 1 ? " , " : ".\n");
		}

		out << "\nСЛОВО: " << h.hiddenWord << endl;

		return out;
	}

	void startGame()
	{
		startTime = clock(); // Начало отсчёта времени
	}
	void endGame()
	{
		endTime = clock(); // Конец отсчёта времени
		double totalTime = (double)(endTime - startTime) / CLOCKS_PER_SEC; // Подсчёт времени игры в секундах
		cout << *this << endl
			<< "\n\tИгра окончена!" << endl
			<< "\tИтоговый счёт" << endl
			<< "\tВы " << (errorCount < 6 && hiddenWord == word ? "выиграли!" : "проиграли!") << endl
			<< "Потрачено времени: " << totalTime << " с." << endl
			<< "Кол-во ошибок: " << errorCount << endl
			<< "Кол-во попыток: " << attempts << endl
			<< "Искомое слово: " << word << endl
			<< "Введённые буквы: ";
		for (int i = 0; i < letters.size(); i++)
		{
			cout << letters[i];
			cout << (i < letters.size() - 1 ? " , " : ".\n");
		}
	}
	bool isEnd()
	{
		return (errorCount < 6 && word == hiddenWord) || errorCount >= 6;
	}
	bool isLetterContains(char letter)
	{
		return find(letters.begin(), letters.end(), letter) != letters.end();
	}
	bool checkLetter(char letter)
	{
		bool flag = false;
		letters.push_back(letter);
		attempts++;
		for (int i = 0; i < word.length(); i++)
		{
			if (letter == word[i])
			{
				hiddenWord[i] = letter;
				flag = true;
			}
		}
		if (flag)
			return true;

		errorCount++;
		return false;
	}
};

char getLetter(const Hangman& h, string message) // Получение буквы со всеми проверками
{
	char letter;
	cout << message;
	cin >> letter;

	while (letter > 'я' || letter < 'А')
	{
		system("cls");
		cout << h << endl;
		cout << "\tПожалуйста, введите букву из кириллицы!" << endl;
		cout << "Введите букву: ";
		cin >> letter;
	}
	if (letter == 'я') // Почему-то у 'я' toupper() не хочет повышать регистр 
		return 'Я';
	return toupper(letter);
}

void CesearEncodeFile(ifstream& file, int step, string fileName)  // Кодировка одноразовая
{
	string s;
	ofstream codedFile(fileName + "Coded.txt", ios::out | ios::binary);
	while (!file.eof())
	{
		file >> s;
		for (int i = 0; i < s.length(); i++)
		{
			s[i] += step;
		}
		codedFile << s << endl;
	}
	file.seekg(file._Seekbeg);
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, ""); // для toupper()
	srand(time(NULL));

	/*ifstream words("Words.txt"); // Если нужно зашифровать, раскомментировать
	CesearEncodeFile(words, 2, "Words");*/

	while (true)
	{
		ifstream wordsList("WordsCoded.txt");
		Hangman hangman{ wordsList };

		cout << "\tКонсольная игра \"ВИСЕЛИЦА\"" << endl;

		int t;
		cout << "Что вы хотите сделать?" << endl
			<< "1 - Играть в \"ВИСЕЛИЦУ\"" << endl
			<< "0 - Выход из программы" << endl
			<< "Введите команду: ";
		cin >> t;
		switch (t)
		{
		case 1:
			system("cls");
			cout << "\tКонсольная игра \"ВИСЕЛИЦА\"" << endl;

			char key;
			cout << "Вы готовы начать игру?(Y/N): ";
			cin >> key;
			key = toupper(key);

			system("cls");
			switch (key)
			{
			case 'Y':
				hangman.startGame();
				break;
			default:
				cout << "\n\tДо свидания!" << endl;
				exit(0);
				break;
			}
			while (true)
			{
				cout << hangman << endl;
				char letter = getLetter(hangman, "Введите букву: ");

				if (hangman.isLetterContains(letter))
				{
					system("cls");
					cout << "Вы уже вводили эту букву!" << endl;
					continue;
				}
				while (hangman.checkLetter(letter) && !hangman.isEnd())
				{
					system("cls");
					cout << "Вы угадали букву " << letter << "!" << endl;
					cout << hangman << endl;
					letter = getLetter(hangman, "Введите следующую букву: ");
				}

				system("cls");

				if (hangman.isEnd())
				{
					hangman.endGame();
					break;
				}

				cout << "Вы не угадали букву! Попробуйте еще раз!" << endl;
			}
			break;
		case 0:
			cout << "\n\tДо свидания!" << endl;
			exit(0);
			break;
		default:
			break;
		}
		if (wordsList.is_open())
			wordsList.close();
	}



}