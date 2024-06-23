#pragma once
#include <iostream>
using namespace std;
class Route
{
private:
	string start_point;
	string end_point;
	int number;
public:
	Route()
	{

	}
	Route(string start, string end, int number) : 
		start_point(start), end_point(end), number(number)
	{ 

	}
	
	void SetOnKeyboard()
	{
		cout << "Write start point: ";
		cin >> start_point;
		cout << "Write end point: ";
		cin >> end_point;
		cout << "Write number of route";
		cin >> number;
	}
	void Set(string start_point, string end_point, int number)
	{
		this->start_point = start_point;
		this->end_point = end_point;
		this->number = number;
	}
	void Print()
	{
		cout << "Route number " << number << endl;
		cout << "Starting from " << start_point << " to " << end_point << endl;
		cout << "\n----------------------------\n" << endl;
	}
	friend void FindANumber(Route *routes, size_t size, int n);
};