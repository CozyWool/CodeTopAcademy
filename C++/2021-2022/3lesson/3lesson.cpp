#include <iostream>
using namespace std;
int main()
{
    int i = 1; // 4 byte

    while (i <= 10)
    {
        cout << i << " ";
        i++;
    }
    cout << endl;

    for (int j = 1; j <= 10; j++) {
        cout << j << " ";
    }

    return 0;
}

============================
#include <iostream>
#include <ctime>
using namespace std;
int main()
{
    // 1970 1 January
    srand(time(NULL));

    // 01.01.1970
    int randomNumber = rand() % 10;
    cout << "Random Number: " << randomNumber << endl;

    // Y = 10, X = 20
    // rand % (X - Y) + Y
    // 589976690 % 10 = 0 + 10 = 10
    // 589976699 % 10 = 9 + 10 = 19
    randomNumber = rand() % 10 + 10; // 10 ... 20
    cout << "Random Number: " << randomNumber << endl;

    return 0;
}

============================
#include <iostream>
using namespace std;
int main()
{
    srand(time(NULL));

    int choiceLevel, firstNumber, secondNumber, correctAnswer, userAnswer;

    do
    {
        cout << "1 - Beginner\n";
        cout << "2 - Intermediate\n";
        cout << "3 - Advance\n";
        cout << "0 - Exit\n";
        cout << "Please, choice the level: ";
        cin >> choiceLevel;

        int countCorrectAnswers = 0;
        const int countQuestions = 5;

        switch (choiceLevel) {
        case 1:
            for (int i = 0; i < countQuestions; i++)
            {
                firstNumber = rand() % 10; // range: 0..9
                secondNumber = rand() % 10; // range: 0..9;

                correctAnswer = firstNumber * secondNumber;

                cout << firstNumber << " * " << secondNumber << " = ";
                cin >> userAnswer;

                if (userAnswer == correctAnswer)
                {
                    cout << "Correct answer!" << endl;
                    countCorrectAnswers++;
                }
                else
                    cout << "Incorrect answer!" << endl;
            }

            cout << "Your result: " << countCorrectAnswers << "/" << countQuestions << endl << endl;
            break;
        case 2:
            for (int i = 0; i < countQuestions; i++)
            {
                firstNumber = rand() % 10 + 10; // range: 10..20
                secondNumber = rand() % 10 + 10; // range: 10..20;

                correctAnswer = firstNumber * secondNumber;

                cout << firstNumber << " * " << secondNumber << " = ";
                cin >> userAnswer;

                if (userAnswer == correctAnswer)
                {
                    cout << "Correct answer!" << endl;
                    countCorrectAnswers++;
                }
                else
                    cout << "Incorrect answer!" << endl;
            }

            cout << "Your result: " << countCorrectAnswers << "/" << countQuestions << endl << endl;
            break;
        case 3:
            for (int i = 0; i < countQuestions; i++)
            {
                firstNumber = rand() % 10 + 20; // range: 20..30
                secondNumber = rand() % 10 + 20; // range: 20..30;

                correctAnswer = firstNumber * secondNumber;

                cout << firstNumber << " * " << secondNumber << " = ";
                cin >> userAnswer;

                if (userAnswer == correctAnswer)
                {
                    cout << "Correct answer!" << endl;
                    countCorrectAnswers++;
                }
                else
                    cout << "Incorrect answer!" << endl;
            }

            cout << "Your result: " << countCorrectAnswers << "/" << countQuestions << endl << endl;
            break;
        case 0:
            cout << "Bye! See you soon..." << endl << endl;
            break;

        default:
            cout << "Incorrect Level. Please, input again!\n\n";
            break;
        }
    } while (choiceLevel != 0);

    return 0;
}

