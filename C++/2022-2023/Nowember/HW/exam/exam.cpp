#include <iostream>
#include <Windows.h>
#include <algorithm>
#include <math.h>
#include <vector>
#include <string>
#include <cstdlib>

using namespace std;
/*Создайте приложение «Список дел».
Приложение должно позволять:
■ Добавление дел. У дела есть: DONE
• название;
• приоритет;
• описание;
• дата, время исполнения.
■ Удаление дел. DONE
■ Редактирование дел. DONE
■ Поиск дел по:
• названию;
• приоритету;
• описанию;
• дате и времени исполнения.
■ Отображение списка дел:  DONE
• на день;
• на неделю;
• на месяц.
■ При отображении должна быть возможность сортировки:
• по приоритету;
• по дате и времени исполнения*/
struct Date
{
    int year;
    int month;
    int day;
    int hour;
    int minute;
    int second;
};
void printDate(Date d)
{
    cout << "Год\tМесяц\tДень\tЧасы\tМинуты\tСекунды" << endl
        << d.year << "\t"
        << d.month << "\t"
        << d.day << "\t"
        << d.hour << "\t"
        << d.minute << "\t"
        << d.second << "\t";
}
Date fillDate()
{
    Date date;
    cout << "\nГод:";
    cin >> date.year;
    cout << "Месяц:";
    cin >> date.month;
    cout << "День:";
    cin >> date.day;
    cout << "Часы:";
    cin >> date.hour;
    cout << "Минуты:";
    cin >> date.minute;
    cout << "Секунды:";
    cin >> date.second;
    return date;
}
struct Case
{
    string name;
    int prior;
    string description;
    Date date;
    Date dateToDo;
    int caseType; // тип дела(на день, на неделю, на месяц)
};
enum caseTypes
{
    day,
    week,
    month
};
bool isVys(int year) // Проверка на високосный год
{
    bool res = false;
    if (year % 4 == 0)
        res = true;
    if (year % 100 == 0)
        res = false;
    if (year % 400 == 0)
        res = true;
    return res;
}
int date(Date date) // Подсчёт даты в днях
{
    int d = date.day;
    int m = date.month;
    int y = date.year;
    int k = d;
    if (isVys(y) && (m > 2))
        k += y * 366;
    else k += y * 365;
    switch (m - 1)
    {
    case 12: k += 31;
    case 11: k += 30;
    case 10: k += 31;
    case  9: k += 30;
    case  8: k += 31;
    case  7: k += 31;
    case  6: k += 30;
    case  5: k += 31;
    case  4: k += 30;
    case  3: k += 31;
    case  2: k += 28;
    case  1: k += 31;
    }
    return k;
}
int difference(Date d1, Date d2)
{
    int k = date(d1) - date(d2);
    return k;
}
int defineCaseType(Case c)
{
    int totalDay = difference(c.dateToDo, c.date);
    if (totalDay <= 1)
    {
        return day;
    }
    else if (totalDay > 1 && totalDay <= 7)
    {
        return week;
    }
    else if (totalDay > 7 && totalDay <= 30)
    {
        return month;
    }
    else
    {
        return month; // если больше месяца, но ТЗ не требует вывода дел на год
    }
}
void addCase(vector<Case>& cases, string name, int prior, string description, Date date, Date dateToDo)
{
    Case newCase;
    newCase.name = name;
    newCase.prior = (prior >= 1 && prior <= 9) ? prior : 1;
    newCase.description = description;
    newCase.date = date;
    newCase.dateToDo = dateToDo;
    newCase.caseType = defineCaseType(newCase);
    cases.push_back(newCase);
}
void printCase(Case c)
{
    cout << "Имя:" << c.name << endl
        << "Приоритет:" << c.prior << endl
        << "Описание:" << c.description << endl
        << "\t\tДата создания" << endl;
    printDate(c.date);
    cout << endl << "\t\tДата выполнения" << endl;
    printDate(c.dateToDo);
    cout << "\n-----------------------------------------------------" << endl;
}
void printCasesByType(vector<Case>& cases, int type)
{
    switch (type)
    {
    case day:
        for (int i = 0; i < cases.size(); i++)
        {
            if (cases[i].caseType == day)
            {
                printCase(cases[i]);
            }
        }
        break;
    case week:
        for (int i = 0; i < cases.size(); i++)
        {
            if (cases[i].caseType == week)
            {
                printCase(cases[i]);
            }
        }
        break;
    case month:
        for (int i = 0; i < cases.size(); i++)
        {
            if (cases[i].caseType == month)
            {
                printCase(cases[i]);
            }
        }
        break;
    default:
        break;
    }
}
void printCases(vector<Case>& cases)
{
    for (int i = 0; i < cases.size(); i++)
    {
        printCase(cases[i]);
    }
}
void deleteCase(vector<Case>& cases, int index)
{
    cases.erase(cases.begin() + index);
}
void changeCase(vector<Case>& cases, int index, int type, int dateAnswer, string newValue)
{
    switch (type)
    {
    case 1:
        cases[index].name = newValue;
        break;
    case 2:
        cases[index].prior = stoi(newValue);
        break;
    case 3:
        cases[index].description = newValue;
        break;
    case 4:
        switch (dateAnswer)
        {
        case 1:
            cases[index].date.year = stoi(newValue);
            break;
        case 2:
            cases[index].date.month = stoi(newValue);
            break;
        case 3:
            cases[index].date.day = stoi(newValue);
            break;
        case 4:
            cases[index].date.hour = stoi(newValue);
            break;
        case 5:
            cases[index].date.minute = stoi(newValue);
            break;
        case 6:
            cases[index].date.second = stoi(newValue);
            break;
        default:
            break;
        }
        cases[index].caseType = defineCaseType(cases[index]);
        break;
    case 5:
        switch (dateAnswer)
        {
        case 1:
            cases[index].dateToDo.year = stoi(newValue);
            break;
        case 2:
            cases[index].dateToDo.month = stoi(newValue);
            break;
        case 3:
            cases[index].dateToDo.day = stoi(newValue);
            break;
        case 4:
            cases[index].dateToDo.hour = stoi(newValue);
            break;
        case 5:
            cases[index].dateToDo.minute = stoi(newValue);
            break;
        case 6:
            cases[index].dateToDo.second = stoi(newValue);
            break;
        default:
            break;
        }
        cases[index].caseType = defineCaseType(cases[index]);
        break;
    default:
        break;
    }
}
vector<Case> searchCases(vector<Case>& cases, int type, string value)
{
    vector<Case> searchedCases;

    switch (type)
    {
    case 1:
        for (int i = 0; i < cases.size(); i++)
        {
            if (cases[i].name.find(value) != value.npos)
            {
                searchedCases.push_back(cases[i]);
            }
        }
        break;
    case 2:
        for (int i = 0; i < cases.size(); i++)
        {
            if (to_string(cases[i].prior).find(value) != value.npos)
            {
                searchedCases.push_back(cases[i]);
            }
        }
        break;
    case 3:
        for (int i = 0; i < cases.size(); i++)
        {
            if (cases[i].description.find(value) != value.npos)
            {
                searchedCases.push_back(cases[i]);
            }
        }
        break;
    case 4:
        break;
    case 0:
        break;
    default:
        break;
    }

    return searchedCases;
}
int menu()
{
    int cmd;
    cout << "1 - Добавить дело\n"
        << "2 - Удалить дело\n"
        << "3 - Изменить дело\n"
        << "4 - Найти дела\n"
        << "5 - Вывести дела\n"
        << "0 - Выход из программы\n"
        << "Введите команду:";
    cin >> cmd;
    return cmd;
}
int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    bool key = true;
    int cmd;
    int answer, answer2;
    int dateAnswer = 0;
    vector<Case> cases;
    vector<Case> searchedCases;
    string name;
    string newValue;
    int prior;
    string description;
    Date date;
    Date dateToDo;
    while (key)
    {
        cout << "\t\tПрограмма \"Список дел\"\n" << endl;
        cmd = menu();
        switch (cmd)
        {
        case 1:
            system("cls");
            cout << "\t\tДобавление дела" << endl;
            cout << "Название дела:";
            cin.seekg(cin.eof());
            getline(cin, name);
            cout << "Приоритет дела(1 - 9):";
            cin >> prior;
            cout << "Описание дела:";
            cin.seekg(cin.eof());
            getline(cin, description);
            cout << "\n\tДата создания дела";
            date = fillDate();
            cout << "\n\tДата выполнения дела";
            dateToDo = fillDate();
            addCase(cases, name, prior, description, date, dateToDo);
            break;
        case 2:
            system("cls");
            cout << "\t\tУдаление дела" << endl;
            cout << "Какое дело вы хотите удалить?" << endl;
            for (int i = 0; i < cases.size(); i++)
            {
                cout << i + 1 << " - Дело \"" << cases[i].name << "\"" << endl;
            }
            cout << "Введите команду:";
            cin >> answer;
            answer--;
            deleteCase(cases, answer);
            break;
        case 3:
            system("cls");
            cout << "\t\tИзменение дела" << endl;
            cout << "Какое дело вы хотите изменить?" << endl;
            for (int i = 0; i < cases.size(); i++)
            {
                cout << i + 1 << " - Дело \"" << cases[i].name << "\"" << endl;
            }
            cout << "Введите команду:";
            cin >> answer;
            answer--;
            system("cls");
            cout << "Что именно вы хотите изменить в деле \"" << cases[answer].name << "\"" << endl
                << "1 - Имя\n"
                << "2 - Приоритет\n"
                << "3 - Описание\n"
                << "4 - Дата\n"
                << "5 - Дата выполнения\n"
                << "0 - Назад\n"
                << "Введите команду:";
            cin >> answer2;
            system("cls");
            switch (answer2)
            {
            case 1:
                cout << "Новое имя:";
                break;
            case 2:
                cout << "Новый приоритет:";
                break;
            case 3:
                cout << "Новое описание:";
                break;
            case 4:
                cout << "Что именно вы хотите изменить в дате?" << endl
                    << "1 - Год\n"
                    << "2 - Месяц\n"
                    << "3 - День\n"
                    << "4 - Часы\n"
                    << "5 - Минуты\n"
                    << "6 - Секунды\n"
                    << "Введите команду:";
                cin >> dateAnswer;
                switch (dateAnswer)
                {
                case 1:
                    cout << "Новый год:";
                    break;
                case 2:
                    cout << "Новый месяц:";
                    break;
                case 3:
                    cout << "Новый день:";
                    break;
                case 4:
                    cout << "Новое значение часов:";
                    break;
                case 5:
                    cout << "Новое значение минут:";
                    break;
                case 6:
                    cout << "Новое значение секунд:";
                    break;
                default:
                    break;
                }
                break;
            case 5:
                cout << "Что именно вы хотите изменить в дате выполнения?" << endl
                    << "1 - Год\n"
                    << "2 - Месяц\n"
                    << "3 - День\n"
                    << "4 - Часы\n"
                    << "5 - Минуты\n"
                    << "6 - Секунды\n"
                    << "Введите команду:";
                cin >> dateAnswer;
                switch (dateAnswer)
                {
                case 1:
                    cout << "Новый год:";
                    break;
                case 2:
                    cout << "Новый месяц:";
                    break;
                case 3:
                    cout << "Новый день:";
                    break;
                case 4:
                    cout << "Новое значение часов:";
                    break;
                case 5:
                    cout << "Новое значение минут:";
                    break;
                case 6:
                    cout << "Новое значение секунд:";
                    break;
                default:
                    break;
                }
                break;
            default:
                break;
            }
            if (answer2 != 0)
            {
                newValue.clear();
                cin.seekg(cin.eof());
                getline(cin, newValue);
                changeCase(cases, answer, answer2, dateAnswer, newValue);
            }
            break;
        case 4:
            system("cls");
            cout << "\t\tПоиск дел" << endl;
            cout << "По какому критерию вы хотите найти дела?\n"
                << "1 - По названию\n"
                << "2 - По приоритету\n"
                << "3 - По описанию\n"
                << "4 - По дате и времени исполнения(НЕ СДЕЛАНО)\n"
                << "0 - Назад\n"
                << "Введите команду:";
            cin >> answer;
            system("cls");
            switch (answer)
            {
            case 1:
                cout << "Название(или фрагмент названия):";
                break;
            case 2:
                cout << "Приоритет:";
                break;
            case 3:
                cout << "Описание(или фрагмент описания)";
                break;
            case 4:
                break;
            case 0:
                break;
            default:
                break;
            }
            if (answer != 0)
            {
                newValue.clear();
                cin.seekg(cin.eof());
                getline(cin, newValue);
                searchedCases = searchCases(cases, answer, newValue);
                system("cls");
                cout << "\t\tНайденые дела" << endl;
                printCases(searchedCases);
            }
            break;
        case 5:
            system("cls");
            cout << "\t\tВывод дел" << endl;
            cout << "По какому критерию вы хотите вывести дела?\n"
                << "1 - На день\n"
                << "2 - На неделю\n"
                << "3 - На месяц или больше\n"
                << "0 - Назад\n"
                << "Введите команду:";
            cin >> answer;
            system("cls");
            switch (answer)
            {
            case 1:
                printCasesByType(cases, day);
                break;
            case 2:
                printCasesByType(cases, week);
                break;
            case 3:
                printCasesByType(cases, month);
                break;
            case 0:
                break;
            default:
                break;
            }
            break;
        case 0:
            key = false;
            system("cls");
            cout << "\n\t\tДо свидания!\n" << endl;
        default:
            break;
        }
    }
}