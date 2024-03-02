namespace Mission08_Team0115.Models
{
    public interface IQuadrantRepository
    {
        List<Quadrant> Quadrants { get; }
        List<TaskCategory> TaskCategories { get; }

        public void AddTask(Quadrant task);
        public void RemoveTask(Quadrant task);
        public void UpdateTask(Quadrant task);
    }
}
