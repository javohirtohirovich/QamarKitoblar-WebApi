namespace QamarKitoblar.Domain.Exceptions.Geners;

public class GenerNotFoundException : NotFoundException
{
    public GenerNotFoundException()
    {
        this.TitleMessage = "Gener not found!";
    }
}
