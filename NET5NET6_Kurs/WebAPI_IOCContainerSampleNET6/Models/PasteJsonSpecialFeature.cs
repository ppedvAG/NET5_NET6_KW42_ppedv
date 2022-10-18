namespace WebAPI_IOCContainerSampleNET6.Models
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int genre { get; set; }
    }

}
