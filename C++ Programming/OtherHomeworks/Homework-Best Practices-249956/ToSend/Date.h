#ifndef DATE_H
#define DATE_H

class Date
{
	private:
		short int day, month, year;
	
	public:
		Date();
		Date(unsigned short int, unsigned short int, unsigned short int);
		
		void setDay(unsigned short int);
		void setMonth(unsigned short int);
		void setYear(unsigned short int);
		
		unsigned short int getDay();
		unsigned short int getMonth();
		unsigned short int getYear();
		
		void displayDate();
};

#endif