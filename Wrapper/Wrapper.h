#ifndef __WRAPPER__
#define __WRAPPER__
#include "../Algo/Algo.h"
// A changer
// Le bon chemin pour être "../Debug/nomProjetLib.lib"
#pragma comment(lib,"../Debug/Algo.lib") // A changer

using namespace System;
namespace Wrapper {
	public ref class WrapperMapBuilder {
	private:
		MapBuilderC* algo;
	public:
		WrapperMapBuilder(){ algo = MapBuilderC_new(); }
		~WrapperMapBuilder(){ MapBuilderC_delete(algo); }
		int* BuildMap(const int size, const int numberOfCellTypes) { return algo->BuildMap(size, numberOfCellTypes); }
	};
}
#endif
