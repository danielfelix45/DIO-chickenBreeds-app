using DIO.chickenbreeds;

namespace DIO.chickenbreed
{
  class Program
  {
    static BreedRepository repositorio = new BreedRepository();
    static void Main(string[] args)
    {
      string userOption = GetUserOption();

      while (userOption.ToUpper() != "X")
      {
        switch (userOption)
        {
          case "1":
            ListBreed();
            break;
          case "2":
            InsertBreed();
            break;
          case "3":
            UpdateBreed();
            break;
          case "4":
            DeleteBreed();
            break;
          case "5":
            ViewBreed();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        userOption = GetUserOption();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void DeleteBreed()
    {
      Console.Write("Digite o id da raça: ");
      int indexBreed = int.Parse(Console.ReadLine());

      repositorio.Delete(indexBreed);
    }

    private static void ViewBreed()
    {
      Console.Write("Digite o id da raça: ");
      int indexBreed = int.Parse(Console.ReadLine());

      var breed = repositorio.ReturnById(indexBreed);

      Console.WriteLine(breed);
    }

    private static void UpdateBreed()
    {
      Console.Write("Digite o id da raça: ");
      int indexBreed = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Color)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Color), i));
      }
      Console.Write("Digite a cor entre as opções acima: ");
      int colorInput = int.Parse(Console.ReadLine());

      Console.Write("Digite o Nome da Raça: ");
      string nameInput = Console.ReadLine();

      Console.Write("Digite o Ano que Surgiu a Raça: ");
      int yearInput = int.Parse(Console.ReadLine());

      Console.Write("Digite a Origem da Raça: ");
      string originInput = Console.ReadLine();

      Breed updateBreed = new Breed(id: indexBreed,
                    color: (Color)colorInput,
                    name: nameInput,
                    year: yearInput,
                    origin: originInput);

      repositorio.Update(indexBreed, updateBreed);
    }

    private static void ListBreed()
    {
      Console.WriteLine("Listar raças");

      var list = repositorio.List();

      if (list.Count == 0)
      {
        Console.WriteLine("Nenhuma raça cadastrada.");
        return;
      }

      foreach (var breed in list)
      {
        var deleted = breed.returnDeleted();
        Console.WriteLine("#ID {0}: - {1} {2}", breed.returnId(), breed.returnName(), (deleted ? "*Excluído*" : ""));
      }
    }

    private static void InsertBreed()
    {
      Console.WriteLine("Inserir nova raça");

      foreach (int i in Enum.GetValues(typeof(Color)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Color), i));
      }
      Console.Write("Digite a Cor entre as opções acima: ");
      int colorInput = int.Parse(Console.ReadLine());

      Console.Write("Digite o Nome da Raça: ");
      string nameInput = Console.ReadLine();

      Console.Write("Digite o Ano que nasceu a raça: ");
      int yearInput = int.Parse(Console.ReadLine());

      Console.Write("Digite a Origem da raça: ");
      string originInput = Console.ReadLine();

      Breed newBreed = new Breed(id: repositorio.NextId(),
                    color: (Color)colorInput,
                    name: nameInput,
                    year: yearInput,
                    origin: originInput);

      repositorio.Insert(newBreed);
    }
    private static string GetUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("FÉLIX Galinhas ornamentais a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar raças");
      Console.WriteLine("2- Inserir nova raça");
      Console.WriteLine("3- Atualizar raça");
      Console.WriteLine("4- Excluir raça");
      Console.WriteLine("5- Visualizar raça");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string userOption = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return userOption;
    }
  }
}




