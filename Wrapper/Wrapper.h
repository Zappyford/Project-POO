#ifndef __WRAPPER__
#define __WRAPPER__
#include "../Algo/Algo.h"
// A changer
// Le bon chemin pour �tre "../Debug/nomProjetLib.lib"
#pragma comment(lib,"../Debug/Algo.lib") // A changer

using namespace System;
namespace Wrapper {
	public ref class WrapperMapBuilder {
	private:
		MapBuilderC* algo;
	public:
		WrapperMapBuilder(){ algo = MapBuilderC_new(); }
		~WrapperMapBuilder(){ MapBuilderC_delete(algo); }
		int* BuildMap(const int size, const int numberOfCellTypes) { return algo->BuildMap(size, numberOfCellTypes);}
		void placePlayer1(const int sizeOfMap, int& x, int& y) { return algo->placePlayer1(sizeOfMap, x,y); }
		void placePlayer2(const int sizeOfMap, int& x, int& y) { return algo->placePlayer2(sizeOfMap, x, y); }
	};

}

#endif
