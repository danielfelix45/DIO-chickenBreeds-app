using DIO.chickenbreed.Interfaces;

namespace DIO.chickenbreed
{
  public class BreedRepository : IRepository<Breed>
  {
    private List<Breed> listBreed = new List<Breed>();
    public void Delete(int id)
    {
      listBreed[id].Delete();
    }

    public void Insert(Breed entity)
    {
      listBreed.Add(entity);
    }

    public List<Breed> List()
    {
      return listBreed;
    }

    public int NextId()
    {
      return listBreed.Count;
    }

    public Breed ReturnById(int id)
    {
      return listBreed[id];
    }

    public void Update(int id, Breed entity)
    {
      listBreed[id] = entity;
    }
  }
}