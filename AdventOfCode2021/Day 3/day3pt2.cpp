#include <string>
#include <cmath>
#include <iostream>
#include <fstream>
#include <vector>
//int dec = std::stoi(bin#, nullptr, 2); // dec = -1201

using namespace std;
vector<char> byteSlicer(vector<string> inputs, int slicePos);
vector<string> textToVector(string fileName);
char mode(vector<char> charArray, bool anti);
vector<string> vectorSnipper(char mode, int index, vector<string> inputLines);

int main(){
	const int LINE_LEN = 12;
	int i = -1;
	vector<string> inputLines = textToVector("input");
	int oxyGenRating;
	int carScrubRating;
	vector<string> currLines = inputLines;
	vector<char> currCharas;
	char currMode;

	do{//Could be done with recursion, but this is easier to debug
		i++;
		currCharas = byteSlicer(currLines, i);
		currMode = mode(currCharas, false);
		currLines = vectorSnipper(currMode, i, currLines);
	}while(currLines.size() > 1);
	oxyGenRating = stoi(currLines.at(0), nullptr, 2);

	//Do the same, but with the least common
	currLines = inputLines;
	int k = -1;
	//resetting our variables
	do{
		k++;
		currCharas = byteSlicer(currLines, k);
		currMode = mode(currCharas, true);//changed here
		currLines = vectorSnipper(currMode, k, currLines);
	}while(currLines.size() > 1);
	carScrubRating = stoi(currLines.at(0), nullptr, 2);

	cout << oxyGenRating << "\n" << carScrubRating << endl;
	cout << oxyGenRating * carScrubRating << endl;
}

vector<char> byteSlicer(vector<string> inputs, int slicePos){//takes an array of lines, returns an array of the bits at slicePos
	vector<char> charArray;
	for (string line : inputs){
		charArray.push_back(line.at(slicePos));
	}
	return charArray;
}

vector<string> textToVector(string fileName){//concerts input text to a vector of strings
	fstream inTxt;
	vector<string> returnVec;
	inTxt.open(fileName);
	string line;
	while (getline(inTxt, line)){
		returnVec.push_back(line);
	}
	inTxt.close();
	return returnVec;
}

char mode(vector<char> charArray, bool anti){//returns mode, or anti-mode if enabled
	int ones = 0;
	int zeros = 0;
	for (char chara : charArray){//counts 1's and 0's
		if (chara == '0'){
			zeros++;
		}else{
			ones++;
		}
	}
	if (anti){
		if (ones < zeros){
			return '1';
		}else{
			return '0';
		}
	}else{
		if (ones >= zeros){
			return '1';
		}else{
			return '0';
		}
	}
}

vector<string> vectorSnipper(char mode, int index, vector<string> inputLines){
	vector<string> newVecString;
	for (string line : inputLines){
		if (line.at(index) == mode){
			newVecString.push_back(line);
		}
	}
	return newVecString;
}