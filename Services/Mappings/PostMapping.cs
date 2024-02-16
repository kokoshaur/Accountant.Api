using Models;

namespace Services.Mappings
{
    public static class PostMapping
    {
        public static uint ToSalary(this POST post)
        {
            switch(post)
            {
                case POST.Jun:
                    return 70000;
                case POST.Middle:
                    return 200000;
                case POST.Senior:
                    return 400000;
                default:
                    return 0;
            }
        }
    }
}
