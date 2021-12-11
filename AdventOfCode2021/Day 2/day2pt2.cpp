#include <iostream>
#include <cmath>
#include <string>
#include <vector>
#include <fstream>

using namespace std;

int main(){
	fstream inTxt;
	inTxt.open("input");
	vector<string> dir;
	vector<int> amount;
	int aim = 0;
	int xPos = 0;
	int depth = 0;
	string temp;
	int temp1; //I'm so smart

	for (int i = 0; i < 1000; i++){
		inTxt >> temp;
		dir.push_back(temp);
		inTxt >> temp1;
		amount.push_back(temp1);
	}
	//Takes values from input.txt, slaps em into
	//two vectors, one for direction, one for amount

	for (int i = 0; i < 1000; i++){
		if (dir.at(i) == "forward"){
			xPos += amount.at(i);
			depth += aim * amount.at(i);
		}else if (dir.at(i) == "up"){
			aim -= amount.at(i);
		}else if (dir.at(i) == "down"){
			aim += amount.at(i);
		}else{
			cout << "something went wrong!" << endl;
		}
	}
	cout << xPos * depth << endl;
}