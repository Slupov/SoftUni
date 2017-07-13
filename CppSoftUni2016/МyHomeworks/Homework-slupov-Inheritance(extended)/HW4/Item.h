#pragma once
#include<iostream>
#include<string>
using namespace std;
class Item
{
public:
	string itemCode;
	string name;
	float price;

	Item() {};
	Item(string _itemCode,string _name, float _price) : itemCode(_itemCode), name(_name), price(_price) {};


};

