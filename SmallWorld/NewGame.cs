using PetitMonde.Map;
using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace PetitMonde
{
    

    /// <summary>
    /// GameBuilder for a new game
    /// </summary>
    public class NewGame : GameBuilderImpl
    {
        private NewGameDataContext dataContext;

        public NewGame(NewGameDataContext dataContext)// string nicknameP1, string nicknameP2, Faction tribeP1, Faction tribeP2, MapSize mapSize)
        {
            this.dataContext = dataContext;
        }
    
        public override Game BuildGame()
        {
            MapBuilder mapbuilder;

            switch (dataContext.SizeOfMap)
            {
                case MapSize.demo:
                    mapbuilder = new DemoMapBuilder();
                    break;
                case MapSize.medium:
                    mapbuilder = new MediumMapBuilder();
                    break;
                case MapSize.small:
                    mapbuilder = new SmallMapBuilder();
                    break;
                default:
                    mapbuilder = new SmallMapBuilder();
                    break;
            }

            GameImpl.INSTANCE.Map = mapbuilder.BuildMap();


            /// Récupération de l'emplacement par défaut des joueurs 
            Tribe tribeP1;
            Tribe tribeP2;

            switch(dataContext.FactionP1){
                case Faction.Dwarves:
                    tribeP1 = new Dwarves();
                    break;
                case Faction.Elves:
                    tribeP1 = new Elves();
                    break;
                case Faction.Orcs:
                    tribeP1 = new Orcs();
                    break;
                default:
                    tribeP1 = new Dwarves();
                    break;
            }

            switch (dataContext.FactionP2)
            {
                case Faction.Dwarves:
                    tribeP2 = new Dwarves();
                    break;
                case Faction.Elves:
                    tribeP2 = new Elves();
                    break;
                case Faction.Orcs:
                    tribeP2 = new Orcs();
                    break;
                default:
                    tribeP2 = dataContext.FactionP1 != Faction.Orcs ? (Tribe)new Orcs() : (Tribe)new Dwarves();
                    break;
            }

            int sizeOfMap = (int)Math.Sqrt(GameImpl.INSTANCE.Map.mapCells.Length);

            WrapperMapBuilder mBuilder = new WrapperMapBuilder();
            int defaultXP1;
            int defaultYP1;
            int defaultXP2;
            int defaultYP2;

            unsafe
            {
                mBuilder.placePlayer1(sizeOfMap, &defaultXP1, &defaultYP1);
                mBuilder.placePlayer2(sizeOfMap, &defaultXP2, &defaultYP2);
            }

            GameImpl.INSTANCE.Player1 = new PlayerImpl(tribeP1, defaultXP1, defaultYP1, mapbuilder.NumberOfUnits, dataContext.NicknameP1 != null && dataContext.NicknameP1.Length > 1 ? dataContext.NicknameP1 : "Player 1");
            GameImpl.INSTANCE.Player2 = new PlayerImpl(tribeP2, defaultXP1, defaultYP2, mapbuilder.NumberOfUnits, dataContext.NicknameP2 != null && dataContext.NicknameP2.Length > 1 ? dataContext.NicknameP2 : "Player 2");

            GameImpl.INSTANCE.CurrentPlayer = GameImpl.INSTANCE.Player1; // Le joueur 1 commence
            GameImpl.INSTANCE.OpponentPlayer = GameImpl.INSTANCE.Player2;

            GameImpl.INSTANCE.RemainingTurns = mapbuilder.TurnsToPlay;

            return GameImpl.INSTANCE;
        }
    }
}
