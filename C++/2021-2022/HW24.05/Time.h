#pragma once
#include <iostream>
using namespace std;
class Time
{
private:
	int hour;
	int minute;
	int second;
public:
	Time()
	{

	}
	Time(int hour, int minute, int second) : hour(hour), minute(minute), second(second)
	{

	}
	int getTimeInSeconds()
	{
		return hour * 3600 + minute * 60 + second;
	}
	void Set(int hour, int minute, int second)
	{
		this->hour = hour;
		this->minute = minute;
		this->second = second;
	}
};

