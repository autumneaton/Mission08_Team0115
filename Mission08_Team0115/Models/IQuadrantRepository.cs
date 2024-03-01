namespace Mission08_Team0115.Models
{
    public interface IQuadrantRepository
    {
        List<Quadrant> Quadrants { get; }

        public void AddTask(Quadrant task);
    }
}
