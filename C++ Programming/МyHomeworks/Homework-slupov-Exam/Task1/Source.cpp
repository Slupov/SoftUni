#include <iostream>
#include <string>
#include <math.h>

#define PI 3.14159265
using namespace std;

int main()
{
	int x1, x2, x3;
	int y1, y2, y3;
	int z1, z2, z3;


	scanf("%d, %d, %d; %d, %d, %d; %d, %d, %d;", &x1, &y1, &z1, &x2, &y2, &z2, &x3, &y3, &z3);

	double a, b, c;

	a = sqrt((x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1) + (z2 - z1)*(z2 - z1));
	b = sqrt((x3 - x1)*(x3 - x1) + (y3 - y1)*(y3 - y1) + (z3 - z1)*(z3 - z1));
	c = sqrt((x2 - x3)*(x2 - x3) + (y2 - y3)*(y2 - y3) + (z2 - z3)*(z2 - z3));

	double cosA, cosB, cosC;

	cosA = (b*b + c*c - a*a) / (2 * b*c);
	cosB = (a*a + c*c - b*b) / (2 * a*c);
	cosC = (a*a + b*b - c*c) / (2 * a*b);

	std::cout << (int)(acos(cosC)*180.0 / PI) << ",";
	std::cout << (int)(acos(cosB)*180.0 / PI) << ",";
	std::cout << (int)(acos(cosA)*180.0 / PI);

	return 0;
}