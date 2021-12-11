#include <iostream>
#include <cmath>
#include <string>
#include <vector>
#include <fstream>

using namespace std;

int main(){
	int depth = 0;
	int xPos = 0;
	fstream inTxt;
	inTxt.open("input");
	string dir;
	int amount;
	int i = 0;

	while (i < 1000){//hackerman
		inTxt >> dir;
		inTxt >> amount;
		//pls don't break
		if (dir == "forward"){
			xPos += amount;
		}else if (dir == "up"){
			depth -= amount;
		}else if (dir == "down"){
			depth += amount;
		}else{
			cout << "Something went wrong" << endl;
		}
		i++;
		cout << i << endl;
	}

	cout << xPos * depth << endl;
}