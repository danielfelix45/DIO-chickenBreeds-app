using DIO.chickenbreeds;

namespace DIO.chickenbreed
{
  public class Breed : BaseEntity
  {
    private string Name { get; set; }
    private string Origin { get; set; }
    private int YearOrigin { get; set; }
    private Color Color { get; set; }
    private bool Deleted { get; set; }

    public Breed() { }
    public Breed(int id, string name, string origin, int year, Color color)
    {
      Id = id;
      Name = name;
      Origin = origin;
      YearOrigin = year;
      Color = color;
      Deleted = false;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Nome: " + Name + Environment.NewLine;
      retorno += "Origem: " + Origin + Environment.NewLine;
      retorno += "Ano: " + YearOrigin + Environment.NewLine;
      retorno += "Cor: " + Color + Environment.NewLine;
      retorno += "Excluído: " + Deleted;
      return retorno;
    }

    public string returnName()
    {
      return Name;
    }

    public int returnId()
    {
      return Id;
    }

    public bool returnDeleted()
    {
      return Deleted;
    }

    public void Delete()
    {
      Deleted = true;
    }
  }
}