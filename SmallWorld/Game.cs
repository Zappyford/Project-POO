namespace PetitMonde
{
    public interface Game
    {

        Player GetCurrentPlayer();

        Player GetOpponentPlayer();

        public void AttackUnit(Units.Unit unit, Map.Cells.Cell dest);
    }
}
