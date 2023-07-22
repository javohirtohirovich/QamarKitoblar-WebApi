namespace QamarKitoblar.Domain.Exceptions.Publishers
{
    public class PublisherNotFoundException : NotFoundException
    {
        public PublisherNotFoundException()
        {
            this.TitleMessage = "Publisher not found!";
        }
    }
}
