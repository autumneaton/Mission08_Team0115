namespace Mission08_Team0115.Models
{
    public class EFQuadrantRepository : IQuadrantRepository
    {
        private Mission08QuadrantsContext _context;
        public EFQuadrantRepository(Mission08QuadrantsContext temp)  
        {
            _context = temp;
        }

        public List<Quadrant> Quadrants => _context.Quadrants.ToList();

        public List<TaskCategory> TaskCategories => _context.Categories.ToList();

        public void AddTask(Quadrant quadrant) 
        {
            _context.Add(quadrant);
            _context.SaveChanges();
        }

        public void RemoveTask(Quadrant quadrant)
        {
            //_context.Add(quadrant);
            //_context.SaveChanges();
        }

        public void UpdateTask(Quadrant quadrant)
        {
            //_context.Add(quadrant);
           // _context.SaveChanges();
        }
    }
}
