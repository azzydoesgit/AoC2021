#include <string>
#include <cmath>
#include <iostream>
#include <fstream>
#include <vector>
//int dec = std::stoi(bin#, nullptr, 2); // dec = -1201

using namespace std;

int main(){
	const int LINE_LEN = 12;

	fstream inTxt;

	string gammaBin;
	string epsilonBin;
	string line;
	vector<string> inputLines;

	inTxt.open("input");
	while (getline(inTxt, line)){
		inputLines.push_back(line);
	}
	inTxt.close();

	for (int i = 0; i < LINE_LEN; i++){
		int ones = 0;
		int zeros = 0;
		for (string currLine : inputLines){//determines if bit i is a 1 or 0, counts accordingly
			if (currLine.at(i) == '0'){
				zeros++;
			}else{ //please work
				ones++;
			}
		}
		if (zeros > ones){//determines if 0 or 1 is more common, adds them to gamma and epsilon depending
			gammaBin.push_back('0');
			epsilonBin.push_back('1');
		}else{
			gammaBin.push_back('1');
			epsilonBin.push_back('0');
		}
	}
	
	int gammaDec = stoi(gammaBin, nullptr, 2);
	int epsilonDec = stoi(epsilonBin, nullptr, 2);

	cout << gammaDec * epsilonDec << endl;
}