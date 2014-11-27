#include "Algo.h"
#include <stdlib.h> 

int* MapBuilderC::BuildMap(const int size, const int numberOfCellTypes) { 
	int numberOfCells = size*size;
	int* cells = new int[numberOfCells];

	int numberOfEachCell = numberOfCells / numberOfCellTypes;
	// Array that stores the number of case of each type left to place
	int* tabCellTypeLeft = new int[numberOfCellTypes];

	for (int i = 0; i < numberOfCellTypes; i++)
		tabCellTypeLeft[i] = numberOfEachCell;

	for (int i = 0; i < numberOfCells; i++)
	{
		int randomNumber = rand() % numberOfCellTypes;
		bool canPlace = false;

		// Vérification de la possibilité de placer ce type de case
		while (!canPlace)
		{
			if (tabCellTypeLeft[randomNumber] > 0) // Si au moins une case de ce type est disponible, on peut placer
				canPlace = true;
			else // Sinon on regénère un nombre, jusqu'à tomber sur un valide
				randomNumber = rand() % numberOfCellTypes;
		}

		cells[i] = randomNumber;
		tabCellTypeLeft[randomNumber]--;
	}

	return cells;
}

MapBuilderC* MapBuilderC_new() { return new MapBuilderC(); }
void MapBuilderC_delete(MapBuilderC* algo) { delete algo; }
int* MapBuilderC_BuildMap(MapBuilderC* algo, const int size, const int numberOfCellTypes) { return algo->BuildMap(size, numberOfCellTypes); }