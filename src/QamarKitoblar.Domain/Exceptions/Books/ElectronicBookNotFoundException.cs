namespace QamarKitoblar.Domain.Exceptions.Books
{
    public class ElectronicBookNotFoundException : NotFoundException
    {
        public ElectronicBookNotFoundException()
        {
            this.TitleMessage = "Electron book not found!";
        }
    }
}
