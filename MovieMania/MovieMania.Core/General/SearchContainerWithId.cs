namespace MovieMania.Core.General
{
    public class SearchContainerWithId<T> : SearchContainer<T>
    {
        public int Id { get; set; }
    }
}
