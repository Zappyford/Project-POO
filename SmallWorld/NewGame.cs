using PetitMonde.Map;
using PetitMonde.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde
{
    public enum MapSize
    {
        demo,
        small,
        medium
    }

    /// <summary>
    /// GameBuilder for a new game
    /// </summary>
    public class NewGame : GameBuilderImpl
    {
        private string nicknameP1;
        private string nicknameP2;
        private Faction factionP1;
        private Faction factionP2;
        private MapSize mapSize;
        private int numberOfUnits;

        public NewGame(string nicknameP1, string nicknameP2, Faction tribeP1, Faction tribeP2, MapSize mapSize)
        {
            this.mapSize = mapSize;
            this.nicknameP1 = nicknameP1;
            this.nicknameP2 = nicknameP2;
            this.factionP1 = tribeP1;
            this.factionP2 = tribeP2;
        }
    
        public override Game BuildGame()
        {
            MapBuilder mapbuilder;

            switch (mapSize)
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
            /// 
            Tribe tribeP1;
            Tribe tribeP2;

            switch(factionP1){
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

            switch(factionP2){
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
                    tribeP2 = factionP1 != Faction.Orcs ? (Tribe)new Orcs() : (Tribe)new Dwarves();
                    break;
            }

            GameImpl.INSTANCE.Player1 = new PlayerImpl(tribeP1, 0, 0, mapbuilder.numberOfUnits, nicknameP1);
            GameImpl.INSTANCE.Player2 = new PlayerImpl(tribeP2, 0, 0, mapbuilder.numberOfUnits, nicknameP2);

            return GameImpl.INSTANCE;
        }
    }
}
