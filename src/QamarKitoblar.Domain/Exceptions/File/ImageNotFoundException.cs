namespace QamarKitoblar.Domain.Exceptions.File;

public class ImageNotFoundException : NotFoundException
{
    public ImageNotFoundException()
    {
        TitleMessage = "Image not found!";
    }
}
