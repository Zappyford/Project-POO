using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PetitMonde
{
    /// <summary>
    /// Game builder for a prevously saved game
    /// </summary>
    public class SavedGame : GameBuilderImpl
    {
        SavedGameDataContext dataContext;
        public SavedGame(SavedGameDataContext data)
        {
            dataContext = data;
        }

        public override Game BuildGame()
        {
            if (File.Exists(dataContext.path))
            {
                using (Stream FileStream = File.OpenRead(dataContext.path))
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    GameImpl.load((GameImpl)deserializer.Deserialize(FileStream));
                }
            }
            return GameImpl.INSTANCE;
        }
    }
}
